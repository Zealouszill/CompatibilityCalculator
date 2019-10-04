/* Author: Spencer Stewart
 * Last Updated: 10/4/2019
 * Project: CompatibilityCalculator
 *
 * Description:
 * 
 * This class connects the view with the ViewModel.
 * 
 * It will create an instance of the ViewModel and it will be
 * referenced for the 
 * 
 */

using CompatibilityCalculatorDatabase;
using CompatibilityCalculatorLogic;
using CompatibilityCalculatorTypes;
using System.Diagnostics;

namespace CompatibilityCalculatorXamarin
{
    public class ViewModelLocator
    {
        //PotentialRepository testRepo;
        //public MainViewModel Main { get; } = new MainViewModel(testRepo);

        public ViewModelLocator()
        {
            IDataStorage testStorage = new SqliteDataStore();
            PotentialRepository testRepo = new PotentialRepository(testStorage);
            //BuildAvaloniaApp().Start<MainWindow>(() => new MainViewModel(testRepo));
            //Main = new MainViewModel(testRepo);
            Main = new MainViewModel(testRepo);

            Debug.WriteLine("This code segment was executed");
            
        }


        public MainViewModel Main { get; }

        //public MainViewModel Main { get; } = new MainViewModel(testRepo);

    }
}
