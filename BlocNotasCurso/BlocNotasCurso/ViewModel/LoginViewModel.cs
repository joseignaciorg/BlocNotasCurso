using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using BlocNotasCurso.Factorias;
using BlocNotasCurso.Model;
using BlocNotasCurso.Service;
using BlocNotasCurso.Util;
using Xamarin.Forms;

namespace BlocNotasCurso.ViewModel
{
    public class LoginViewModel:GeneralViewModel//manejar la referenica al navegador, al servicio
    {
        //comand va a capturar eventos
        public ICommand cmdLogin { get; set; }
        public ICommand cmdAlta{ get; set; }

        public LoginViewModel(INavigator navigator, IServicioDatos servicio, Session session) : base(navigator, servicio,session)
        {
         cmdLogin=new Command(IniciarSesion);
         cmdAlta=new Command(NuevoUsuario);
            Titulo = "Blocs";
        }

        public string TituloIniciar { get { return "Iniciar sesión"; } }
        public string TituloRegistro { get { return "Nuevo usuario"; } }
        public string TituloLogin { get { return "Nombre de usuario"; } }
        public string TituloPassword { get { return "Contraseña"; } }

        private Usuario _usuario=new Usuario();
        public Usuario Usuario
        {
            get { return _usuario; }
            set { SetProperty(ref _usuario, value); }
        }

        private async void IniciarSesion()
        {
            try
            {
                IsBusy = true;// bloqueamos la pantalla para poner un reloj y que el usuario sepa que se esta logeando
                var us = await _servicio.ValidarUsuario(_usuario);
                if (us!=null)
                {
                    Session["usuario"] = us;
                    var blocs = await _servicio.GetBlocs(us.Id);
                    
                    //await _navigator.PopToRootAsync();
                    await _navigator.PushAsync<PrincipalViewModel>(viewModel =>
                    {
                        Titulo = "Pantalla principal";
                        viewModel.Blocs=new ObservableCollection<Bloc>(blocs);

                    });
                }
                else
                {
                    //se meteria un dialogo para el control de los mensajes de error
                    var xxx = "";
                }
                
            }
            finally
            {

                IsBusy = false;
            }
        }

        private async void NuevoUsuario()
        {
            //se puede poner de estas dos formas (descomentando el comentario y poniendo el pushmodalasync solo pushAsync)
            //o dejandolo como esta
            //await _navigator.PopToRootAsync();
            await _navigator.PushModalAsync<RegistroViewModel>(viewModel =>
            {
                viewModel.Titulo = "Nuevo Usuario";
            });
        }
    }
}