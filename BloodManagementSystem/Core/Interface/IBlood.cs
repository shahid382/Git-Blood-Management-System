using BloodManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace BloodManagementSystem.Core.Interface
{
    public interface IBlood
    {
        List<SchoolModel> DisplayAllDonars();
        SchoolModel AddDonar(SchoolModel schoolModel);
    }
}