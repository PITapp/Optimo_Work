using System.Reflection;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

using OptimoWork.Models.DbOptimo;

namespace OptimoWork.Data
{
    public partial class DbOptimoContext : Microsoft.EntityFrameworkCore.DbContext
    {
        private readonly IHttpContextAccessor httpAccessor;

        public DbOptimoContext(IHttpContextAccessor httpAccessor, DbContextOptions<DbOptimoContext> options):base(options)
        {
            this.httpAccessor = httpAccessor;
        }

        public DbOptimoContext(IHttpContextAccessor httpAccessor)
        {
            this.httpAccessor = httpAccessor;
        }

        partial void OnModelBuilding(ModelBuilder builder);

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<OptimoWork.Models.DbOptimo.Base>()
                  .HasOne(i => i.BaseAnreden)
                  .WithMany(i => i.Bases)
                  .HasForeignKey(i => i.AnredeID)
                  .HasPrincipalKey(i => i.AnredeID);
            builder.Entity<OptimoWork.Models.DbOptimo.BaseKontakte>()
                  .HasOne(i => i.Base)
                  .WithMany(i => i.BaseKontaktes)
                  .HasForeignKey(i => i.BaseID)
                  .HasPrincipalKey(i => i.BaseID);
            builder.Entity<OptimoWork.Models.DbOptimo.Benutzer>()
                  .HasOne(i => i.Base)
                  .WithMany(i => i.Benutzers)
                  .HasForeignKey(i => i.BaseID)
                  .HasPrincipalKey(i => i.BaseID);
            builder.Entity<OptimoWork.Models.DbOptimo.InventurArtikel>()
                  .HasOne(i => i.InventurBasis)
                  .WithMany(i => i.InventurArtikels)
                  .HasForeignKey(i => i.InventurID)
                  .HasPrincipalKey(i => i.InventurID);
            builder.Entity<OptimoWork.Models.DbOptimo.InventurBasis>()
                  .HasOne(i => i.InventurBasisStatus)
                  .WithMany(i => i.InventurBases)
                  .HasForeignKey(i => i.LagerortStatus)
                  .HasPrincipalKey(i => i.LagerortStatus);
            builder.Entity<OptimoWork.Models.DbOptimo.InventurDevice>()
                  .HasOne(i => i.InventurBasis)
                  .WithMany(i => i.InventurDevices)
                  .HasForeignKey(i => i.InventurID)
                  .HasPrincipalKey(i => i.InventurID);
            builder.Entity<OptimoWork.Models.DbOptimo.InventurErfassung>()
                  .HasOne(i => i.InventurArtikel)
                  .WithMany(i => i.InventurErfassungs)
                  .HasForeignKey(i => i.ArtikelID)
                  .HasPrincipalKey(i => i.ArtikelID);
            builder.Entity<OptimoWork.Models.DbOptimo.InventurErfassung>()
                  .HasOne(i => i.InventurDevice)
                  .WithMany(i => i.InventurErfassungs)
                  .HasForeignKey(i => i.DeviceID)
                  .HasPrincipalKey(i => i.DeviceID);
            builder.Entity<OptimoWork.Models.DbOptimo.Protokoll>()
                  .HasOne(i => i.Base)
                  .WithMany(i => i.Protokolls)
                  .HasForeignKey(i => i.BaseID)
                  .HasPrincipalKey(i => i.BaseID);

            builder.Entity<OptimoWork.Models.DbOptimo.Protokoll>()
                  .Property(p => p.Gelesen)
                  .HasDefaultValueSql("0");

            builder.Entity<OptimoWork.Models.DbOptimo.VwBase>()
                  .Property(p => p.BaseID)
                  .HasDefaultValueSql("0");

            builder.Entity<OptimoWork.Models.DbOptimo.VwBaseAlle>()
                  .Property(p => p.BaseID)
                  .HasDefaultValueSql("0");

            builder.Entity<OptimoWork.Models.DbOptimo.VwBaseKontakte>()
                  .Property(p => p.BaseID)
                  .HasDefaultValueSql("0");

            builder.Entity<OptimoWork.Models.DbOptimo.VwBenutzerBase>()
                  .Property(p => p.BenutzerID)
                  .HasDefaultValueSql("0");

            builder.Entity<OptimoWork.Models.DbOptimo.VwBenutzerRollen>()
                  .Property(p => p.BenutzerID)
                  .HasDefaultValueSql("0");

            builder.Entity<OptimoWork.Models.DbOptimo.VwInventurArtikel>()
                  .Property(p => p.ArtikelID)
                  .HasDefaultValueSql("0");

            builder.Entity<OptimoWork.Models.DbOptimo.VwInventurArtikel>()
                  .Property(p => p.AnzahlErfasst)
                  .HasDefaultValueSql("0");

            builder.Entity<OptimoWork.Models.DbOptimo.VwInventurArtikelAlle>()
                  .Property(p => p.ArtikelID)
                  .HasDefaultValueSql("0");

