using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace Churras.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Churras> Churras { get; set; }
        public DbSet<ParticipanteChurras> ParticipanteChurras { get; set; }

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
            modelBuilder.Entity<ParticipanteChurras>()
                .HasRequired(c => c.Churras)
                .WithMany()
                .WillCascadeOnDelete(false);

            base.OnModelCreating(modelBuilder);
        }
    }
}