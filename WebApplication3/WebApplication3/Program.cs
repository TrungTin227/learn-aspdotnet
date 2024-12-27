namespace WebApplication3
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting(); //Được dùng để đăng ký Routing Middleware vào trong hệ thống để nó bắt các url gửi lên và xác định xem url đó sẽ được xử lý bởi Controller nào, Action nào.

            app.UseAuthorization();

            //app.MapControllerRoute(
            //    name: "product-details",
            //    pattern: "p/{id}",
            //    defaults: new {controller = "Product", action = "Details" }
            //    );

            //app.MapControllerRoute(
            //    name: "collection",
            //    pattern: "c/{id=1}",
            //    defaults: new { controller = "Collection", action = "Index" }
            //    );

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Privacy}/{id?}");
            //              Đăng ký một route mặc định cho ứng dụng, nếu không có route nào khớp với url gửi lên thì route này sẽ được sử dụng. Tham số id là optional.
            app.Run();
        }
    }
}
