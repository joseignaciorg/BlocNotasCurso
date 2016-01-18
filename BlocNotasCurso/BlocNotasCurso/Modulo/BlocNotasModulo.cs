using System;
using Autofac;
using BlocNotasCurso.Service;
using BlocNotasCurso.View;
using BlocNotasCurso.ViewModel;
using Xamarin.Forms;

namespace BlocNotasCurso.Modulo
{
    public class BlocNotasModulo:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ServicioDatosImpl>().As<IServicioDatos>().SingleInstance();

            builder.RegisterType<Login>();
            builder.RegisterType<Principal>();
            builder.RegisterType<Registro>();
            builder.RegisterType<LoginViewModel>();
            builder.RegisterType<PrincipalViewModel>();
            builder.RegisterType<RegistroViewModel>();

            //Registrar la instancia de una funcion que va a devolver una pagina
            builder.RegisterInstance<Func<Page>>(() =>
            {
                //saber que pagina está en primer plano (pagina principalen este momento) y le digo que me lo de como una pagina maestrodetalle
                var masterP = App.Current.MainPage as MasterDetailPage;
                //si no se puede convertir como masterdetailpage me das el mainpage
                var page = masterP != null ? masterP.Detail : App.Current.MainPage;
                //creo objeto navigation de tipo pagina
                var navigation = page as IPageContainer<Page>;
                //devuelvo la pagina actual o la maestra (le pregunto al objeto si es la pagina principal)
                return navigation != null ? navigation.CurrentPage : page;
            });
        }
         
    }
}