using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{

    //represents our database
    public class MovieShopDbContext : DbContext
    {
        public MovieShopDbContext(DbContextOptions<MovieShopDbContext> options): base(options)
        {



        }


        public DbSet<Genre> Genres { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Trailer> Trailers { get; set; }
        public DbSet<MovieGenre> MovieGenres { get; set; }
        public DbSet<Cast> Casts { get; set; }
        public DbSet<MovieCast> MovieCasts { get; set; }
        public DbSet<Crew> Crews { get; set; }
        public DbSet<MovieCrew> MovieCrews { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Purchase> Purchases { get; set; } 
        public DbSet<Favorite> Favorites { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>(ConfigureMovie);
            modelBuilder.Entity<Trailer>(ConfigureTrailer);
            modelBuilder.Entity<MovieGenre>(ConfigureMovieGenre);
            modelBuilder.Entity<Cast>(ConfigureCast);
            modelBuilder.Entity<MovieCast>(ConfigureMovieCast);
            modelBuilder.Entity<Crew>(ConfigureCrew);
            modelBuilder.Entity<MovieCrew>(ConfigureMovieCrew);
            modelBuilder.Entity<User>(ConfigureUser);
            modelBuilder.Entity<Purchase>(ConfigurePurchase);
            modelBuilder.Entity<Favorite>(ConfigureFavorite);
            modelBuilder.Entity<Role>(ConfigureRole);
            modelBuilder.Entity<UserRole>(ConfigureUserRole);
        }


        public void ConfigureUserRole(EntityTypeBuilder<UserRole> builder)
        {
            builder.ToTable("UserRole");
            builder.HasKey(ur => new { ur.UserId, ur.RoleId });
            builder.HasOne(m => m.User).WithMany(m => m.RolesOfUser).HasForeignKey(u => u.UserId);
            builder.HasOne(m => m.Role).WithMany(m => m.UsersOfRole).HasForeignKey(u => u.RoleId);

            //   builder.HasOne(m => m.Movie).WithMany(m => m.GenresOfMovie).HasForeignKey(m => m.MovieId);
            //  builder.HasOne(m => m.Genre).WithMany(m => m.MoviesOfGenre).HasForeignKey(m => m.GenreId);
        }

        public void ConfigureRole(EntityTypeBuilder<Role> builder)
        {
            builder.ToTable("Role");
            builder.HasKey(r => r.Id);
            builder.Property(r => r.Name).HasMaxLength(20);
        }

        public void ConfigureFavorite(EntityTypeBuilder<Favorite> builder)
        {
            builder.ToTable("Favorite");
            builder.HasKey(f=> f.Id);
            builder.HasOne(m => m.Movie).WithMany(m => m.UsersOfFavoriteMovie).HasForeignKey(m => m.MovieId);
            builder.HasOne(m => m.User).WithMany(m => m.FavoriteMoviesOfUsers).HasForeignKey(m => m.UserId);

        }



        public void ConfigurePurchase(EntityTypeBuilder<Purchase> builder)
        {
            builder.ToTable("Purchase");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.PurchasedNumber).HasColumnType("UniqueIdentifier");
            builder.HasOne(m => m.Movie).WithMany(m => m.PurchasesOfMovie).HasForeignKey(m => m.MovieID);
            builder.HasOne(m => m.User).WithMany(m => m.MoviesOfPurchase).HasForeignKey(m => m.UserId);
            builder.Property(p=>p.TotalPrice).HasPrecision(18, 2);
            //modelBuilder.Entity<Class>().Property(object => object.property).HasPrecision(12, 10);
        }


        public void ConfigureUser(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");
            builder.HasKey(b => b.Id);
            builder.Property(b => b.FirstName).HasMaxLength(128);
            builder.Property(b => b.LastName).HasMaxLength(128);
            builder.Property(b => b.Email).HasMaxLength(256);
            builder.Property(b => b.HashedPassword).HasMaxLength(1024);
            builder.Property(b => b.Salt).HasMaxLength(1024);
            builder.Property(b => b.PhoneNumber).HasMaxLength(16);

        }

        public void ConfigureMovieCrew(EntityTypeBuilder<MovieCrew> builder)
        {
            builder.ToTable("MovieCrew");
            builder.HasKey(mcr => new { mcr.MovieId, mcr.CrewId });
            builder.HasOne(m => m.Movie).WithMany(m => m.CrewsOfMovie).HasForeignKey(m => m.MovieId);
            builder.HasOne(m => m.Crew).WithMany(m => m.MoviesOfCrew).HasForeignKey(m => m.CrewId);
            builder.Property(mcr=> mcr.Department).HasMaxLength(128);
            builder.Property(mcr => mcr.Job).HasMaxLength(128);
        }

        public void ConfigureCrew(EntityTypeBuilder<Crew> builder)
        {
            builder.ToTable("Crew");
            builder.HasKey(cr => cr.Id);
            builder.Property(c => c.ProfilePath).HasMaxLength(2084);
        }


        private void ConfigureMovieCast(EntityTypeBuilder<MovieCast> builder)
        {
            builder.ToTable("MovieCast");
            builder.HasKey(mc => new { mc.MovieId, mc.CastID});
            builder.HasOne(m => m.Movie).WithMany(m => m.CastsOfMovie).HasForeignKey(m => m.MovieId);
            builder.HasOne(m => m.Cast).WithMany(m => m.MoviesOfCast).HasForeignKey(m => m.CastID);
            builder.Property(mc => mc.Character).HasMaxLength(450);
        }

        private void ConfigureCast(EntityTypeBuilder<Cast> builder)
        {
            builder.ToTable("Cast");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Name).HasMaxLength(128).IsRequired();
            builder.Property(c => c.ProfilePath).HasMaxLength(2084).IsRequired();
        }



        private void ConfigureMovieGenre(EntityTypeBuilder<MovieGenre> builder){
            builder.ToTable("MovieGenre");
            builder.HasKey(mg => new { mg.MovieId, mg.GenreId });
            builder.HasOne(m=> m.Movie).WithMany(m=> m.GenresOfMovie).HasForeignKey(m=>m.MovieId);
            builder.HasOne(m => m.Genre).WithMany(m => m.MoviesOfGenre).HasForeignKey(m => m.GenreId);
        }



        private void ConfigureTrailer (EntityTypeBuilder<Trailer> builder)
        {
            builder.ToTable("Trailer");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Name).HasMaxLength(2084);
            builder.Property(t => t.TrailerUrl).HasMaxLength(2084);
        }



        private void ConfigureMovie (EntityTypeBuilder<Movie> builder)
        {
            // going to use Fluent API to config Movie table

            builder.ToTable("Movie");
            builder.HasKey(m => m.Id);
            builder.Property(m => m.Title).HasMaxLength(256).IsRequired();
            builder.Property(m => m.Tagline).HasMaxLength(512);
            builder.Property(m => m.ImdbUrl).HasMaxLength(2084);
            builder.Property(m => m.TmdbUrl).HasMaxLength(2084);
            builder.Property(m => m.PosterUrl).HasMaxLength(2084);
            builder.Property(m => m.BackdropUrl).HasMaxLength(2084);
            builder.Property(m => m.OriginalLanguage).HasMaxLength(64);
            builder.Property(m => m.Price).HasColumnType("decimal(5, 2)").HasDefaultValue(9.9m);
            builder.Property(m => m.Budget).HasColumnType("decimal(18, 4)").HasDefaultValue(9.9m);
            builder.Property(m => m.Revenue).HasColumnType("decimal(18, 4)").HasDefaultValue(9.9m);
            builder.Property(m => m.CreatedDate).HasDefaultValueSql("getdate()");
        }
    }
}
