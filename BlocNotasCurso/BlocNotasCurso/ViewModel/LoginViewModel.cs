using System;
using System.Windows.Input;
using BlocNotasCurso.Factorias;
using BlocNotasCurso.Model;
using BlocNotasCurso.Service;
using Xamarin.Forms;

namespace BlocNotasCurso.ViewModel
{
    public class LoginViewModel:GeneralViewModel//manejar la referenica al navegador, al servicio
    {
        //comand va a capturar eventos eventos
        public ICommand cmdLogin { get; set; }
        public ICommand cmdAlta{ get; set; }

        public LoginViewModel(INavigator navigator, IServicioDatos servicio) : base(navigator, servicio)
        {
         cmdLogin=new Command(IniciarSesion);
         cmdAlta=new Command(NuevoUsuario);   
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
                    await _navigator.PopToRootAsync();
                    await _navigator.PushAsync<PrincipalViewModel>(viewModel =>
                    {
                        Titulo = "Pantalla principal";
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
            await _navigator.PushModalAsync<PrincipalViewModel>(viewModel =>
            {
                Titulo = "Nuevo Usuario";
            });
        }
    }
}