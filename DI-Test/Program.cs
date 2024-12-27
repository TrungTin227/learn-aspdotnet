using Microsoft.Extensions.DependencyInjection;

namespace DI_Test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var serviceCollection = new ServiceCollection(); //Khi dùng các service cần phải đăng ký trước (ASP.NET tạo ra tự động nên bạn sẽ không thấy bước này) 
            //Ví dụ này làm rõ nên ta k dùng các Builder có sẵn mà tự tạo bằng tay

            serviceCollection.AddSingleton<IMySingletonService>(services => new MySingletonService()); //Chỉ duy nhất một object được tạo ra và sử dụng cho tới khi hết vòng đời của collection
            //Tạo ra 1 lần và tồn tại mãi cho đến hết vòng đời của collection
            serviceCollection.AddScoped<IMyScopedService>(services => new MyScopedService());
            // Bất cứ khi nào gọi tới get service thì nó sẽ tạo ra một object mới trong phạm vi cái scope đó
            serviceCollection.AddTransient<IMyTransientService>(services => new MyTransientService());
            //Băt khì khi nào gọi tới một service thì nó sẽ tạo ra một object mới
            var service = serviceCollection.BuildServiceProvider(); //Tạo ra services provider để lấy ra các service ra

            object? obj;

            Console.WriteLine("Get singleton service");
            obj = service.GetService<IMySingletonService>();
            obj = service.GetService<IMySingletonService>();
            obj = service.GetService<IMySingletonService>();

            Console.WriteLine("Get scoped service");
            obj = service.GetService<IMyScopedService>();
            obj = service.GetService<IMyScopedService>();
            obj = service.GetService<IMyScopedService>(); //Gọi 3 lần nhưng chỉ tạo ra 1 object vì nó chỉ tạo ra 1 object trong phạm vi scope

            Console.WriteLine("Get transient service");
            obj = service.GetService<IMyTransientService>();
            obj = service.GetService<IMyTransientService>();
            obj = service.GetService<IMyTransientService>();

            Console.WriteLine();
            Console.WriteLine("--- Create new scope ---");
            Console.WriteLine();

            var scope = service.CreateScope();

            Console.WriteLine("Get singleton service");
            obj = scope.ServiceProvider.GetService<IMySingletonService>(); //K có tạo ra object mới vì nó chỉ tạo ra 1 object trong suốt vòng đời
            obj = scope.ServiceProvider.GetService<IMySingletonService>();
            obj = scope.ServiceProvider.GetService<IMySingletonService>();

            Console.WriteLine("Get scoped service");
            obj = scope.ServiceProvider.GetService<IMyScopedService>();
            obj = scope.ServiceProvider.GetService<IMyScopedService>();
            obj = scope.ServiceProvider.GetService<IMyScopedService>();

            Console.WriteLine("Get transient service");
            obj = scope.ServiceProvider.GetService<IMyTransientService>();
            obj = scope.ServiceProvider.GetService<IMyTransientService>();
            obj = scope.ServiceProvider.GetService<IMyTransientService>();
        }
    }
}
