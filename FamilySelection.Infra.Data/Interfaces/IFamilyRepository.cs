using FamilySelection.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamilySelection.Infra.Data.Interfaces
{
    public interface IFamilyRepository : IGenericRepository<Family>
    {
        public Task<IEnumerable<Family>> GetAllPeople();
    }
}
