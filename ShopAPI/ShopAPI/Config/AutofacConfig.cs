using Autofac;
using Shop.Business.Manager;
using Shop.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.API.Config
{
    public class AutofacConfig : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CustomerManager>().SingleInstance();
            builder.RegisterType<CustomerRepository>().SingleInstance();

            builder.RegisterType<OrderManager>().SingleInstance();
            builder.RegisterType<OrderRepository>().SingleInstance();

            builder.RegisterType<ProductManager>().SingleInstance();
            builder.RegisterType<ProductRepository>().SingleInstance();
            //builder.RegisterType<AuthManager>().SingleInstance();
            //builder.RegisterType<LeadManager>().As<ILeadManager>().SingleInstance();
            //builder.RegisterType<TokenService>().SingleInstance();
        }
    }
}
