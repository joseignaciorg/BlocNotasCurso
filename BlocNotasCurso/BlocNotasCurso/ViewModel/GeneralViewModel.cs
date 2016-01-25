using BlocNotasCurso.Factorias;
using BlocNotasCurso.Service;
using BlocNotasCurso.Util;
using BlocNotasCurso.ViewModel.Base;

namespace BlocNotasCurso.ViewModel
{
    public class GeneralViewModel:ViewModelBase
    {
        protected INavigator _navigator;
        protected IServicioDatos _servicio;
        protected Session Session { get; set; }

        public GeneralViewModel(INavigator navigator, IServicioDatos servicio, Session session)
        {
            _navigator = navigator;
            _servicio = servicio;
            Session = session;
        }
    }
}