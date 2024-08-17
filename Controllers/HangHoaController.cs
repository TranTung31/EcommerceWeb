using EcommerceWeb.Data;
using EcommerceWeb.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EcommerceWeb.Controllers
{
    public class HangHoaController : Controller
    {
        private readonly EcommerceDbContext _context;

        public HangHoaController(EcommerceDbContext context) => _context = context;

        public IActionResult Index(int? loai)
        {
            var hangHoas = _context.HangHoas.AsQueryable();

            if (loai.HasValue)
            {
                hangHoas = hangHoas.Where(p => p.MaLoai == loai.Value);
            }

            var result = hangHoas.Select(p => new HangHoaVM
            {
                MaHh = p.MaHh,
                TenHh = p.TenHh,
                HinhAnh = p.Hinh ?? "",
                MoTa = p.MoTaDonVi ?? "",
                DonGia = p.DonGia ?? 0,
                TenLoai = p.MaLoaiNavigation.TenLoai,
            }).ToList();

            return View(result);
        }

        public IActionResult Search(string? query)
        {
            var hangHoas = _context.HangHoas.AsQueryable();

            if (query != null)
            {
                hangHoas = hangHoas.Where(p => p.TenHh.Contains(query));
            }

            var result = hangHoas.Select(p => new HangHoaVM
            {
                MaHh = p.MaHh,
                TenHh = p.TenHh,
                HinhAnh = p.Hinh ?? "",
                MoTa = p.MoTaDonVi ?? "",
                DonGia = p.DonGia ?? 0,
                TenLoai = p.MaLoaiNavigation.TenLoai,
            }).ToList();

            return View(result);
        }

        public IActionResult Detail(int id)
        {
            var hangHoa = _context.HangHoas.Include(p => p.MaLoaiNavigation).FirstOrDefault(p => p.MaHh == id);

            if (hangHoa == null)
            {
                TempData["Message"] = $"Không tìm thấy sản phẩm có mã {id}";
                return Redirect("/404");
            }

            var result = new ChiTietHangHoaVM
            {
                MaHh = hangHoa.MaHh,
                TenHh = hangHoa.TenHh,
                HinhAnh = hangHoa.Hinh ?? "",
                MoTaNgan = hangHoa.MoTaDonVi ?? "",
                ChiTiet = hangHoa.MoTa,
                DonGia = hangHoa.DonGia ?? 0,
                TenLoai = hangHoa.MaLoaiNavigation.TenLoai,
                DanhGia = 5,
                SoLuongTon = 10,
            };

            return View(result);
        }
    }
}
