using AutoMapper;
using Itau.Case.ClubesFutebol.Application.Views;
using Itau.Case.ClubesFutebol.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Itau.Case.ClubesFutebol.Application.Mappers
{
    public class ClubeMapping : Profile
    {
        public ClubeMapping()
        {
            CreateMap<ClubePostViewsModel, Clube>();            
        }
    }
}
