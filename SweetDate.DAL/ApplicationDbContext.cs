using Microsoft.EntityFrameworkCore;
using SweetDate.Domain.Entity;
using SweetDate.Domain.Hash;

namespace SweetDate.DAL;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        Database.EnsureCreated();
    }

    public DbSet<Person> Person { get; set; }
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>(builder =>
        {
            builder.ToTable("Users").HasKey(x => x.Id);

            builder.HasData(new User[]
            {
                new User()
                {
                    Id = 1,
                    Username = "hahahuug",
                    Name = "Alsu",
                    Login = "alsu@gmail.com",
                    Password = HashPassword.HashPassowrd("123456"),
                }
            });

            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.Password).IsRequired();
            builder.Property(x => x.Name).HasMaxLength(100).IsRequired();

            builder.HasOne(x => x.Person)
                .WithOne(x => x.User)
                .HasPrincipalKey<User>(x => x.Id)
                .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<Person>(builder =>
        {
            builder.ToTable("Person").HasKey(x => x.Id);

            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.HasData(new Person
            {
                Id = 1,
                Gender = "Woman",
                LookingGender = "Man",
                Age = 20,
                Description = "lala",
                Tg = "@kh_alsu",
                City = "Kazan",
                Country = "Russia",
                Avatar = "https://sun9-52.userapi.com/impg/UD9bs5yJxjnU18NeIbnmVhxmBuNC8HngUZxJrQ/EUBmctN6jyw.jpg?size=1808x2160&quality=95&sign=3b8bc51a9f84de9f0d1bf8f2e973c480&type=album",
                // DateCreate = DateTime.Now,
                UserId = 1
            });
        });

    }
}
    