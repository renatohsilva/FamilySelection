using FamilySelection.Domain.Entities;
using FamilySelection.Service.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamilySelection.Service.Common.Services
{
    public class PontuationService : IPontuationService
    {
        private readonly IEnumerable<IPontuationRule> pontuationRules;

        public PontuationService(IEnumerable<IPontuationRule> pontuationRules)
        {
            this.pontuationRules = pontuationRules;
        }

        public int GetPontuation(Family family)
        {
            int pontuation = 0;
            foreach (var pontuationRule in pontuationRules)
            {
                pontuation += pontuationRule.GetPontuation(family);
            }
            return pontuation;
        }
    }
}