            builder.Entity<OptimoWork.Models.DbOptimo.VwInventurErfassung>()
                  .Property(p => p.ErfassungID)
                  .HasDefaultValueSql("0");

            builder.Entity<OptimoWork.Models.DbOptimo.VwInventurLagerorte>()
                  .Property(p => p.InventurID)
                  .HasDefaultValueSql("0");

            builder.Entity<OptimoWork.Models.DbOptimo.VwInventurLagerorte>()
                  .Property(p => p.DeviceID)
                  .HasDefaultValueSql("0");

            builder.Entity<OptimoWork.Models.DbOptimo.VwInventurLagerorteMitSummen>()
                  .Property(p => p.InventurID)
                  .HasDefaultValueSql("0");

            builder.Entity<OptimoWork.Models.DbOptimo.VwInventurLagerorteMitSummen>()
                  .Property(p => p.AnzahlArtikel)
                  .HasDefaultValueSql("0");

            builder.Entity<OptimoWork.Models.DbOptimo.VwInventurLagerorteMitSummen>()
                  .Property(p => p.AnzahlErfasst)
                  .HasDefaultValueSql("0");

            this.OnModelBuilding(builder);
        }


        public DbSet<OptimoWork.Models.DbOptimo.Base> Bases
        {
          get;
          set;
        }

        public DbSet<OptimoWork.Models.DbOptimo.BaseAnreden> BaseAnredens
        {
          get;
          set;
        }

        public DbSet<OptimoWork.Models.DbOptimo.BaseKontakte> BaseKontaktes
        {
          get;
          set;
        }

        public DbSet<OptimoWork.Models.DbOptimo.Benutzer> Benutzers
        {
          get;
          set;
        }

        public DbSet<OptimoWork.Models.DbOptimo.InfotexteHtml> InfotexteHtmls
        {
          get;
          set;
        }

        public DbSet<OptimoWork.Models.DbOptimo.InventurArtikel> InventurArtikels
        {
          get;
          set;
        }

        public DbSet<OptimoWork.Models.DbOptimo.InventurBasis> InventurBases
        {
          get;
          set;
        }

        public DbSet<OptimoWork.Models.DbOptimo.InventurBasisStatus> InventurBasisStatuses
        {
          get;
          set;
        }

        public DbSet<OptimoWork.Models.DbOptimo.InventurDevice> InventurDevices
        {
          get;
          set;
        }

        public DbSet<OptimoWork.Models.DbOptimo.InventurErfassung> InventurErfassungs
        {
          get;
          set;
        }

        public DbSet<OptimoWork.Models.DbOptimo.Notizen> Notizens
        {
          get;
          set;
        }

        public DbSet<OptimoWork.Models.DbOptimo.Protokoll> Protokolls
        {
          get;
          set;
        }

        public DbSet<OptimoWork.Models.DbOptimo.VwBase> VwBases
        {
          get;
          set;
        }

        public DbSet<OptimoWork.Models.DbOptimo.VwBaseAlle> VwBaseAlles
        {
          get;
          set;
        }

        public DbSet<OptimoWork.Models.DbOptimo.VwBaseKontakte> VwBaseKontaktes
        {
          get;
          set;
        }

        public DbSet<OptimoWork.Models.DbOptimo.VwBaseOrte> VwBaseOrtes
        {
          get;
          set;
        }

        public DbSet<OptimoWork.Models.DbOptimo.VwBasePlz> VwBasePlzs
        {
          get;
          set;
        }

        public DbSet<OptimoWork.Models.DbOptimo.VwBenutzerBase> VwBenutzerBases
        {
          get;
          set;
        }

        public DbSet<OptimoWork.Models.DbOptimo.VwBenutzerRollen> VwBenutzerRollens
        {
          get;
          set;
        }

        public DbSet<OptimoWork.Models.DbOptimo.VwErfassungSummen> VwErfassungSummens
        {
          get;
          set;
        }

        public DbSet<OptimoWork.Models.DbOptimo.VwInventurArtikel> VwInventurArtikels
        {
          get;
          set;
        }

        public DbSet<OptimoWork.Models.DbOptimo.VwInventurArtikelAlle> VwInventurArtikelAlles
        {
          get;
          set;
        }

        public DbSet<OptimoWork.Models.DbOptimo.VwInventurErfassung> VwInventurErfassungs
        {
          get;
          set;
        }

        public DbSet<OptimoWork.Models.DbOptimo.VwInventurErfassungSummen> VwInventurErfassungSummens
        {
          get;
          set;
        }

        public DbSet<OptimoWork.Models.DbOptimo.VwInventurLagerorte> VwInventurLagerortes
        {
          get;
          set;
        }

        public DbSet<OptimoWork.Models.DbOptimo.VwInventurLagerorteMitSummen> VwInventurLagerorteMitSummens
        {
          get;
          set;
        }

        public DbSet<OptimoWork.Models.DbOptimo.VwRollen> VwRollens
        {
          get;
          set;
        }
    }
}
