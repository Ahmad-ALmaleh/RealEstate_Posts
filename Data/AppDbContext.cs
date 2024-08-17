using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using test.Models;
using static System.Net.Mime.MediaTypeNames;

namespace test.Data
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        { }
            public DbSet<Post> Posts { get; set; }
        public DbSet<PostDetails> PostDetails { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<SavedPost> SavedPosts { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Post and PostDetails: One-to-One relationship
            modelBuilder.Entity<Post>()
                .HasOne(p => p.PostDetails)
                .WithOne(d => d.Post)
                .HasForeignKey<PostDetails>(d => d.PostId)
                .OnDelete(DeleteBehavior.Cascade);

            // Post and Image: One-to-Many relationship
            modelBuilder.Entity<Post>()
                .HasMany(p => p.Photos)
                .WithOne(i => i.Post)
                .HasForeignKey(i => i.PostId)
                .OnDelete(DeleteBehavior.Cascade);

            // Post and AppUser: Many-to-One relationship
            modelBuilder.Entity<Post>()
                .HasOne(p => p.Owner)
                .WithMany(u => u.Posts)
                .HasForeignKey(p => p.OwnerId)
                .OnDelete(DeleteBehavior.Cascade);

            // SavedPost: Many-to-Many relationship
            modelBuilder.Entity<SavedPost>()
                .HasKey(sp => new { sp.PostId, sp.UserId });

            modelBuilder.Entity<SavedPost>()
                .HasOne(sp => sp.Post)
                .WithMany(p => p.SavedPosts)
                .HasForeignKey(sp => sp.PostId)
                .OnDelete(DeleteBehavior.Restrict); // Avoiding multiple cascade paths

            modelBuilder.Entity<SavedPost>()
                .HasOne(sp => sp.User)
                .WithMany(u => u.SavedPosts)
                .HasForeignKey(sp => sp.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }



        // protected override void OnModelCreating(ModelBuilder modelBuilder)
        // {
        //     base.OnModelCreating(modelBuilder);

        //     modelBuilder.Entity<Post>()
        //         .HasOne(p => p.Owner)
        //         .WithMany(u => u.Posts)
        //         .HasForeignKey(p => p.OwnerId)
        //         .OnDelete(DeleteBehavior.Cascade);

        //     modelBuilder.Entity<Post>()
        //         .HasMany(p => p.Photos)
        //         .WithOne(i => i.Post)
        //         .HasForeignKey(i => i.PostId)
        //         .OnDelete(DeleteBehavior.Cascade);

        //     modelBuilder.Entity<Post>()
        //.HasOne(p => p.PostDetails)
        //.WithOne(d => d.Post)
        //.HasForeignKey<PostDetails>(d => d.PostId) // Specify the dependent entity type here
        //.OnDelete(DeleteBehavior.Cascade);

        //     modelBuilder.Entity<Post>()
        //         .HasMany(p => p.SavedPosts)
        //         .WithOne(s => s.Post)
        //         .HasForeignKey(s => s.PostId)
        //         .OnDelete(DeleteBehavior.Cascade);

        //     // Additional configurations if needed...

        //     modelBuilder.Entity<Post>()
        //.HasOne(p => p.PostDetails)
        //.WithOne(d => d.Post)
        //.HasForeignKey<PostDetails>(d => d.PostId)
        //.OnDelete(DeleteBehavior.Cascade);

        //     modelBuilder.Entity<Post>()
        //.HasMany(p => p.Photos)
        //.WithOne(i => i.Post)
        //.HasForeignKey(i => i.PostId)
        //.OnDelete(DeleteBehavior.Cascade);




        //     // Configuring composite primary key for SavedPost
        //     modelBuilder.Entity<SavedPost>()
        //         .HasKey(sp => new { sp.PostId, sp.UserId });

        //     // Configuring one-to-many relationship between AppUser and SavedPost
        //     modelBuilder.Entity<SavedPost>()
        //         .HasOne(sp => sp.User)
        //         .WithMany(u => u.SavedPosts)
        //         .HasForeignKey(sp => sp.UserId)
        //         .OnDelete(DeleteBehavior.Cascade);

        //     // Configuring one-to-many relationship between Post and SavedPost
        //     modelBuilder.Entity<SavedPost>()
        //         .HasOne(sp => sp.Post)
        //         .WithMany(p => p.SavedPosts)
        //         .HasForeignKey(sp => sp.PostId)
        //         .OnDelete(DeleteBehavior.Cascade);
        // }
    }
}

