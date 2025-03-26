using Microsoft.AspNetCore.Http.HttpResults;
using MySqlX.XDevAPI.Common;

namespace ThuQuanServer.Endpoints;

public static class PhieuDatEndpoint
{
    public static void MapPhieuDatEndpoints(this IEndpointRouteBuilder app)
    {
        var tagName = "Phieu Dat";
        
        app.MapGet("/GetPhieuDat", () => { return Results.Ok(); }).WithTags(tagName);
        app.MapPost("/InsertPhieuDat", () =>
        {
            return Results.Ok();
        }).WithTags(tagName);
        app.MapPut("/UpdatePhieuDat", () =>
        {
            return Results.Ok();
        }).WithTags(tagName);
    }
}