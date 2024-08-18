using EcommerceWeb.Helpers;
using EcommerceWeb.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceWeb.ViewComponents
{
    public class CartViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var cart = HttpContext.Session.Get<List<CartVM>>(MySettings.CART_KEY) ?? new List<CartVM>();
            return View("CartPanel", new CartModel
            {
                Quantity = cart.Sum(c => c.SoLuong),
                Total = cart.Sum(c => c.ThanhTien),
            });
        }
    }
}
