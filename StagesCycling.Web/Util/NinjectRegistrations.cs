namespace StagesCycling.Web.Util
{
    using Ninject.Modules;
    using Ninject.Extensions.Factory;

    using StagesCycling.DAL;
    using AutoMapper;
    using BLL.Services;
    using StagesCycling.DAL.Context;
    using StagesCycling.BLL.Services.Interfaces;

    public class NinjectRegistrations : NinjectModule
    {
        public override void Load()
        {
            //var mapper = MappingProfile.InitializeAutoMapper().CreateMapper();
            //Bind<IMapper>().ToConstant(mapper);

            Bind<IRepositoryFactory>().ToFactory();
            Bind<ApplicationDbContext>().ToSelf();

            Bind(typeof(IGenericRepository<>)).To(typeof(GenericRepository<>));
            Bind<IUnitOfWork>().To<UnitOfWork>();

            Bind<IAdminService>().To<AdminService>();
            Bind<IUpdateService>().To<UpdateService>();
            Bind<IDetailsService>().To<DetailsService>();
            Bind<IAccessoriesService>().To<AccessoriesService>();
            Bind<IOrderService>().To<OrderService>();
            Bind<IConfigurationService>().To<ConfigurationService>();
        }
    }
}