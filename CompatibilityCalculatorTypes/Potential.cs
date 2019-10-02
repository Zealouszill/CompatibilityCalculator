

namespace CompatibilityCalculatorTypes
{
    public class Potential
    {
        public Potential()
        {

        }

        public Potential(string firstName, string lastName, int age, int enjoysSportsRating, int frugalityRating,
            int physicallyActiveRating, int desireForKidsRating, int senseOfHumorRating, int drivenRating)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            EnjoysSportsRating = enjoysSportsRating;
            FrugalityRating = frugalityRating;
            PhysicallyActiveRating = physicallyActiveRating;
            DesireForKidsRating = desireForKidsRating;
            SenseOfHumorRating = senseOfHumorRating;
            DrivenRating = drivenRating;

        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public int EnjoysSportsRating { get; set; }
        public int FrugalityRating { get; set; }
        public int PhysicallyActiveRating { get; set; }
        public int DesireForKidsRating { get; set; }
        public int SenseOfHumorRating { get; set; }
        public int DrivenRating { get; set; }
    }
}
