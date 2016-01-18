using Autofac;
using BlocNotasCurso.Factorias;
using Xamarin.Forms;

namespace BlocNotasCurso.Modulo
{
    public class AutofacModule:Module 
    {
        protected override void Load(ContainerBuilder builder)
        {
            //registrame el tipo Viewfactory como un IviewFactory y le digo que sea una instancia unica (se que es un objeto unico en memoria)
            builder.RegisterType<ViewFactory>().As<IViewFactory>().SingleInstance();
            //registrame el navigator como un INavigator 
            builder.RegisterType<Navigator>().As<INavigator>().SingleInstance();
            //registrame el INavigation
            builder.Register<INavigation>(ctx => App.Current.MainPage.Navigation).SingleInstance();
        }
    }
}