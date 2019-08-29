using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ConsultaSkusMarketPlace.Clases
{
    public class Skus
    {
        [Key]
        public int idSku { get; set; }
        public int idMarketplace { get; set; }
        public string sku { get; set; }
        public int inventario { get; set; }
        public string estado { get; set; }
        public DateTime fechaHoraCarga { get; set; }
        public DateTime fechaCreacion { get; set; }

        public virtual MarketPlace marketplace { get; set; }
    }
}