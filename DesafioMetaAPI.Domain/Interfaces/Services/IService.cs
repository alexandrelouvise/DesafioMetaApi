﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioMetaAPI.Domain.Interfaces.Services
{
    public interface IService<T> where T : class
    {
        void Add(T entity);

        T GetById(int id);

        IEnumerable<T> GetAll();

        void Update(T entity);

        void Remove(T entity);

        void Dispose();
    }
}
