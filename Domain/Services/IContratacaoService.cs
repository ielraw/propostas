﻿using Domain.Dto;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public interface IContratacaoService
    {
        Task<ContratacaoResponseDto> PostAsync(ContratacaoRequestDto model);
    }
}
