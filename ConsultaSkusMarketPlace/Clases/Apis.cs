using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ConsultaSkusMarketPlace.Clases
{
    public class Apis
    {
        [Key]
        public int idApi { get; set; }
        public int idMarketplace { get; set; }
        public string action { get; set; }
        public string urlBase { get; set; }
        public string parametrosUrl { get; set; }
        public string parametrosBody { get; set; }

        public virtual MarketPlace marketplace { get; set; }
    }
}