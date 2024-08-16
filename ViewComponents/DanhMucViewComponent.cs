using EcommerceWeb.Data;
using EcommerceWeb.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EcommerceWeb.ViewComponents
{
    public class DanhMucViewComponent : ViewComponent
    {
        private readonly EcommerceDbContext _context;

        public DanhMucViewComponent(EcommerceDbContext context) => _context = context;

        public IViewComponentResult Invoke()
        {
            var result = _context.Loais.Select(loai => new DanhMucVM
            {
                MaLoai = loai.MaLoai,
                TenLoai = loai.TenLoai,
                SoLuong = loai.HangHoas.Count
            }).OrderBy(loai => loai.TenLoai);
            return View(result);
        }
    }
}
