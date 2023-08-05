using WebShop.BOL.Enums;

namespace WebShop.ViewModels.Products
{
    public class ProductDetailViewModel
    {
        public ProductViewModel Product { get; set; }
        public string PageTitle { get; set; }
        public Size Size { get; set; }
    }
}