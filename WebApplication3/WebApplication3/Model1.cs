namespace WebApplication3
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<Authors> Authors { get; set; }
        public virtual DbSet<Books> Books { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Authors>()
                .Property(e => e.FirstName)
                .IsUnicode(false);

            modelBuilder.Entity<Authors>()
                .Property(e => e.LastName)
                .IsUnicode(false);

            modelBuilder.Entity<Authors>()
                .HasMany(e => e.Books)
                .WithRequired(e => e.Authors)
                .HasForeignKey(e => e.AuthorId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Books>()
                .Property(e => e.Title)
                .IsUnicode(false);

            modelBuilder.Entity<Books>()
                .Property(e => e.Price);




        }
    }
}