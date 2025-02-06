using EntityFramework1.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace EntityFramework1
{
    class Program
    {
        static void DropDatabase()
        {
            using var dbcontext = new ProductDBContext();
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

            using var dbcontext = new ProductDBContext();
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

        static void InsertProduct()
        {
            using var dbcontext = new ProductDBContext(); //Tạo dbcontext
            /*
             -Model (Product)
            - Add, AddSync
            - SaveChanges, SaveChangesSync
             */
            //tạo ra 1 đối tượng Product
            //var p1 = new Product
            //{
            //    ProductName = "Iphone 13",
            //    Provider = "Apple"
            //};
            //Thêm đối tượng Product vào bảng Product trong CSDL
            //dbcontext.Products.Add(p1);

            //Muốn chèn 1 lúc nhiều dòng dữ liệu trong dbcontext thì sử dụng AddRange
            //AddRange cho phép chèn vào 1 mảng các Models như Product, Customer, Order,....
            var products = new Product[]
            {
                new Product { ProductName = "Iphone 13", Provider = "Apple" },
                new Product { ProductName = "Samsung Galaxy S21", Provider = "Samsung" },
                new Product { ProductName = "Xiaomi Redmi Note 10", Provider = "Xiaomi" }
            };
            dbcontext.AddRange(products);

            

            //Lưu thay đổi vào CSDL
            int sodong = dbcontext.SaveChanges(); //trả về số dòng bị tác động như: thêm, xóa, sửa

            Console.WriteLine($"Da chen {sodong} du lieu");
        }

        static void ReadProduct()
        {
            using var dbcontext = new ProductDBContext(); //Tạo dbcontext
            //Lấy ra tất cả dữ liệu trong bảng Product
            //C1
            //var products = dbcontext.Products
            //    .Where (p => p.ProductId > 2)
            //    .ToList();
            //products.ForEach(p => p.PrintInfo());

            //var qr = from Product in dbcontext.Products
            //         where Product.ProductId > 2
            //         orderby Product.ProductId descending
            //         select Product;

            //qr.ToList().ForEach(p => p.PrintInfo());

            Product? product = (from p in dbcontext.Products
                                where p.ProductId == 2
                                select p).FirstOrDefault();
            if (product != null)
            {
                product.PrintInfo();
            }
            else
            {
                Console.WriteLine("Khong tim thay san pham");
            }

            //foreach (var p in products)
            //{
            //    Console.WriteLine($"{p.ProductId} - {p.ProductName} - {p.Provider}");
            //}
        }

        // Update data on db
        public static void RenameProduct(int id, string newname)
        {
            using var dbcontext = new ProductDBContext();
            Product? product = dbcontext.Products.Find(id);
            if (product != null)
            {
                // product -> DBContext 
                //EntityEntry<Product> entity = dbcontext.Entry(product); // Đối tượng này được dùng để theo dõi sự thay đổi của đối tượng product (Model)
                //entity.State = EntityState.Detached; // Đánh dấu đối tượng product là không được theo dõi
                product.ProductName = newname;
                var datarow = dbcontext.SaveChanges();
                Console.WriteLine($"Updated: {datarow}");
            }
            else
            {
                Console.WriteLine("Not found");
            }
        }

        static void DeleteProduct(int id)
        {
            using var dbcontext = new ProductDBContext();
            Product? product = dbcontext.Products.Find(id);
            if (product != null)
            {
                dbcontext.Products.Remove(product);
                var datarow = dbcontext.SaveChanges();
                Console.WriteLine($"Deleted: {datarow}");
            }
            else
            {
                Console.WriteLine("Not found");
            }
        }

        static void Main(string[] args)
        {
            //Entity -> Database, Table
            // Database -> SQL Server : data01 -> DBContext (Để biểu diễn 1 CSDL đối tượng đó cần kế thừa từ lớp DBContext) ->DBCotext 
            // --product

            //var dbcontext = new ProductDBContext();
            //Đối tượng dbcontext đang biểu diễn CSDL tên data01
            //DropDatabase();
            //CreateDatabase();

            //Insert, Update, Delete, Select
            //InsertProduct();
            //ReadProduct();
            RenameProduct(2, "Iphone 15");

            //DeleteProduct(5);

            //Logging 
        }
    }
}
