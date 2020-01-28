using Banco.API.Domain.Clientes;
using Banco.API.Domain.Contas;
using Banco.API.Repository;
using Banco.API.Repository.Infra;
using SimpleInjector;
using SimpleInjector.Lifestyles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Banco.API.API.App_Start
{
    public class SimpleInjectorContainer
    {
        private static readonly Container container = new Container();

        public static Container Build()
        {
            container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();

            //container.Register<INotification, Notification>(Lifestyle.Scoped);

            RegisterRepositories();
            RegisterServices();

            container.Verify();
            return container;
        }

        private static void RegisterRepositories()
        {
            container.Register<IClientesRepository, ClientesRepository>();
            container.Register<IContasRepository, ContasRepository>();
            container.Register<IConexaoRepository, ConexaoRepository>();
        }

        private static void RegisterServices()
        {
        }
    }
}