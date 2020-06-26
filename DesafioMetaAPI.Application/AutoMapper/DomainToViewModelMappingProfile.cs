using AutoMapper;
using DesafioMetaAPI.Application.ViewModel;
using DesafioMetaAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioMetaAPI.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Contato, ContatoViewModel>();
        }
    }
}
