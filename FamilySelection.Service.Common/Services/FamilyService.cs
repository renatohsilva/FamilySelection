using FamilySelection.Domain.DTOs;
using FamilySelection.Domain.Entities;
using FamilySelection.Infra.Data.Interfaces;
using FamilySelection.Service.Common.Interfaces;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamilySelection.Service.Common.Services
{
    public class FamilyService : GenericService<Family>, IFamilyService
    {
        private readonly IPontuationService pontuationService;
        private readonly IValidator<Family> validatorFamily;
        public FamilyService(IPontuationService pontuationService, IFamilyRepository personRepository, IValidator<Family> validatorFamily) : base(personRepository)
        {
            this.pontuationService = pontuationService;
            this.validatorFamily = validatorFamily;
        }

        public async Task<IEnumerable<FamilyDto>> LoadFamiliesDtoByPontuation()
        {
            IEnumerable<FamilyDto> familyDtos = await CreateFamiliesDtoByPontuation();
            return familyDtos.OrderByDescending(item => item.Pontuation);
        }

        private async Task<IEnumerable<FamilyDto>> CreateFamiliesDtoByPontuation()
        {
            IFamilyRepository veiculoRepository = (IFamilyRepository)GetRepository();
            IEnumerable<Family> families = await veiculoRepository.GetAllPeople();

            var familiesDto = new List<FamilyDto>();
            foreach (var family in families)
            {
                familiesDto.Add(new FamilyDto
                {
                    Code = family.Code,
                    Description = family.Description,
                    Pontuation= pontuationService.GetPontuation(family)
                });
            }

            return familiesDto;
        }

        public override void Consistency(Family entity)
        {
            validatorFamily.ValidateAndThrow(entity);
        }
    }
}
