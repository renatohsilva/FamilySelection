using FamilySelection.Domain.Entities;
using FamilySelection.Service.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamilySelection.Service.Common.Services.PontuationRules
{
    public class Over3DependentsRule : IPontuationRule
    {
        public int GetPontuation(Family family)
        {
            try
            {
                IEnumerable<Person> people = family.People;
                var familyDependents = people.Count(item => item.Salary == 0 && item.Age <= 18);
                if (familyDependents >= 3)
                {
                    return 3;
                }
                return 0;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
