

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFramework1.Models
{
    [Table("Category")]
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        [StringLength(50)]
        public string Name { get; set; }

        [Column(TypeName = "ntext")]
        public string Description { get; set; }
        //Mỗi category có nhiều sản phẩn thuộc category đó nên ta cần 1 thuộc tính kiểu List<Product> để liệt ke danh sách sản phẩm thuộc category đó
        //Collection navigation property
        public virtual List<Product> Products { get; set; } //Không tạo ra FK trong CSDL, không ảnh hưởng gì cả

    }
}
