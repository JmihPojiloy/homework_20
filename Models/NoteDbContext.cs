using Microsoft.EntityFrameworkCore;

namespace HW20.Models
{
    public class NoteDbContext : DbContext
    {
        public DbSet<Note> Notes { get; set; }

        public NoteDbContext(DbContextOptions<NoteDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Note>().HasData(
            new Note()
             {
                Id = 1,
                FirstName = "Vasily",
                LastName = "Vasiliev",
                MiddleName = "Vasilievich",
                PhoneNumber = 00001,
                Address = "Pushkin st.",
                Information = "cool man"
            },

            new Note()
            {
                Id = 2,
                FirstName = "Petr",
                LastName = "Petrov",
                MiddleName = "Petrovich",
                PhoneNumber = 00002,
                Address = "Kolotushkin st.",
                Information = "good man"
            },

            new Note()
            {
                Id = 3,
                FirstName = "Sidor",
                LastName = "Sidorov",
                MiddleName = "Sidorovich",
                PhoneNumber = 00003,
                Address = "Hohotushkin st.",
                Information = "zaebis man"
            });
        }
    }
}
