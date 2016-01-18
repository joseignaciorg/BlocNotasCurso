using Xamarin.Forms;

namespace BlocNotasCurso.Factorias
{
    public interface IPage // Define el funcionamiento de una determinada página (sacaremos al usuario dialogos y tenemos que saber en que ventana estamos )
    {
        //navigation gestiona tod@ lo que hay en la pila de navegacion de xamarin
        INavigation Navigation { get;} 
    }
}