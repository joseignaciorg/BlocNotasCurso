using System;
using System.Windows.Input;
using BlocNotasCurso.Factorias;
using BlocNotasCurso.Model;
using BlocNotasCurso.Service;

namespace BlocNotasCurso.ViewModel
{
    public class RegistroViewModel:GeneralViewModel
    {
        //capturo el evento del boton alta
        public ICommand cmdRegistro { get; set; }

        public Usuario Usuario
        {
            get { return _usuario; }
            set { SetProperty(ref _usuario, value); }
        }

        private Usuario _usuario;

        public RegistroViewModel(INavigator navigator, IServicioDatos servicio) : base(navigator, servicio)
        {

        }

        private async void GuardarUsuario()
        {
            try
            {
                IsBusy = true;
                var r=await _servicio.AddUsuario(_usuario);
                if (r!=null)
                {
                    await _navigator.PushModalAsync<PrincipalViewModel>();
                }
                else
                {
                    //se meteria un dialogo para el control de los mensajes de error
                    var a = "";
                }
            }
            finally
            {

                IsBusy = false;
            }
        }
    }
}