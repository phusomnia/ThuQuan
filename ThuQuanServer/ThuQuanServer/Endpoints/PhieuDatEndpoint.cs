namespace ThuQuanServer.Endpoints;

public static class PhieuDatEndpoint
{
    public static IEndpointRouteBuilder MapTaiKhoanEndpoints(this IEndpointRouteBuilder app)
    {   
        var taiKhoanRepository = app.ServiceProvider.GetRequiredService<ITaiKhoanRepository>();
        var passwordHashService = app.ServiceProvider.GetRequiredService<IPasswordHashService>();
        
        var groupName = "TaiKhoan";
        
        // GET API
        app.MapGet("/GetTaiKhoan", (DbContext dbContext) =>
        {
            var taikhoan = taiKhoanRepository.GetAccount();
            return Results.Ok(taikhoan);
        }).WithTags(groupName);
        
        app.MapGet("/GetTaiKhoanById/{id}", ([FromRoute , Required] int? id) =>
        {
            // if (string.IsNullOrEmpty(request)) return RequireMessage(vaiTro);
            var taikhoan = taiKhoanRepository.GetAccountByProps(new {
                Id = id,
            });
            return Results.Ok(taikhoan);
        }).WithTags(groupName);;
        
        app.MapGet("/GetTaiKhoanByVaiTro/{vaitro}", ([FromRoute , Required] string? vaitro) =>
        {
            // if (string.IsNullOrEmpty(request)) return RequireMessage(vaiTro);
            var taikhoan = taiKhoanRepository.GetAccountByProps(new {
                VaiTro = vaitro,
            });
            return Results.Ok(taikhoan);
        }).WithTags(groupName);

        // POST API
        app.MapPost("/InsertTaiKhoan", (
            [FromBody] TaiKhoanRequestDto nhanVienRequest) =>
        {
            // Check existed username
            var existedUserName = taiKhoanRepository.GetAccount()
                .Where(p => p.UserName == nhanVienRequest.UserName);
            
            if (existedUserName.Any())
            {
                return Results.BadRequest("Username is already exist");
            }
            
            // Check existed email
            var existedEmail = taiKhoanRepository.GetAccount()
                .Where(p => p.Email == nhanVienRequest.Email);
            
            if (existedEmail.Any())
            {
                return Results.BadRequest("Email is already exist");
            }

            // Hash password
            nhanVienRequest.Password = passwordHashService.HashPassword(nhanVienRequest.Password);

            // Time
            nhanVienRequest.NgayThamGia = (DateTime.Now);
            Console.WriteLine(nhanVienRequest.NgayThamGia);
            
            if (!taiKhoanRepository.RegisterAccount(nhanVienRequest))
            {
                return Results.BadRequest("Insert TaiKhoan failed");
            }

            return Results.Ok(new ApiResponse
            {
                Success = true,
                Message = "Insert TaiKhoan successully",
                Data = nhanVienRequest
            });
        }).WithMetadata(typeof(TaiKhoanRequestDto)).WithOpenApi(o =>
        {
            o.Security = new List<OpenApiSecurityRequirement>();
            return o;
        }).WithTags(groupName);
        
        // PUT API
        app.MapPut("/UpdateTaiKhoan/{id}", (
            [Required] int id,
            [FromBody] TaiKhoanRequestDto nhanVienRequest) =>
        {
            // taiKhoanRepository.UpdateTaiKhoan(nhanVienRequest, id);
            return Results.Ok();
        }).WithMetadata(typeof(TaiKhoanRequestDto)).WithOpenApi(o =>
        {
            o.Security = new List<OpenApiSecurityRequirement>();
            return o;
        }).WithTags(groupName);

        return app;
    }
}