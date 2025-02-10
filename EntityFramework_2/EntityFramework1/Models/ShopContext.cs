

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace EntityFramework1.Models
{
    //muốn lớp này biểu diễn 1 CSDL(có các bảng dữ liệu) đối tượng đó cần kế thừa từ lớp DBContext
    public class ShopContext : DbContext
    {
       public static readonly ILoggerFactory loggerFactory = LoggerFactory.Create(builder =>
       {
            builder.AddFilter((category, level) =>
                category == DbLoggerCategory.Database.Command.Name
                && level == LogLevel.Information)
            .AddConsole(); //Hiện thị ở Console
       });
        //Kiểu thuộc tính là DBSet
        //DBSet là biểu diễn 1 bảng của CSDL mỗi dòng của bảng sẽ được biểu diễn bởi 1 đối tượng
        public DbSet<Product> Products { get; set; } //1 bảng biểu diễn sản phẩm của Product
        //Thuộc tính Products biểu diễn bảng Product trong CSDL (tablename)
        public DbSet<Category> Categories { get; set; } //1 bảng biểu diễn danh mục của Category

        private const string connectionString = @"Server=THANHTHAO\SQLEXPRESS;
                                                Database=shopdata;
                                                User ID=sa;
                                                Password=12345;
                                                TrustServerCertificate=True;";
        //Bất kể khi nào 1 lớp DBContext được tạo ra thì đều nạp chồng phương thức OnConfiguring
        //Method này được chạy khi phướng thức mới này được tạo ra
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //base.OnConfiguring(optionsBuilder);
            //optionsBuilder.UseSqlServer("Server=.;Database=ProductDB;Trusted_Connection=True;");
            optionsBuilder.UseLoggerFactory(loggerFactory);
            optionsBuilder.UseSqlServer(connectionString);
            optionsBuilder.UseLazyLoadingProxies();
        }

    }
}
