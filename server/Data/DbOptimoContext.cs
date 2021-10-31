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

        public DbSet<OptimoWork.Models.DbOptimo.VwRollen> VwRollens
        {
          get;
          set;
        }
    }
}
