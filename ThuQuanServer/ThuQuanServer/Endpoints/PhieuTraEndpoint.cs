namespace ThuQuanServer.Endpoints;

public static class PhieuTraEndpoint
{
    public static void MapPhieuTraEndpoints(this IEndpointRouteBuilder app)
    {
        var tagName = "Phieu Tra";
        
        app.MapGet("/GetPhieuTra", () => { return Results.Ok(); }).WithTags(tagName);
        app.MapPost("/InsertPhieuTra", () =>
        {
            return Results.Ok();
        }).WithTags(tagName);
        app.MapPut("/UpdatePhieuTra", () =>
        {
            return Results.Ok();
        }).WithTags(tagName);
    }
}