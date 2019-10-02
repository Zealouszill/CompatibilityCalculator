﻿using System.Collections.Generic;

namespace CompatibilityCalculatorTypes
{
    public interface IDataStorage
    {
        void AddPotential(Potential p);
        void AddUserStats(UserProfileStats u);
        IEnumerable<Potential> GetAllPotentials();
        Potential GetPotentialById(int id);
        UserProfileStats GetUserStats();
        void ChangeUserStats(UserProfileStats u);
        void  RemovePotentialById(int id);
    }
}
