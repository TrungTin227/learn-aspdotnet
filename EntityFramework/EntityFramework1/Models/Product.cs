
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFramework1.Models
{
    //Khai báo bảng có trong CSDL dbcontext
    [Table("Product")]
    public class Product
    {
        //Để sử dụng lớp này ở db context
        //Những thuộc tính này miêu tả dữ liệu tương ứng CSDL bảng Product
        [Key]
        public int ProductId { get; set; }

        [Required]
        [StringLength(50)]
        public string ProductName { get; set; }

        [StringLength(50)]
        public string Provider { get; set; }

        public void PrintInfo() => Console.WriteLine($"{ProductId} - {ProductName} - {Provider}");

    }
}
