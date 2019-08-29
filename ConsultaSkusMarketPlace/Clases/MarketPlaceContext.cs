using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using ConsultaSkusMarketPlace.Clases;

namespace ConsultaSkusMarketPlace.Clases
{
    public class MarketPlaceContext : DbContext
    {
        public MarketPlaceContext() : base("DefaultConnection")
        {

        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public DbSet<MarketPlace> marketPlaces { get; set; }
        public DbSet<Categorias> categorias { get; set; }
        public DbSet<Tallas> tallas { get; set; }
        public DbSet<Skus> skus { get; set; }
        public DbSet<Apis> apis { get; set; }


    }
}