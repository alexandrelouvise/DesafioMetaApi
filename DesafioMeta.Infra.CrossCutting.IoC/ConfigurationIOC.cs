using Autofac;
using DesafioMetaAPI.Application.Interfaces;
using DesafioMetaAPI.Application.Services;
using DesafioMetaAPI.Domain.Interfaces.Repositories;
using DesafioMetaAPI.Domain.Interfaces.Services;
using DesafioMetaAPI.Domain.Services;
using DesafioMetaAPI.Infra.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioMeta.Infra.CrossCutting.IoC
{
    public class ConfigurationIOC
    {
        public static void Load(ContainerBuilder builder)
        {
            #region Registra IOC

            #region IOC Application
            builder.RegisterType<ContatoApplication>().As<IContatoApplication>();
            #endregion

            #region IOC Services
            builder.RegisterType<ContatoService>().As<IContatoService>();
            #endregion

            #region IOC Repositorys SQL
            builder.RegisterType<ContatoRepository>().As<IContatoRepository>();
            #endregion

            #endregion
        }

    }
}
