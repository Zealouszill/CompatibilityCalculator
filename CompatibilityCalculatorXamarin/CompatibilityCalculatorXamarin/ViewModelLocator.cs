using CompatibilityCalculatorDatabase;
using CompatibilityCalculatorLogic;
using CompatibilityCalculatorTypes;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Input;
using Xamarin.Forms;

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
