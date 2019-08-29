using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ConsultaSkusMarketPlace.Clases
{
    public class Tallas
    {
        [Key]
        public int idTalla { get; set; }
        public int idMarketplace { get; set; }
        public string talla { get; set; }
        public string tallaSAP { get; set; }
        public DateTime fechaCreacion { get; set; }

        public virtual MarketPlace marketplace { get; set; }

    }
}