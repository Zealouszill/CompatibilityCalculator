

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

        }


        public MainViewModel Main { get; }

        //public MainViewModel Main { get; } = new MainViewModel(testRepo);

    }
}
