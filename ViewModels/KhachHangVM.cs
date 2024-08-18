using System.ComponentModel.DataAnnotations;

namespace EcommerceWeb.ViewModels
{
    public class RegisterVM
    {
        [Required(ErrorMessage = "Trường này không được để trống!")]
        [MaxLength(20, ErrorMessage = "Tối đa 20 ký tự!")]
        [Display(Name = "Mã khách hàng")]
        public string? MaKh { get; set; }

        [Required(ErrorMessage = "Trường này không được để trống!")]
        [MaxLength(50, ErrorMessage = "Tối đa 50 ký tự!")]
        [DataType(DataType.Password)]
        [Display(Name = "Mật khẩu")]
        public string? MatKhau { get; set; }

        [Required(ErrorMessage = "Trường này không được để trống!")]
        [MaxLength(50, ErrorMessage = "Tối đa 50 ký tự!")]
        [Display(Name = "Họ tên")]
        public string? HoTen { get; set; }

        [Display(Name = "Giới tính")]
        public bool GioiTinh { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Ngày sinh")]
        public DateTime NgaySinh { get; set; }

        [Required(ErrorMessage = "Trường này không được để trống!")]
        [MaxLength(60, ErrorMessage = "Tối đa 60 ký tự!")]
        [Display(Name = "Địa chỉ")]
        public string? DiaChi { get; set; }

        [Required(ErrorMessage = "Trường này không được để trống!")]
        [MaxLength(24, ErrorMessage = "Tối đa 24 ký tự!")]
        //[RegularExpression(@"[0][9875]/d[8]")]
        [Display(Name = "Điện thoại")]
        public string? DienThoai { get; set; }

        [EmailAddress(ErrorMessage = "Chưa đúng định dạng email!")]
        [Display(Name = "Email")]
        public string? Email { get; set; }

        [Display(Name = "Hình ảnh")]
        public string? HinhAnh { get; set; }
    }
}
