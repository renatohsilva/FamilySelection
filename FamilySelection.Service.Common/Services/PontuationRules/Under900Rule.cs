using FamilySelection.Domain.Entities;
using FamilySelection.Service.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamilySelection.Service.Common.Services.PontuationRules
{
    public class Under900Rule : IPontuationRule
    {
        public int GetPontuation(Family family)
        {
            try
            {
                IEnumerable<Person> people = family.People;
                var familySalary = people.Sum(item => item.Salary);
                if (familySalary <= 900)
                {
                    return 5;
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
