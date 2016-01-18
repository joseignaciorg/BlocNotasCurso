using BlocNotasCurso.Factorias;
using BlocNotasCurso.Service;
using BlocNotasCurso.ViewModel.Base;

namespace BlocNotasCurso.ViewModel
{
    public class GeneralViewModel:ViewModelBase
    {
        protected INavigator _navigator;
        protected IServicioDatos _servicio;

        public GeneralViewModel(INavigator navigator, IServicioDatos servicio)
        {
            _navigator = navigator;
            _servicio = servicio;
        }
    }
}