using Autofac;
using BlocNotasCurso.Factorias;

namespace BlocNotasCurso.Modulo
{
    public abstract class AutofacBootstrapper// clase que va a arrancar la aplicacion 
    {
        public void Run()
        {
            var builder=new ContainerBuilder();// containerbuilder se encarga de generar el contenedor de inyeccion de dependencias
            ConfigureContainer(builder);//configuro el contenedor
            var cont = builder.Build();//guardo el contenedor
            var viewFactory = cont.Resolve<IViewFactory>();//guardo la factoria de vistas
            RegisterViews(viewFactory);//te doy la factoria de vistas para que me relaciones las vistas
            ConfigureApplication(cont);//configuro la aplicacion como inicializar la aplicación
        }

        public virtual void ConfigureContainer(ContainerBuilder builder)//se encarga de configurar el contenedor
        {
            builder.RegisterModule<AutofacModule>();
        }

        protected abstract void RegisterViews(IViewFactory viewFactory);
        protected abstract void ConfigureApplication(IContainer container);
    }
}