using AutoMapper;
using EcommerceWeb.Data;
using EcommerceWeb.ViewModels;
using EcommerceWeb.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceWeb.Controllers
{
    public class KhachHangController : Controller
    {
        private readonly EcommerceDbContext _context;
        private readonly IMapper _mapper;

        public KhachHangController(EcommerceDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult DangKy()
        {
            return View();
        }

        public IActionResult DangKyForm(RegisterVM model, IFormFile HinhAnh)
        {
            try
            {
                var khachHang = _mapper.Map<KhachHang>(model);
                khachHang.RandomKey = Utils.GenerateRandomKey();
                khachHang.MatKhau = model.MatKhau.ToMd5Hash(khachHang.RandomKey);
                khachHang.HieuLuc = true;
                khachHang.VaiTro = 0;

                if (HinhAnh != null)
                {
                    khachHang.Hinh = Utils.UploadImage(HinhAnh, "KhachHang");
                }
                _context.KhachHangs.Add(khachHang);
                _context.SaveChanges();
                return RedirectToAction("Index", "HangHoa");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
