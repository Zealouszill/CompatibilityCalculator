/* Author: Spencer Stewart
 * Last Updated: 10/11/2019
 * Project: CompatibilityCalculator
 *
 * Description:
 * 
 * This is the MainViewModel for the Compatibility Calculator project.
 * 
 * This will take data for various fields from the view. It also has the
 * potential to run different commands. Such as inserting data into the 
 * database, and removing data from the database.
 * 
 */

using CompatibilityCalculatorTypes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace CompatibilityCalculatorLogic
{
    public class MainViewModel : INotifyPropertyChanged
    {

        // ICommands for the different commands from the View.
        public ICommand addPotentialCommand;
        public ICommand calcCompStats;
        public ICommand removePotentialCommand;

        // Collection of all potentials we have stored.
        public ObservableCollection<Potential> ListOfAllPotentials { get; private set; }

        // Create our Repository.
        private readonly PotentialRepository potentialRepo;

        // Defautl Constructor.
        public MainViewModel() { }

        // Constructor to set up our list of Potentials saved in
        // the Database.
        public MainViewModel(PotentialRepository potentialRepo)
        {
            // Set the class potentialRepo, to the one we want passed in.
            this.potentialRepo = potentialRepo;

            // Get list of potentials from the Database. Otherwise, throw an exception.
            try
            {
                ListOfAllPotentials = new ObservableCollection<Potential>(this.potentialRepo.GetAllPotentials());
            }
            catch (Exception e)
            {
                Console.WriteLine("Was unsuccessful in attempted to get Potentials from Database.");
                Console.WriteLine("Exception Message: " + e.Message);
            }
        }

        // This method will calculate the percentage between the user and the potential
        // that they have selected.
        public void calculateCompatibilityPercentage()
        {
            // This will calculator the percentage in each category of the stats.
            // It will then calcalate the compatibility percentage for the user.
            try
            {
                double difference = (Math.Abs(selectedItemFunction.EnjoysSportsRating - userEnjoysSportsRatingFunction) +
                Math.Abs(selectedItemFunction.FrugalityRating - userFrugalityRatingFunction) +
                Math.Abs(selectedItemFunction.PhysicallyActiveRating - userPhysicallyActiveRatingFunction) +
                Math.Abs(selectedItemFunction.DesireForKidsRating - userDesireForKidsRatingFunction) +
                Math.Abs(selectedItemFunction.SenseOfHumorRating - userSenseOfHumorRatingFunction) +
                Math.Abs(selectedItemFunction.DrivenRating - UserDrivenRating));

                compatibilityPercentageFunction = Math.Abs(Math.Round((difference / 54) * 100, 2) - 100);

            } 
            catch (Exception e)
            {
                Debug.WriteLine("Exception thrown. User did not select a potential on the list.");
                Debug.WriteLine(e.Message);
            }
        }

        // This command will take the values from the view and create a new potential from it.
        // It will then call the necessary commands to save the data into the database.
        public ICommand AddPotentialCommand => addPotentialCommand ?? (addPotentialCommand = new SimpleCommand(
            () =>
            {
                return true;
            },
            () =>
            {
                // Create a new potential for this scope's reference.
                Potential tempPot = new Potential(
                    firstNameFunction,
                    lastNameFunction,
                    ageFunction,
                    enjoysSportsRatingFunction,
                    frugalityRatingFunction,
                    physicallyActiveRatingFunction,
                    desireForKidsRatingFunction,
                    senseOfHumorRatingFunction,
                    drivenRatingFunction
                    );

                // Add the potential to the database. Then add it to our observable collection
                // For display.
                potentialRepo.AddPotential(tempPot);
                ListOfAllPotentials.Add(tempPot);

                // Reset the view values back to empty.
                firstNameFunction = null;
                lastNameFunction = null;
                ageFunction = 0;
                enjoysSportsRatingFunction = 0;
                frugalityRatingFunction = 0;
                physicallyActiveRatingFunction = 0;
                desireForKidsRatingFunction = 0;
                senseOfHumorRatingFunction = 0;
                drivenRatingFunction = 0;
            }));

        // This command will call the calculateCompatibilityPercentage method.
        public ICommand CalcCompStats => calcCompStats ?? (calcCompStats = new SimpleCommand(
            () =>
            {
                calculateCompatibilityPercentage();
            }));

        // This command will call the needed methods to find the desired potential in the database.
        // and have it removed.
        public ICommand RemovePotentialCommand => removePotentialCommand ?? (removePotentialCommand = new SimpleCommand(
            () =>
            {
                // Try to remove the potential if it is found in the database.
                // Otherwise throw an exception.
                try
                {
                    potentialRepo.RemovePotentialById(selectedItemFunction.Id);
                    ListOfAllPotentials.Remove(selectedItemFunction);
                }
                catch (Exception e)
                {
                    Debug.WriteLine("Could not delete item from database.");
                    Debug.WriteLine(e);
                }
            }));

        /* ***Compatibility Percentage***
         * These functions are needed to calculate the percentage of the
         * user and the selected potential.
         */

        private Potential SelectedItem;
        public Potential selectedItemFunction
        {
            get { return SelectedItem; }
            set { SetField(ref SelectedItem, value); }
        }

        private double CompatibilityPercentage;
        public double compatibilityPercentageFunction
        {
            get { return CompatibilityPercentage; }
            set { SetField(ref CompatibilityPercentage, value); }
        }

        /* Display Database Input Values Code block for potential girlfriend: */

        private string PotentialFirstName;
        public string firstNameFunction
        {
            get { return PotentialFirstName; }
            set { SetField(ref PotentialFirstName, value); }
        }

        private string PotentialLastName;
        public string lastNameFunction
        {
            get { return PotentialLastName; }
            set { SetField(ref PotentialLastName, value); }
        }

        private int PotentialAge;
        public int ageFunction
        {
            get { return PotentialAge; }
            set { SetField(ref PotentialAge, value); }
        }

        private int PotentialEnjoysSportsRating;
        public int enjoysSportsRatingFunction
        {
            get { return PotentialEnjoysSportsRating; }
            set { SetField(ref PotentialEnjoysSportsRating, value); }
        }

        private int PotentialFrugalityRating;
        public int frugalityRatingFunction
        {
            get { return PotentialFrugalityRating; }
            set { SetField(ref PotentialFrugalityRating, value); }
        }

        private int PotentialPhysicallyActiceRating;
        public int physicallyActiveRatingFunction
        {
            get { return PotentialPhysicallyActiceRating; }
            set { SetField(ref PotentialPhysicallyActiceRating, value); }
        }

        private int PotentialDesireForKidsRating;
        public int desireForKidsRatingFunction
        {
            get { return PotentialDesireForKidsRating; }
            set { SetField(ref PotentialDesireForKidsRating, value); }
        }

        private int PotentialSenseOfHumorRating;
        public int senseOfHumorRatingFunction
        {
            get { return PotentialSenseOfHumorRating; }
            set { SetField(ref PotentialSenseOfHumorRating, value); }
        }

        private int PotentialDrivenRating;
        public int drivenRatingFunction
        {
            get { return PotentialDrivenRating; }
            set { SetField(ref PotentialDrivenRating, value); }
        }

        /* End Display Database Values Code Block.
         * 
         * Start of Compatability input code for user: */

        private string UserFirstName;
        public string userFirstNameFunction
        {
            get { return UserFirstName; }
            set { SetField(ref UserFirstName, value); }
        }

        private string UserLastName;
        public string userLastNameFunction
        {
            get { return UserLastName; }
            set { SetField(ref UserLastName, value); }
        }

        private int UserAge;
        public int userAgeFunction
        {
            get { return UserAge; }
            set { SetField(ref UserAge, value); }
        }

        private int UserEnjoysSportsRating;
        public int userEnjoysSportsRatingFunction
        {
            get { return UserEnjoysSportsRating; }
            set { SetField(ref UserEnjoysSportsRating, value); }
        }

        private int UserFrugalityRating;
        public int userFrugalityRatingFunction
        {
            get { return UserFrugalityRating; }
            set { SetField(ref UserFrugalityRating, value); }
        }

        private int UserPhysicallyActiveRating;
        public int userPhysicallyActiveRatingFunction
        {
            get { return UserPhysicallyActiveRating; }
            set { SetField(ref UserPhysicallyActiveRating, value); }
        }

        private int UserDesireForKidsRating;
        public int userDesireForKidsRatingFunction
        {
            get { return UserDesireForKidsRating; }
            set { SetField(ref UserDesireForKidsRating, value); }
        }

        private int UserSenseOfHumorRating;
        public int userSenseOfHumorRatingFunction
        {
            get { return UserSenseOfHumorRating; }
            set { SetField(ref UserSenseOfHumorRating, value); }
        }

        private int UserDrivenRating;
        public int userDrivenRatingFunction
        {
            get { return UserDrivenRating; }
            set { SetField(ref UserDrivenRating, value); }
        }

        // These methods are used to change the property of variable,
        // if there is ever any data inputed into the control fields in the view.
        #region INotifyPropertyChanged Implementation
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected bool SetField<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, value))
                return false;
            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }
        #endregion
    }
}
