using System;
using System.Diagnostics.Contracts;
using BlocNotasCurso.ViewModel.Base;
using Xamarin.Forms;

namespace BlocNotasCurso.Factorias
{
    public interface IViewFactory //se encarga de contruir vistas para que el contenedor de inyeccion de dependencias 
                                  //sepa quien es el viewmodel y quien el view de forma automatica
    {
        //register guarda en el contenedor todas las relaciones de viewmodel con view
        // TViewmodel tiene que ser un objeto (por eso le ponemos class)
        //TView tiene que heredar de page
        void Register<TViewModel, TView>() where TViewModel : class, IViewModel where TView : Page;

        //Para poder navegar entre las diferentes vistas uso los resolve
        
        //Resolucion diciendo cual es el objeto acción del viewmodelo
        Page Resolve<TViewModel>(Action<TViewModel> action = null) where TViewModel : class,IViewModel;

        //Paso tviewmodel y quiera escribir sobre el
        Page Resolve<TViewModel>(out TViewModel viewModel, Action<TViewModel> action = null) where TViewModel: class,IViewModel;

        //Paso un viewmodel hecho vacio para que me lo devuelvas (para cargar otros elementos en el etc...)
        Page Resolve<TViewModel>(TViewModel viewModel) where TViewModel : class,IViewModel;

    }
}