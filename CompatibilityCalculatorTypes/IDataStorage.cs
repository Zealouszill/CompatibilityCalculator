/* Author: Spencer Stewart
 * Last Updated: 10/11/2019
 * Project: CompatibilityCalculator
 *
 * Description:
 * 
 * This is the interface to supply the necessary functions to 
 * interact with the database.
 * 
 * You can add, or remove a potential from teh database.
 * 
 * You can also get the list of potentials stored in the database.
 * 
 */

using System.Collections.Generic;

namespace CompatibilityCalculatorTypes
{
    public interface IDataStorage
    {
        // Add or remove potential.
        void AddPotential(Potential p);
        void RemovePotentialById(int id);

        // Get list of potentials from database.
        IEnumerable<Potential> GetAllPotentials();   
    }
}
