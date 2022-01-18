using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProiectDAW.Models;
using ProiectDAW.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectDAW
{
    public class ProjectContext : DbContext

    {
        
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


            modelBuilder.Entity<Role>().HasData(
                new Role { Id = 1, Name="Admin" },
                new Role { Id = 2, Name="User" }
            );

            modelBuilder.Entity<Genre>().HasData(
                new Genre { Id = 28, Name = "Action" },
                new Genre { Id = 12, Name = "Adventure" },
                new Genre { Id = 16, Name = "Animation" },
                new Genre { Id = 35, Name = "Comedy" },
                new Genre { Id = 80, Name = "Crime" },
                new Genre { Id = 99, Name = "Documentary" },
                new Genre { Id = 18, Name = "Drama" },
                new Genre { Id = 10751, Name = "Family" },
                new Genre { Id = 14, Name = "Fantasy" },
                new Genre { Id = 36, Name = "History" },
                new Genre { Id = 27, Name = "Horror" },
                new Genre { Id = 10402, Name = "Music" },
                new Genre { Id = 9648, Name = "Mystery" },
                new Genre { Id = 10749, Name = "Romance" },
                new Genre { Id = 878, Name = "Science Fiction" },
                new Genre { Id = 10770, Name = "TV Movie" },
                new Genre { Id = 53, Name = "Thriller" },
                new Genre { Id = 10752, Name = "War" },
                new Genre { Id = 37, Name = "Western" }
            );

            base.OnModelCreating(modelBuilder);
        }
    }
}
