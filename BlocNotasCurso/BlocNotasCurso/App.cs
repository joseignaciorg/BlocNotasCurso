using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BlocNotasCurso.Modulo;
using Xamarin.Forms;

namespace BlocNotasCurso
{
    public class App : Application
    {
        public App()
        {
           var start=new Startup(this);
            start.Run();
           
        }

        protected override void OnStart()//se ejecuta cuanda arranca la aplicacion
        {
            // Handle when your app starts
        }

        protected override void OnSleep()//se ejecuta cuando la aplicacion se suspende
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()//cuando el movil entra en estado de suspension o cuadno das al boton del home y queda la aplicacion en segundo plano
        {
            // Handle when your app resumes
        }

    }
}
