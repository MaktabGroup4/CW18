using App.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DataStorage
{
    public class LibraryDbContext : DbContext
    {
        public LibraryDbContext(DbContextOptions<LibraryDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Member>(entity =>
            {
                entity.Property(x => x.Mobile).HasMaxLength(12);
                entity.HasOne(s => s.Address)
                .WithOne(ad => ad.Member)
            .HasForeignKey<Address>(s => s.Id);
                entity.HasData(new Member()
                {
                    Id = 10,
                    FullName = "Abbas Abdi",
                    Email = "abbas.abdi@gmail.com",
                    Age = 23,
                    Mobile = "09121224567",
                });
                entity.HasData(new Member()
                {
                    Id = 11,
                    FullName = "Alireza Alavi",
                    Email = "alireza.alavi@gmail.com",
                    Age = 23,
                    Mobile = "09121224567",
                });
            });

            modelBuilder.Entity<Address>(entity =>
            {
                entity.HasOne(s => s.City)
                .WithOne(ad => ad.Address)
            .HasForeignKey<City>(s => s.Id);
                entity.HasData(new Address()
                {
                    Id = 10,
                    FullAddress = "Kh Taleghani"
                });
                entity.HasData(new Address()
                {
                    Id = 11,
                    FullAddress = "Kh Shariati"
                });
            });

            modelBuilder.Entity<City>(entity =>
            {
                entity.HasOne(c => c.State)
                .WithOne(st => st.City)
            .HasForeignKey<State>(s => s.Id);
                entity.HasData(new City()
                {
                    Id = 10,
                    Name = "Tehran"
                });
                entity.HasData(new City()
                {
                    Id = 11,
                    Name = "Tabriz",
                    
                });
            });

            modelBuilder.Entity<State>(entity =>
            {
                entity.HasData(new State()
                {
                    Id = 10,
                    Name = "Tehran"
                });
                entity.HasData(new State()
                {
                    Id = 11,
                    Name = "Azarbayjan Sharqi"
                });
            });

            modelBuilder.Entity<Book>(entity =>
            {
                entity.HasOne(b => b.Genre)
                .WithMany(g => g.Books)
                .HasForeignKey(s => s.GenreId);
                entity.HasData(new Book()
                {
                    Id = 1,
                    Name = "Emil",
                    Author = "Roso",
                    GenreId = 1
                });
                entity.HasData(new Book()
                {
                    Id = 2,
                    Name = "Ablah",
                    Author = "Dasta",
                    GenreId = 2
                });
                entity.HasData(new Book()
                {
                    Id = 3,
                    Name = "Tarikhe Kholafa",
                    Author = "Jafarian",
                    GenreId = 1
                });
            });

            modelBuilder.Entity<Genre>(entity =>
            {
                entity.HasData(new Genre()
                {
                    Id = 1,
                    Name = "Policy"
                });
                entity.HasData(new Genre()
                {
                    Id = 2,
                    Name = "Novel"
                });
            });

            modelBuilder.Entity<MembersBook>().HasKey(sc => new { sc.MemberId, sc.BookId });

            modelBuilder.Entity<MembersBook>(entity =>
            {
                entity.HasOne(sc => sc.Member)
                .WithMany(s => s.MembersBooks)
                .HasForeignKey(sc => sc.MemberId);
                entity.HasOne(sc => sc.Book)
                .WithMany(s => s.MembersBooks)
                .HasForeignKey(sc => sc.BookId);
                entity.HasData(new MembersBook()
                {
                    Id = 1,
                    BookId = 1,
                    MemberId = 10
                });
                entity.HasData(new MembersBook()
                {
                    Id = 2,
                    BookId = 2,
                    MemberId = 10
                });
                entity.HasData(new MembersBook()
                {
                    Id = 3,
                    BookId = 2,
                    MemberId = 11
                });
            });
        }

        public DbSet<Member> Members { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<MembersBook> MembersBooks { get; set; }
    }
}
