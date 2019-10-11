/* Author: Spencer Stewart
 * Last Updated: 10/11/2019
 * Project: CompatibilityCalculator
 *
 * Description:
 * 
 * This class connects the view with the ViewModel.
 * 
 * It will create an instance of the ViewModel and it will be
 * referenced for the data input. 
 * 
 */

using CompatibilityCalculatorDatabase;
using CompatibilityCalculatorLogic;
using CompatibilityCalculatorTypes;

namespace CompatibilityCalculatorXamarin
{
    public class ViewModelLocator
    {
        // Create out MainViewModel
        public MainViewModel Main { get; }

        public ViewModelLocator()
        {
            // Set up a new variables to instantiate our main view model.
            IDataStorage testStorage = new SqliteDataStore();
            PotentialRepository testRepo = new PotentialRepository(testStorage);
            Main = new MainViewModel(testRepo);
        }
    }
}
