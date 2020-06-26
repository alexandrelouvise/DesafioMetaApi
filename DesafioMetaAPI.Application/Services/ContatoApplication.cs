using AutoMapper;
using DesafioMetaAPI.Application.Interfaces;
using DesafioMetaAPI.Application.ViewModel;
using DesafioMetaAPI.Domain.Entities;
using DesafioMetaAPI.Domain.Interfaces.Services;
using DesafioMetaAPI.Domain.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesafioMetaAPI.Application.Services
{
    public class ContatoApplication : IContatoApplication
    {
        private readonly IContatoService _contatoService;
        private readonly IMapper _mapper;

        public ContatoApplication(IContatoService contatoService, IMapper mapper)
        {
            _contatoService = contatoService;
            _mapper = mapper;
        }

        public void Add(ContatoViewModel contato)
        {
            _contatoService.Add(_mapper.Map<Contato>(contato));
        }

        public IEnumerable<ContatoViewModel> GetAll(int page, int size)
        {
            var cliente = _mapper.Map<IList<ContatoViewModel>>(_contatoService.GetAll());
            
            return new Pagination<ContatoViewModel>(cliente.AsQueryable(), 0, size, page).Results;
        }

        public ContatoViewModel GetById(int id)
        {
            var cliente = _contatoService.GetById(id);
            return _mapper.Map<ContatoViewModel>(cliente);
        }

        public void Remove(ContatoViewModel contato)
        {
            _contatoService.Remove(_mapper.Map<Contato>(contato));
        }

        public void Update(ContatoViewModel contato)
        {
            _contatoService.Update(_mapper.Map<Contato>(contato));
        }
    }
}
