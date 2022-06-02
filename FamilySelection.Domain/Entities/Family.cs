using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamilySelection.Domain.Entities
{
    public class Family : BaseEntity
    {
        [Required]
        public decimal Pontuation { get; set; }
    }
}
