using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsultaSkusMarketPlace.Clases
{
    public class SkusDafiti
    {
        public SuccessResponse SuccessResponse { get; set; }
    }


    public class Head
    {
        public string RequestId { get; set; }
        public string RequestAction { get; set; }
        public string ResponseType { get; set; }
        public string Timestamp { get; set; }
    }

    public class Images
    {
        public List<string> Image { get; set; }
    }

    public class ProductData
    {
        public string BoxHeight { get; set; }
        public string BoxWidth { get; set; }
        public string BoxLength { get; set; }
        public string BoxWeight { get; set; }
        public string UpperMaterial { get; set; }
        public string InnerMaterial { get; set; }
        public string Activity { get; set; }
        public string Color { get; set; }
        public string ColorNameBrand { get; set; }
        public string ColorFamily { get; set; }
        public string SoleMaterial { get; set; }
        public string ShaftHeight { get; set; }
        public string TipShape { get; set; }
        public string HeelHeight { get; set; }
        public string Gender { get; set; }
        public string Season { get; set; }
    }

    public class Product
    {
        public string SellerSku { get; set; }
        public string ShopSku { get; set; }
        public string Name { get; set; }
        public string Variation { get; set; }
        public string ParentSku { get; set; }
        public string Quantity { get; set; }
        public string Available { get; set; }
        public string Price { get; set; }
        public string SalePrice { get; set; }
        public string SaleStartDate { get; set; }
        public string SaleEndDate { get; set; }
        public string Status { get; set; }
        public string ProductId { get; set; }
        public string Url { get; set; }
        public string MainImage { get; set; }
        public Images Images { get; set; }
        public string Description { get; set; }
        public string TaxClass { get; set; }
        public string Brand { get; set; }
        public string PrimaryCategory { get; set; }
        public ProductData ProductData { get; set; }
    }

    public class Products
    {
        public List<Product> Product { get; set; }
    }

    public class Body
    {
        public Products Products { get; set; }
    }

    public class SuccessResponse
    {
        public Head Head { get; set; }
        public Body Body { get; set; }
    }

}



