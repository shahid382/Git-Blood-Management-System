using BloodManagementSystem.Core.Interface;
using BloodManagementSystem.DataAccess;
using BloodManagementSystem.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BloodManagementSystem.Core.Repository
{
    public class Blood : IBlood
    {
        private readonly BloodDbContext _context;
        public Blood(BloodDbContext _context)
        {
            this._context = _context;
        }
        public List<SchoolModel> DisplayAllDonars()
        {
            try
            {
                var result = _context.schoolModel.ToList();
                return result;
            }
            catch (Exception ex) { throw ex; }
        }
        public SchoolModel AddDonar(SchoolModel schoolModel)
        {
            try
            {
                _context.schoolModel.AddAsync(schoolModel);
                _context.SaveChangesAsync();
                return schoolModel;
            }
            catch (Exception ex) { throw ex; }
        }
    }
}
