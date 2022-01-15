using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProiectDAW.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectDAW
{
    public class ProjectContext : DbContext

    {
        public DbSet<DataBaseModel> DataBaseModels { get; set; }

        // One to Many
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }

        // One to One
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Trailer> Trailers { get; set; }

        public DbSet<Genre> Genres { get; set; }

        // Many to Many
        //public DbSet<User> Users { get; set; }
        //public DbSet<Movie> Movies { get; set; }

        public DbSet<WatchList> WatchLists { get; set; }

        // Many to Many
        //public DbSet<Genre> Genres { get; set; }
        //public DbSet<Movie> Movies { get; set; }

        public DbSet<MovieGenre> MovieGenres { get; set; }

        
        
        
        public ProjectContext(DbContextOptions<ProjectContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("Users","dbo");
            modelBuilder.Entity<Role>().ToTable("Roles", "dbo");
            modelBuilder.Entity<Movie>().ToTable("Movies", "dbo");
            modelBuilder.Entity<Trailer>().ToTable("Trailers", "dbo");
            modelBuilder.Entity<Genre>().ToTable("Genres", "dbo");
            modelBuilder.Entity<WatchList>().ToTable("WatchLists", "dbo");
            modelBuilder.Entity<MovieGenre>().ToTable("MovieGenres", "dbo");


            // One to Many
            modelBuilder.Entity<User>()
                        .HasOne<Role>(user => user.Role)
                        .WithMany(role => role.Users)
                        .HasForeignKey(user => user.RoleId);

            // One to One
            modelBuilder.Entity<Trailer>()
                        .HasOne(trailer => trailer.Movie)
                        .WithOne(movie => movie.Trailer)
                        .HasForeignKey<Trailer>(trailer => trailer.MovieId);

            // Many to Many
            modelBuilder.Entity<WatchList>().HasKey(wl => new { wl.MovieId, wl.UserId });

            modelBuilder.Entity<WatchList>()
                        .HasOne<Movie>(wl => wl.Movie)
                        .WithMany(movie => movie.WatchLists)
                        .HasForeignKey(wl => wl.MovieId);

            modelBuilder.Entity<WatchList>()
                        .HasOne<User>(wl => wl.User)
                        .WithMany(user => user.WatchLists)
                        .HasForeignKey(wl => wl.UserId);

            modelBuilder.Entity<MovieGenre>().HasKey(mg => new { mg.MovieId, mg.GenreId });

            modelBuilder.Entity<MovieGenre>()
                        .HasOne<Movie>(mg => mg.Movie)
                        .WithMany(movie => movie.MovieGenres)
                        .HasForeignKey(mg => mg.MovieId);

            modelBuilder.Entity<MovieGenre>()
                        .HasOne<Genre>(mg => mg.Genre)
                        .WithMany(genre => genre.MovieGenres)
                        .HasForeignKey(mg => mg.GenreId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
