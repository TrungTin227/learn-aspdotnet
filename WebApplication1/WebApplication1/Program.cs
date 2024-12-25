namespace WebApplication1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews(); //Đăng  ký các Controler vào DI

            builder.Services.AddSingleton<IRepository>(services => new MyRepository(services.GetRequiredService<ILogger<MyRepository>>())); //Đăng ký MyRepository vào DI

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts(); //HSTS là một cơ chế bảo mật HTTP giúp ngăn chặn các cuộc tấn công trung gian
            }

            app.UseHttpsRedirection(); //Nếu truy cập vào trang web bằng http thì sẽ tự động chuyển hướng sang https tương ứng
            app.UseStaticFiles(); //Dùng để phục vụ các file tĩnh như css, js, image

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
