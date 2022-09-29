using Autofac;

using EMarketMaker.Core.Repositories;
using EMarketMaker.Core.Services;
using EMarketMaker.Core.UnitOfWorks;
using EMarketMaker.Repository;
using EMarketMaker.Repository.Repositories;
using EMarketMaker.Repository.UnitOfWorks;
using EMarketMaker.Service.Mapping;
using EMarketMaker.Service.Services;
using System.Reflection;
using Module = Autofac.Module;

namespace EMarketMaker.Web.Modules
{
    public class RepoServiceModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterGeneric(typeof(GenericRepository<>)).As(typeof(IGenericRepository<>)).InstancePerLifetimeScope();
            builder.RegisterGeneric(typeof(Service<>)).As(typeof(IService<>)).InstancePerLifetimeScope();
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>();
            var apiAssembly = Assembly.GetExecutingAssembly();
            var repoAssembly = Assembly.GetAssembly(typeof(AppDbContext));
            var serviceAssembly = Assembly.GetAssembly(typeof(MapProfile));

            builder.RegisterAssemblyTypes(apiAssembly,repoAssembly,serviceAssembly).Where(x=>x.Name.EndsWith("Repository")).AsImplementedInterfaces().InstancePerLifetimeScope();
            builder.RegisterAssemblyTypes(apiAssembly,repoAssembly,serviceAssembly).Where(x=>x.Name.EndsWith("Service")).AsImplementedInterfaces().InstancePerLifetimeScope();
            // InstancePerLifetimeScope =>Scope (Core) 1 kere
            //InstancePerDependancy => Transit işlem için yeni dependance oluşturur

            //builder.RegisterType<ProductServiceWithCaching>().As<IProductService>();


        }
    }
}
