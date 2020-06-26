using DesafioMetaAPI.Domain.Interfaces.Repositories;
using DesafioMetaAPI.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioMetaAPI.Domain.Services
{
    public class Service<T> : IDisposable, IService<T> where T : class
    {
        private readonly IRepository<T> _repository;
        public Service(IRepository<T> repository)
        {
            _repository = repository;
        }
        public void Add(T entity)
        {
            _repository.Add(entity);
        }

        public IEnumerable<T> GetAll()
        {
            return _repository.GetAll();
        }

        public T GetById(int id)
        {
            return _repository.GetById(id);
        }

        public void Remove(T entity)
        {
            _repository.Remove(entity);
        }

        public void Update(T entity)
        {
            _repository.Update(entity);
        }

        public void Dispose()
        {
            _repository.Dispose();
        }
    }
}
