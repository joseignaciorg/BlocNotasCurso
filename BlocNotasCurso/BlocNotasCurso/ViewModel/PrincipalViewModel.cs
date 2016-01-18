using BlocNotasCurso.Factorias;
using BlocNotasCurso.Service;

namespace BlocNotasCurso.ViewModel
{
    public class PrincipalViewModel:GeneralViewModel
    {
        public PrincipalViewModel(INavigator navigator, IServicioDatos servicio) : base(navigator, servicio)
        {
        }
    }
}