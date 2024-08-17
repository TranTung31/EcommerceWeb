using EcommerceWeb.Data;
using EcommerceWeb.Helpers;
using EcommerceWeb.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceWeb.Controllers
{
    public class CartController : Controller
    {
        private readonly EcommerceDbContext _context;

        public CartController(EcommerceDbContext context)
        {
            _context = context;
        }

        const string CART_KEY = "MyCart";

        public List<CartVM> cart => HttpContext.Session.Get<List<CartVM>>(CART_KEY) ?? new List<CartVM>();

        public IActionResult Index()
        {
            return View(cart);
        }

        public IActionResult AddToCart(int id, int quantity = 1)
        {
            var gioHang = cart;
            var item = gioHang.FirstOrDefault(c => c.MaHh == id);

            if (item == null)
            {
                var hangHoa = _context.HangHoas.FirstOrDefault(p => p.MaHh == id);
                if (hangHoa == null)
                {
                    TempData["Message"] = $"Không tìm thấy sản phẩm có mã {id}";
                    return Redirect("/404");
                }
                else
                {
                    item = new CartVM
                    {
                        MaHh = hangHoa.MaHh,
                        TenHh = hangHoa.TenHh,
                        HinhAnh = hangHoa.Hinh ?? "",
                        DonGia = hangHoa.DonGia ?? 0,
                        SoLuong = quantity
                    };
                    gioHang.Add(item);
                }
            } else
            {
                item.SoLuong += quantity;
            }

            HttpContext.Session.Set(CART_KEY, gioHang);

            return RedirectToAction("Index");
        }

        public IActionResult RemoveCart(int id)
        {
            var gioHang = cart;
            var item = gioHang.FirstOrDefault(c => c.MaHh == id);

            if (item != null)
            {
                gioHang.Remove(item);
                HttpContext.Session.Set(CART_KEY, gioHang);
            }

            return RedirectToAction("Index");
        }
    }
}
