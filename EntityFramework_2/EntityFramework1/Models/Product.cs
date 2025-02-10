
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
        [Column("TenSanPham", TypeName="ntext")]
      
        public string Name { get; set; }

        [Column(TypeName = "money")]
        public decimal Price { get; set; }

        public int CateId { get; set; } //thêm dấu ? để cho phép null ở CSDL 

        //ForeignKey
        [ForeignKey("CateId")] //Mặc định là CategoryId nhưng ta dùng attribute để đổi tên theo ta mong muốn
        //[Required] //thì có nghĩa nếu bảng category bị xóa thì sản phẩm không bị ảnh hưởng còn nếu k cho phép null thì khi bảng Category bị xóa sẽ dẫn đến lỗi
        public virtual Category Category { get; set; } // FK -> PK   CategoryId


        public int? CateId2 { get; set; }
        //ForeignKey
        [ForeignKey("CateId2")]
        [InverseProperty("Products")] 
        
        public virtual Category Category2 { get; set; } 
        public void PrintInfo() => Console.WriteLine($"{ProductId} - {Name} - {Price}");

    }
}
