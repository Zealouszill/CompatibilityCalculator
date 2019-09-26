using System.Collections.Generic;

namespace CompatibilityCalculatorTypes
{
    public class IDataStorage
    {
        void AddPotential(Potential p);
        void AddUserStats(UserProfileStats u);
        IEnumerable<Potential> GetAllPotentials();
        Potential GetPotentialById(int id);
        UserProfileStats GetUserStats();
        void ChangeUserStats(UserProfileStats u);
        string RemovePotentialById(int id);
    }
}
