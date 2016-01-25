using System.Collections.ObjectModel;
using System.Windows.Input;
using BlocNotasCurso.Factorias;
using BlocNotasCurso.Model;
using BlocNotasCurso.Service;
using BlocNotasCurso.Util;
using Xamarin.Forms;

namespace BlocNotasCurso.ViewModel
{
    public class PrincipalViewModel:GeneralViewModel
    {
        private ObservableCollection<Bloc> _blocs;
        public ICommand CmdNuevo { get; set; }

        public ObservableCollection<Bloc> Blocs
        {
            get { return _blocs; }
            set { SetProperty(ref _blocs, value); }
        }

        public PrincipalViewModel(INavigator navigator, IServicioDatos servicio, Session session) : base(navigator, servicio, session)
        {

            CmdNuevo=new Command(NuevoBloc);
        }

        private async void NuevoBloc()
        {

            await _navigator.PushAsync<NuevoBlocViewModel>(viewModel =>
            {
                viewModel.Titulo = "Nuevo bloc";
                viewModel.Blocs = Blocs;
            });
        }
    }
}