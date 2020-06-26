using DesafioMetaAPI.Domain.Entities;
using DesafioMetaAPI.Domain.Interfaces.Repositories;
using DesafioMetaAPI.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioMetaAPI.Domain.Services
{
    public class ContatoService : Service<Contato>,IContatoService
    {
        public readonly IContatoRepository _contatoRepository;
        public ContatoService(IContatoRepository contatoRepository) : base(contatoRepository)
        {
            _contatoRepository = contatoRepository;
        }
    }
}
