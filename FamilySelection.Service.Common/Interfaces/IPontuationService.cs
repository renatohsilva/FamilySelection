﻿using FamilySelection.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamilySelection.Service.Common.Interfaces
{
    public interface IPontuationService
    {
        public int GetPontuation(Family family);
    }
}
