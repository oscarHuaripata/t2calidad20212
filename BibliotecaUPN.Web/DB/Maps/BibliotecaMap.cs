using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.ModelConfiguration;
using BibliotecaUPN.Web.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace BibliotecaUPN.Web.DB.Maps
{
    public class BibliotecaMap : EntityTypeConfiguration<Biblioteca>
    {
        public BibliotecaMap()
        {
            ToTable("Biblioteca");
            HasKey(o => o.Id);

            Property(o => o.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            HasRequired(o => o.Libro)
                .WithMany()
                .HasForeignKey(o => o.LibroId);
        }
    }
}