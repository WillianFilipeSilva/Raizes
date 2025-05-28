using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Raizes.Domain.Entities;

namespace Raizes.Application.Interfaces
{
    public interface IPropriedadeRepository
    {
        Task AddAsync(Propriedade prop);
    }
}
