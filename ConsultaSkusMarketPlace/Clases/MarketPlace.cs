using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ConsultaSkusMarketPlace.Clases
{
    public class MarketPlace
    {
        [Key]
        public int idMarketplace { get; set; }
        public string descripcion { get; set; }
        public int codigoReservaSap { get; set; }
        public string userId { get; set; }
        public string apiKey { get; set; }
        public string marcaMarketPlace { get; set; }
        public int periodicidadInv { get; set; }
        public string rutaImagenes { get; set; }
        public DateTime fechaUltimaCarga { get; set; }
        public DateTime fechaCreacion { get; set; }

        public virtual ICollection<Categorias> Categorias { get; set; }
        public virtual ICollection<Tallas> Tallas { get; set; }
        public virtual ICollection<Skus> Skus { get; set; }
        public virtual ICollection<Apis> Apis { get; set; }
    }
}