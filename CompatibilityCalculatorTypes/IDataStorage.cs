/* Author: Spencer Stewart
 * Last Updated: 10/11/2019
 * Project: CompatibilityCalculator
 *
 * Description:
 * 
 * 
 * 
 */

using System.Collections.Generic;

namespace CompatibilityCalculatorTypes
{
    public interface IDataStorage
    {
        void AddPotential(Potential p);
        IEnumerable<Potential> GetAllPotentials();
        void  RemovePotentialById(int id);
    }
}
