using System.ComponentModel; 
using System.ComponentModel.DataAnnotations; 
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace WebNauAn_TVU.Models
{
    public class MonAn
    {
        public int Id { get; set; }

        [Display(Name = "Tên món ăn")] 
        public string TenMon { get; set; }

        [Display(Name = "Mô tả")] 
        public string? MoTa { get; set; }

        [Display(Name = "Công thức chế biến")] 
        public string? CongThuc { get; set; }

        [Display(Name = "Hình ảnh")] 
        public string? HinhAnh { get; set; }

        public string? UserId { get; set; }

        [ForeignKey("UserId")]
        [Display(Name = "Người đăng")]
        public virtual IdentityUser? User { get; set; }

        [NotMapped]
        [Display(Name = "Chọn ảnh mới")]
        public IFormFile? ImageFile { get; set; }
    }
}