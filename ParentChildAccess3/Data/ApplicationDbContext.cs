using Microsoft.EntityFrameworkCore;
using ParentChildAccess3.Model;

namespace ParentChildAccess3.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Node> Nodes { get; set; }
        public DbSet<NodeClosure> NodeClosures { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Node entity
            modelBuilder.Entity<Node>()
                .HasKey(n => n.NodeId);

            modelBuilder.Entity<Node>()
                .Property(n => n.Name)
                .IsRequired();

            // NodeClosure entity
            modelBuilder.Entity<NodeClosure>()
                .HasKey(nc => new { nc.AncestorId, nc.DescendantId });

            modelBuilder.Entity<NodeClosure>()
                .HasOne(nc => nc.Ancestor)
                .WithMany()
                .HasForeignKey(nc => nc.AncestorId)
                .OnDelete(DeleteBehavior.Restrict); // Prevent cascade delete

            modelBuilder.Entity<NodeClosure>()
                .HasOne(nc => nc.Descendant)
                .WithMany()
                .HasForeignKey(nc => nc.DescendantId)
                .OnDelete(DeleteBehavior.Restrict); // Prevent cascade delete

            modelBuilder.Entity<NodeClosure>()
                .Property(nc => nc.Depth)
                .IsRequired();

            // Optional: Configure indexes for faster lookup
            modelBuilder.Entity<NodeClosure>()
                .HasIndex(nc => nc.AncestorId);

            modelBuilder.Entity<NodeClosure>()
                .HasIndex(nc => nc.DescendantId);
        }
    }
}