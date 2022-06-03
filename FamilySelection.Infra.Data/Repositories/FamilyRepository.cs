using FamilySelection.Domain.Entities;
using FamilySelection.Infra.Data.Context;
using FamilySelection.Infra.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamilySelection.Infra.Data.Repositories
{
    public class FamilyRepository : GenericRepository<Family>, IFamilyRepository
    {
        public FamilyRepository(FamilySelectionDataContext dataContext) : base(dataContext)
        {
        }

        public async Task<IEnumerable<Family>> GetAllPeople()
        {
            return await GetDataContext().Set<Family>().AsNoTracking().Include(item => item.People).ToListAsync();
        }
    }
}
