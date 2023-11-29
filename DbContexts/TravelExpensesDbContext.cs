using Microsoft.EntityFrameworkCore;
using PracticalLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Student Name: Jadepat Chernsonthi
 * Student Number: 041074866
 * Student Email: cher0151@algonquinlive.com
 * Course & Section #: 23F_CST8333_370
 */
namespace PracticalLib.MyDbContexts
{
    /// <summary>
    /// Represents the database context for managing travel expenses.
    /// </summary>
    public class TravelExpensesDbContext : DbContext
    {
        /// <summary>
        /// Gets or sets the set of travel expenses entities in the database.
        /// </summary>
        public DbSet<TravelExpensesEntity> TravelExpenses { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="TravelExpensesDbContext"/> class.
        /// </summary>
        public TravelExpensesDbContext() : base() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="TravelExpensesDbContext"/> class with the specified options.
        /// </summary>
        /// <param name="options">The options for configuring the database context.</param>
        public TravelExpensesDbContext(DbContextOptions<TravelExpensesDbContext> options)
            : base(options) { }

        /// <summary>
        /// Configures the database context options during the initialization.
        /// </summary>
        /// <param name="optionsBuilder">The options builder used to configure the database context.</param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //Azure database
                //optionsBuilder.UseSqlServer(@"Server=tcp:jadepat-personal.database.windows.net,1433;Initial Catalog=personal;Persist Security Info=False;User ID=practicalProjectClient;Password=client_Login1;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=360;", //มีการแก้ MultipleActiveResultSets=false เป็น true
                //options => options.EnableRetryOnFailure());

                //localhost
                optionsBuilder.UseSqlServer(@"Server=localhost;Database=personal;User ID=practicalProjectClient;Password=client_Login1;Encrypt=True;TrustServerCertificate=True;", //มีการแก้ MultipleActiveResultSets=false เป็น true
                options => options.EnableRetryOnFailure());
            }
        }
    }
}
