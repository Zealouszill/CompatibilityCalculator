/* Author: Spencer Stewart
 * Last Updated: 10/11/2019
 * Project: CompatibilityCalculator
 *
 * Description:
 * 
 * This class holds the methods to call the functions in the
 * SqliteDataStore class.
 * 
 * Results will either remove, or add potentials from or to the
 * database.
 * 
 */

using System;
using System.Collections.Generic;

namespace CompatibilityCalculatorTypes
{
    public class PotentialRepository
    {
        // Create an interface to be used.
        private readonly IDataStorage dataStore;

        // This will set the context for our database we are using.
        public PotentialRepository(IDataStorage dataStore)
        {
            this.dataStore = dataStore ?? throw new ArgumentNullException(nameof(dataStore));
        }

        // This function will attempt to add a potential to the database.
        public bool AddPotential(Potential p)
        {
            // This will attempt to add the referenced
            // Potential to the database. Throw an exception
            // If it is unsccessful.
            try
            {
                dataStore.AddPotential(p);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Unable to add a potential to the database.");
                Console.WriteLine("Exception Message: " + e.Message);
                return false;
            }
        }

        // This function will get and return all of the potentials in the database.
        public IEnumerable<Potential> GetAllPotentials()
        {
            return dataStore.GetAllPotentials();
        }

        // This method will remove a potential from the database given the selected
        // ID from the user.
        public void RemovePotentialById(int id)
        {
            dataStore.RemovePotentialById(id);
        }
    }
}
