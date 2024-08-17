namespace EcommerceWeb.ViewModels
{
    public class CartVM
    {
        public int MaHh { get; set; }
        public string? TenHh { get; set; }
        public string? HinhAnh { get; set; }
        public double DonGia { get; set; }
        public int SoLuong { get; set; }
        public double ThanhTien => DonGia * SoLuong; 
    }
}
