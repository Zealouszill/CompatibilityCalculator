/* Author: Spencer Stewart
 * Last Updated: 10/11/2019
 * Project: CompatibilityCalculator
 *
 * Description:
 * 
 * This class holds the methods, functions and variables to
 * interact with the database.
 * 
 * It will create the database if one doesn't exist.
 * 
 * It can add or remove a potential to the database.
 * 
 * It can also return all potentials currently stored in the database.
 * 
 */

using CompatibilityCalculatorTypes;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace CompatibilityCalculatorDatabase
{
    public class SqliteDataStore : IDataStorage
    {
        // Create a context in our scope.
        private readonly PotentialGirlfriendsContext context;

        // Default Constructor.
        public SqliteDataStore()
        {
            // Instantiate our defined context.
            context = new PotentialGirlfriendsContext();
        }

        // This will add the referenced potential to the database.
        public void AddPotential(Potential p)
        {
            // Add the potential to the database.
            context.Potentials.Add(p);
            
            // Save the changes.
            context.SaveChanges();
        }

        // This will get and return the list of potentials from the database.
        public IEnumerable<Potential> GetAllPotentials()
        {
            return context.Potentials;
        }

        // This will remove a potential in the database with the given ID.
        public void RemovePotentialById(int id)
        {
            // Find the potential in the database and remove it.
            context.Potentials.Remove(context.Potentials.Find(id));

            // Save the change to the database.
            context.SaveChanges();
        }
    }

    // This class holds the context for our database.
    public class PotentialGirlfriendsContext : DbContext
    {
        // bool to tell if our database is created yet.
        private static bool _created = false;

        // Default Constructor.
        public PotentialGirlfriendsContext()
        {
            // If the database isn't created, create it.
            if (!_created)
            {
                _created = true;

                // Delete the database if we need to.
                //Database.EnsureDeleted();

                // Create the database.
                Database.EnsureCreated();
            }
        }

        // This will set the location of the database and name it.
        protected override void OnConfiguring(DbContextOptionsBuilder optionbuilder)
        {
            optionbuilder.UseSqlite($@"Data Source=Sample.db");
        }

        // This will hold the values for all our potentials.
        public DbSet<Potential> Potentials { get; set; }
    }
}
