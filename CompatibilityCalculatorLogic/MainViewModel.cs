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

        public ICommand addPotentialCommand;
        public ICommand userStatCommand;
        public ICommand resultsCommand;
        public ICommand removePotentialCommand;


        private readonly IDataStorage dataStorage;

        public MainViewModel()
        {
            TestString = "This word";

            ListOfAllPotentials = new ObservableCollection<Potential>(dataStorage.GetAllPotentials());
        }

        public MainViewModel(PotentialRepository potentialRepo)
        {

            this.potentialRepo = potentialRepo;

            //var p = dataStore.GetById(2);
            //Console.WriteLine(ListOfAllPotentials[0].FirstName);
            try
            {
                ListOfAllPotentials = new ObservableCollection<Potential>(this.potentialRepo.GetAllPotentials());
            }
            catch (Exception e)
            {

            }

            var temp = potentialRepo.GetUserStats();

            userFirstNameFunction = temp.FirstName;
            userLastNameFunction = temp.LastName;
            userAgeFunction = temp.Age;
            userEnjoysSportsRatingFunction = temp.EnjoysSportsRating;
            userFrugalityRatingFunction = temp.FrugalityRating;
            userPhysicallyActiveRatingFunction = temp.PhysicallyActiveRating;
            userDesireForKidsRatingFunction = temp.DesireForKidsRating;
            userSenseOfHumorRatingFunction = temp.SenseOfHumorRating;
            userDrivenRatingFunction = temp.DrivenRating;

        }


        public IDataStorage DataStore => dataStorage;

        private readonly PotentialRepository potentialRepo;

        private string TestString;
        public string testStringFunction
        {
            get { return TestString; }
            set { SetField(ref TestString, value); }
        }

        private Potential ReferencedPotential;
        public Potential referencedPotentialFunction
        {
            get
            {
                try
                {
                    compatibilityPercentageFunction = calculateCompatibilityPercentage();
                }
                catch
                {

                }

                return ReferencedPotential;
            }
            set { SetField(ref ReferencedPotential, value); }
        }

        public double calculateCompatibilityPercentage()
        {
            double difference = (Math.Abs(ReferencedPotential.EnjoysSportsRating - userEnjoysSportsRatingFunction) +
                Math.Abs(ReferencedPotential.FrugalityRating - userFrugalityRatingFunction) +
                Math.Abs(ReferencedPotential.PhysicallyActiveRating - userPhysicallyActiveRatingFunction) +
                Math.Abs(ReferencedPotential.DesireForKidsRating - userDesireForKidsRatingFunction) +
                Math.Abs(ReferencedPotential.SenseOfHumorRating - userSenseOfHumorRatingFunction) +
                Math.Abs(ReferencedPotential.DrivenRating - UserDrivenRating));

            double percentage = Math.Abs(Math.Round((difference / 54) * 100, 2) - 100);

            return percentage;
        }

        public ICommand AddPotentialCommand => addPotentialCommand ?? (addPotentialCommand = new SimpleCommand(
            () =>
            {
                return true;
            },
            () =>
            {
                //Potential test = new Potential();

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

                potentialRepo.AddPotential(tempPot);
                ListOfAllPotentials.Add(tempPot);

                //Potentials.Clear();
                //foreach (var c in potentialRepo.GetAllPotentials())
                //    Potentials.Add(c);
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

        public ICommand UserStatCommand => userStatCommand ?? (userStatCommand = new SimpleCommand(
            () =>
            {

                potentialRepo.ChangeUserStats(new UserProfileStats(
                    userFirstNameFunction,
                    userLastNameFunction,
                    userAgeFunction,
                    userEnjoysSportsRatingFunction,
                    userFrugalityRatingFunction,
                    userPhysicallyActiveRatingFunction,
                    userDesireForKidsRatingFunction,
                    userSenseOfHumorRatingFunction,
                    userDrivenRatingFunction
                    ));

            }));

        //potentialRepo.AddUserProfile(new UserProfileStats(
        //userFirstNameFunction,
        //    userLastNameFunction,
        //    userAgeFunction,
        //    userEnjoysSportsRatingFunction,
        //    userFrugalityRatingFunction,
        //    userPhysicallyActiveRatingFunction,
        //    userDesireForKidsRatingFunction,
        //    userSenseOfHumorRatingFunction,
        //    userDrivenRatingFunction));

        //Potentials.Clear();
        //foreach (var c in potentialRepo.GetAllPotentials())
        //    Potentials.Add(c);
        //FirstName = null;

        /*  
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            EnjoysSportsRating = enjoysSportsRating;
            FrugalityRating = frugalityRating;
            PhysicallyActiveRating = physicallyActiveRating;
            DesireForKidsRating = desireForKidsRating;
            SenseOfHumorRating = senseOfHumorRating;
            DrivenRating = drivenRating;
         */



        public ICommand GetDBResults => resultsCommand ?? (resultsCommand = new SimpleCommand(
            () =>
            {
                Potential tempPotential = potentialRepo.GetASpecificId(IdSelection);

                firstNameResultsFunction = tempPotential.FirstName;
                lastNameResultsFunction = tempPotential.LastName;
                ageResultsFunction = tempPotential.Age;
                enjoysSportsRatingResultsFunction = tempPotential.EnjoysSportsRating;
                frugalityResultsFunction = tempPotential.EnjoysSportsRating;
                desireForKidsRatingResultsFunction = tempPotential.DesireForKidsRating;
                senseOfHumorRatingResultsFunction = tempPotential.SenseOfHumorRating;
                drivenRatingResultsFunction = tempPotential.DrivenRating;


                //firstNameResultsFunction = potentialRepo.GetASpecificId(IdSelection).FirstName;

                //FirstName = firstName;
                //LastName = lastName;
                //Age = age;
                //PersonalityRating = personalityRating;
                //EnjoysSports = enjoysSports;
            }));



        public ICommand RemovePotentialCommand => removePotentialCommand ?? (removePotentialCommand = new SimpleCommand(
            () =>
            {
                try
                {
                    potentialRepo.RemovePotentialById(selectedItemFunction.Id);
                    ListOfAllPotentials.Remove(selectedItemFunction);
                }
                catch (Exception e)
                {
                    Debug.WriteLine("We were unable to delete item from database.");
                    Debug.WriteLine(e);
                }
            }));



        //public ICommand AddPotentialCommand => addPotentialCommand ?? (addPotentialCommand = new SimpleCommand(() => ChildControlViewModel = new AddCardViewModel(cardRepo)));
        //public ICommand AddPotentialCommand => addPotentialCommand ?? (addPotentialCommand = new SimpleCommand(() => ChildControlViewModel = new AddPotentialViewModel(potentialRepo)));

        //public object ChildControlViewModel { get; set; }

        public ObservableCollection<Potential> ListOfAllPotentials { get; private set; }

        /* Compatibility Percentage */

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

        /* Display Database Input Values Code block: */

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

        /* End Display Database Values Code Block 
         * Add and remove Functionality Code block: */

        private int IdSelection;
        public int idSelectionFunction
        {
            get { return IdSelection; }
            set { SetField(ref IdSelection, value); }
        }

        private int RemovePotentialID;
        public int removePotentialIDFunction
        {
            get { return RemovePotentialID; }
            set { SetField(ref RemovePotentialID, value); }
        }

        /* End Add and remove Functionality Code block
         * Show results Code block: */

        private string FirstNameResults;
        public string firstNameResultsFunction
        {
            get { return FirstNameResults; }
            set { SetField(ref FirstNameResults, value); }
        }

        private string LastNameResults;
        public string lastNameResultsFunction
        {
            get { return LastNameResults; }
            set { SetField(ref LastNameResults, value); }
        }

        private int AgeResults;
        public int ageResultsFunction
        {
            get { return AgeResults; }
            set { SetField(ref AgeResults, value); }
        }

        private int EnjoysSportsRatingResults;
        public int enjoysSportsRatingResultsFunction
        {
            get { return EnjoysSportsRatingResults; }
            set { SetField(ref EnjoysSportsRatingResults, value); }
        }

        private int FrugalityRatingResults;
        public int frugalityResultsFunction
        {
            get { return FrugalityRatingResults; }
            set { SetField(ref FrugalityRatingResults, value); }
        }

        private int PhysicallyActiceRatingResults;
        public int physicallyActiveResultsFunction
        {
            get { return PhysicallyActiceRatingResults; }
            set { SetField(ref PhysicallyActiceRatingResults, value); }
        }

        private int DesireForKidsRatingResults;
        public int desireForKidsRatingResultsFunction
        {
            get { return DesireForKidsRatingResults; }
            set { SetField(ref DesireForKidsRatingResults, value); }
        }

        private int PotentialSenseOfHumorRatingResults;
        public int senseOfHumorRatingResultsFunction
        {
            get { return PotentialSenseOfHumorRatingResults; }
            set { SetField(ref PotentialSenseOfHumorRatingResults, value); }
        }

        private int DrivenRatingResults;
        public int drivenRatingResultsFunction
        {
            get { return DrivenRatingResults; }
            set { SetField(ref DrivenRatingResults, value); }
        }

        /* End  Show results Code block
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

        /*  
         *  Id = id;
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            EnjoysSportsRating = enjoysSportsRating;
            FrugalityRating = frugalityRating;
            PhysicallyActiveRating = physicallyActiveRating;
            DesireForKidsRating = desireForKidsRating;
            SenseOfHumorRating = senseOfHumorRating;
            DrivenRating = drivenRating;
         */

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
