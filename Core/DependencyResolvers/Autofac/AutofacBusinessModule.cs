
using Autofac;
using Autofac.Extras.DynamicProxy;
using Castle.DynamicProxy;
using Core;
using Core.Interceptors.Utilities.Interceptors;
using DataAccess;

namespace Business
{
    public class AutofacBusinessModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //builder.RegisterType<C>().As<ICarService>().SingleInstance();
            //builder.RegisterType<EfCarDal>().As<ICarDal>().SingleInstance();

            builder.RegisterType<FileHelperManager>().As<IFileHelper>().SingleInstance();
           

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces().EnableInterfaceInterceptors(new ProxyGenerationOptions()
            {
                Selector = new AspectInterceptorSelector()
            }).SingleInstance();
        }
    }
}
