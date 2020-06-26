using DesafioMetaAPI.Domain.Entities;
using DesafioMetaAPI.Domain.Interfaces.Repositories;
using DesafioMetaAPI.Infra.Data.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DesafioMetaAPI.Domain.Pagination;

namespace DesafioMetaAPI.Infra.Data.Repositories
{
    public class ContatoRepository: Repository<Contato>, IContatoRepository
    {
        private readonly DesafioMetaAPIDbContext _context;
        public ContatoRepository(DesafioMetaAPIDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
