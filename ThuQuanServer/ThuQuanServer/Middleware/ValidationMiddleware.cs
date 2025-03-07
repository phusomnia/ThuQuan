using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using MySqlX.XDevAPI.Common;

namespace ThuQuanServer.Extension;

public class ValidationMiddleware
{
    private readonly RequestDelegate _next;

    public ValidationMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        if ((context.Request.Method == "POST" || context.Request.Method == "PUT")&& context.Request.ContentLength > 0)
        {
            var endPoint = context.GetEndpoint();
            var requestType = endPoint?.Metadata.GetMetadata<Type>();
            if (requestType != null)
            {
                try
                {
                    // 
                    context.Request.EnableBuffering();
                    var body = await new StreamReader(context.Request.Body).ReadToEndAsync();
                    context.Request.Body.Position = 0;
                    
                    var obj = JsonSerializer.Deserialize(body, requestType, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                    if (obj == null)
                    {
                        await ReturnBadRequest(context, new List<ValidationResult>());
                        return;
                    }
                    
                    // 
                    var errors = new List<ValidationResult>();
                    var validationContext = new ValidationContext(obj);
                    if (!Validator.TryValidateObject(obj, validationContext, errors, validateAllProperties: true))
                    {
                        await ReturnBadRequest(context, errors);
                        return;
                    }
                }
                catch (JsonException e)
                {
                    await ReturnBadRequest(context, e.Message);
                    return;
                }
            }
        }
        await _next(context);
    }
    
    private static async Task ReturnBadRequest(HttpContext context, string message)
    {
        context.Response.StatusCode = StatusCodes.Status400BadRequest;
        await context.Response.WriteAsJsonAsync(new { Error = message });
    }

    private static async Task ReturnBadRequest(HttpContext context, List<ValidationResult> errors)
    {
        context.Response.StatusCode = StatusCodes.Status400BadRequest;
        var errorDict = errors.ToDictionary(
            e => e.MemberNames.FirstOrDefault() ?? "General",
            e => e.ErrorMessage
        );
        await context.Response.WriteAsJsonAsync(new { Errors = errorDict });
    }
}

public static class ValidationMiddlewareExtensions
{
    public static IApplicationBuilder UseValidationMiddleware(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<ValidationMiddleware>();
    }
}