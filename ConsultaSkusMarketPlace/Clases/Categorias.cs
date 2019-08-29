using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ConsultaSkusMarketPlace.Clases
{
    public class Categorias
    {
        [Key]
        public int idCategoria { get; set; }
        public int idMarketplace { get; set; }
        public string codigoCategoria { get; set; }
        public string descripcion { get; set; }
        public string edadSAP { get; set; }
        public string generoSAP { get; set; }
        public string grupoArticuloSap { get; set; }
        public DateTime fechaCreacion { get; set; }

        public virtual MarketPlace marketplace { get; set; }

    }
}