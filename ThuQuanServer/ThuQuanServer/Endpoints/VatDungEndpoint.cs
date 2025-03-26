namespace ThuQuanServer.Endpoints;

public static class VatDungEndpoint
{
    public static void MapVatDungEndpoints(this IEndpointRouteBuilder app)
    {
        var tagName = "Vat Dung";
        
        app.MapGet("/GetPhieuVatDung", () => { return Results.Ok(); }).WithTags(tagName);
        app.MapPost("/InsertPhieuVatDung", () =>
        {
            return Results.Ok();
        }).WithTags(tagName);
        app.MapPut("/UpdateVatDung", () =>
        {
            return Results.Ok();
        }).WithTags(tagName);
    }
}