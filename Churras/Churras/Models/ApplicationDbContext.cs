using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace Churras.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Churrasco> Churrascos { get; set; }
        public DbSet<ParticipanteChurrasco> ParticipanteChurrascos { get; set; }

        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ParticipanteChurrasco>()
                .HasRequired(c => c.Churrasco)
                .WithMany()
                .WillCascadeOnDelete(false);

            base.OnModelCreating(modelBuilder);
        }
    }
}