using DesafioMetaAPI.Application.ViewModel;
using DesafioMetaAPI.Domain.Pagination;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioMetaAPI.Application.Interfaces
{
    public interface IContatoApplication
    {
        void Add(ContatoViewModel contato);

        ContatoViewModel GetById(int id);

        IEnumerable<ContatoViewModel> GetAll(int page, int size);

        void Update(ContatoViewModel contato);

        void Remove(ContatoViewModel contato);

    }
}
