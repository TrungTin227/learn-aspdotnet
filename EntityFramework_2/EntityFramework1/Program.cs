using EntityFramework1.Models;
using Microsoft.EntityFrameworkCore;

namespace EntityFramework1
{
    class Program
    {
        static void DropDatabase()
        {
            using var dbcontext = new ShopContext();
            string dbname = dbcontext.Database.GetDbConnection().Database;
            if (dbcontext.Database.EnsureDeleted())
            {
                Console.WriteLine($"Database {dbname} is deleted");
            }
            else
            {
                Console.WriteLine($"Database {dbname} is not existed");
            }
        }
        static void CreateDatabase()
        {

            using var dbcontext = new ShopContext();
            //từ khóa using sẽ giúp giải phóng bộ nhớ khi không còn sử dụng
            string dbname = dbcontext.Database.GetDbConnection().Database;

            // Console.WriteLine(dbname); //lấy tên csdl trong db context

            //Để tạo CSDL từ dbcontext tao gọi thuộc tính Database rồi gọi phương thức EnsureCreated
            if (dbcontext.Database.EnsureCreated())
            {
                Console.WriteLine($"Database {dbname} is created");
            }
            else
            {
                Console.WriteLine($"Database {dbname} is already existed");
            }

        }
        static void InsertData()
        {
            using var dbcontext = new ShopContext();

            Category c1 = new Category() { Name = "Dien thoai", Description = "Cac loai dien thoai" };

            Category c2 = new Category() { Name = "Do uong", Description = "Cac loai do uong" };

            dbcontext.Categories.Add(c1);
            dbcontext.Categories.Add(c2);

            //var c1 = (from c in dbcontext.Categories
            //         where c.CategoryId == 1
            //         select c).FirstOrDefault();

            //var c2 = (from c in dbcontext.Categories
            //          where c.CategoryId == 2
            //          select c).FirstOrDefault();

            dbcontext.Add(new Product() { Name = "Iphone 12", Price = 1000, CateId = 1 });
            dbcontext.Add(new Product() { Name = "Iphone 11", Price = 900, Category = c1 });
            dbcontext.Add(new Product() { Name = "Iphone 10", Price = 800, CateId = 1 });
            dbcontext.Add(new Product() { Name = "Coca", Price = 1, Category = c2 });
            dbcontext.Add(new Product() { Name = "Pepsi", Price = 2, CateId = 2 });
            dbcontext.SaveChanges();
        }

        static void Main(string[] args)
        {
            //DropDatabase();
            //CreateDatabase();
            InsertData();
            using var dbcontext = new ShopContext();
            //var product = (from p in dbcontext.Products where p.ProductId == 3 select p).FirstOrDefault();
            ////Entity entry là đối tượng theo dõi khi ta truy cập vào 1 đối tượng nào đó
            //var e = dbcontext.Entry(product); //lấy đối tượng Entity Entry của sản phẩm Product
            //e.Reference(p => p.Category).Load(); //Load dữ liệu từ bảng Category vào đối tượng Category của Product
            //product.PrintInfo();

            //if (product.Category != null)
            //{
            //    Console.WriteLine($"{product.Category.Name} - {product.Category.Description}");
            //}
            //else
            //{
            //    Console.WriteLine("Category is null");
            //}

            //lấy ra sản phẩm có category bằng 2

            //var category = (from c in dbcontext.Categories where c.CategoryId == 2 select c).FirstOrDefault();
            //Console.WriteLine($"{category.CategoryId} - {category.Name}");
            ////var e = dbcontext.Entry(category);
            ////e.Collection(c => c.Products).Load();
            ////Dùng lazy loading không cần nạp thủ công 
            //if (category.Products != null)
            //{
            //    Console.WriteLine($"So san pham la: {category.Products.Count()}");
            //   category.Products.ForEach(p => p.PrintInfo());
            //}
            //else
            //{
            //    Console.WriteLine("Product is null");
            //}

            //lấy ra sản phẩm có id = 5
            var product = dbcontext.Products.Find(5);
            if (product != null)
            {
                Console.WriteLine($"{product.ProductId} - {product.Name} - {product.Price}");
            }
            else
            {
                Console.WriteLine("Product is null");
            }
        }
    }
}
/*
    Table("TableName")
    [Key] -> Primary Key
    [Required] -> Not Null
    [StringLength(50)] -> string - nvarchar() 
    [Column("ColumnNameAnhXaVaoTableOSQL, "TypeName ="ntext")]
    [ForeignKey("ColumnNameAnhXaVaoTableOSQL")]


    Reference navigation -> Foreign Key (1 - n)
    Collection navigation -> (Không tạo ra Foreign key)(1 - n)
    InverseProperty 
 */
