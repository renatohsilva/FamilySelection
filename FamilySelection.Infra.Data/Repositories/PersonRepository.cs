using FamilySelection.Domain.Entities;
using FamilySelection.Infra.Data.Context;
using FamilySelection.Infra.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamilySelection.Infra.Data.Repositories
{
    public class PersonRepository : GenericRepository<Person>, IPersonRepository
    {
        public PersonRepository(FamilySelectionDataContext dataContext) : base(dataContext)
        {
        }
    }
}
