using CRUDCleanArchitecture.Core.Domain.IdentityEntities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace Entities
{
    // IdentityDbContext contains pre define db sets
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, Guid>

    // Without Identity package
    //public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) { }

        // needs to be virtual to allow mock
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Person> Persons { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Country>().ToTable("Countries");
            modelBuilder.Entity<Person>().ToTable("Persons");

            //Add Seed to Countries
            string countriesJson = File.ReadAllText("countries.json");
            List<Country> countries = JsonSerializer.Deserialize<List<Country>>(countriesJson);
            foreach (Country country in countries)
            {
                modelBuilder.Entity<Country>().HasData(country);
            }

            // Add Seed to Persons
            string personsJson = File.ReadAllText("persons.json");
            List<Person> persons = JsonSerializer.Deserialize<List<Person>>(personsJson);
            foreach (Person person in persons)
            {
                modelBuilder.Entity<Person>().HasData(person);
            }

            // Fluent API
            // Add column changes
            modelBuilder.Entity<Person>().Property(temp => temp.TIN)
                .HasColumnName("TaxIdentificationNumber")
                .HasColumnType("varchar(8)")
                .HasDefaultValue("ABC12345");

            // dont allow duplicate values
            //modelBuilder.Entity<Person>().HasIndex(temp => temp.TIN).IsUnique();

            // customize table structure
            modelBuilder.Entity<Person>()
                .HasCheckConstraint("CHK_TIN", "len([TaxIdentificationNumber]) = 8");

            // Table Relations
            // It is not required to declare it explicitly
            // Common practice is to declare on the model
            //modelBuilder.Entity<Person>(entity =>
            //{
            //    entity.HasOne<Country>(c => c.Country)
            //    .WithMany(p => p.Persons)
            //    .HasForeignKey(persons => persons.CountryID);
            //});
        }

        // calling Stored Procedure
        public List<Person> sp_GetAllPersons()
        {
            return Persons.FromSqlRaw("EXECUTE [dbo].[GetAllPersons]").ToList();
        }

        // calling Stored Procedure
        public int sp_InsertPerson(Person person)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@PersonID", person.PersonID),
                new SqlParameter("@PersonName", person.PersonName),
                new SqlParameter("@Email", person.Email),
                new SqlParameter("@DateOfBirth", person.DateOfBirth),
                new SqlParameter("@Gender", person.Gender),
                new SqlParameter("@CountryID", person.CountryID),
                new SqlParameter("@Address", person.Address),
                new SqlParameter("@ReceiveNewsLetters", person.ReceiveNewsLetters)
            };

            return Database.ExecuteSqlRaw("EXECUTE [dbo].[InsertPerson] @PersonID, @PersonName, @Email, @DateOfBirth, @Gender, @CountryID, @Address, @ReceiveNewsLetters", parameters);
        }
    }
}
