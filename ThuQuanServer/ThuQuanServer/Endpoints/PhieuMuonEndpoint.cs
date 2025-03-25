namespace ThuQuanServer.Endpoints;

public static class PhieuMuonEndpoint
{
    public static void MapPhieuMuonEndpoints(this IEndpointRouteBuilder app)
    {
        var groupName = "Phieu Muon";
        
        app.MapGet("/GetPhieuMuon", () => { return Results.Ok(); }).WithTags(groupName);
        app.MapPost("/InsertPhieuMuon", () =>
        {
            return Results.Ok();
        }).WithTags(groupName);
        app.MapPut("/UpdatePhieuMuon", () =>
        {
            return Results.Ok();
        }).WithTags(groupName);
    }
}