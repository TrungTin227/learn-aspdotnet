
using ConfigurationDemo.ConfigModels;

namespace ConfigurationDemo
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args); //Luôn luôn tạo 1 web application builder
            //sau đó chúng ta đăng ký các dịch vụ cần thiết cho ứng dụng
            //rồi sau cùng build ứng dụng 
            //và cấu hình host rồi chúng ta chạy run

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Configuration.AddJsonFile("my-appsettings.json", optional: true);
            builder.Configuration.AddJsonFile($"my-appsettings.{builder.Environment.EnvironmentName}.json", optional: true);
            builder.Services.Configure<ApiSettings>(builder.Configuration.GetSection("ApiSettings"));
            var host = builder.Build();

            // Configure the HTTP request pipeline.
            if (!host.Environment.IsDevelopment())
            {
                host.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                host.UseHsts();
            }

            host.UseHttpsRedirection();
            host.UseStaticFiles();

            host.UseRouting();

            host.UseAuthorization();

            host.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            var t = host.RunAsync();
            Console.WriteLine("Press ENTER to stop");
            Console.ReadLine();
            await host.StopAsync();
            await t;
        }
    }
}
