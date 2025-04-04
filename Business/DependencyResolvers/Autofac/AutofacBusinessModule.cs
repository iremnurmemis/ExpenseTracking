
using Autofac;
using Autofac.Extras.DynamicProxy;
using Castle.DynamicProxy;
using Core;
using Core.Interceptors.Utilities.Interceptors;
using DataAccess;
using Business;
using Business.Concrete;
using Business.Abstract;
using DataAccess.Concrete;
using DataAccess.Abstract;

namespace Business
{
    public class AutofacBusinessModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //builder.RegisterType<C>().As<ICarService>().SingleInstance();
            //builder.RegisterType<EfCarDal>().As<ICarDal>().SingleInstance();

            builder.RegisterType<CategoryManager>().As<ICategoryService>().SingleInstance();
            builder.RegisterType<EfCategoryDal>().As<ICategoryDal>().SingleInstance();

            builder.RegisterType<ExpenseManager>().As<IExpenseService>().SingleInstance();
            builder.RegisterType<EfExpenseDal>().As<IExpenseDal>().SingleInstance();

            builder.RegisterType<RevenueManager>().As<IRevenueService>().SingleInstance();
            builder.RegisterType<EfRevenueDal>().As<IRevenueDal>().SingleInstance();

            builder.RegisterType<UserManager>().As<IUserService>().SingleInstance();
            builder.RegisterType<EfUserDal>().As<IUserDal>().SingleInstance();

            builder.RegisterType<AuthManager>().As<IAuthService>().SingleInstance();
            builder.RegisterType<EfRefreshTokenDal>().As<IRefreshTokenDal>().SingleInstance();
            builder.RegisterType<FileHelperManager>().As<IFileHelper>().SingleInstance();
           

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces().EnableInterfaceInterceptors(new ProxyGenerationOptions()
            {
                Selector = new AspectInterceptorSelector()
            }).SingleInstance();
        }
    }
}
