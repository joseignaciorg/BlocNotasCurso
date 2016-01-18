using System;
using System.Threading.Tasks;
using BlocNotasCurso.ViewModel.Base;

namespace BlocNotasCurso.Factorias
{
    public interface INavigator //interfaz para manejar operaciones de navegacion (push, pop)
    {
        // ventanas modales no se apilan con otras tiene que ir ella sola(solo hay una por aplicacion a no ser que elimines y metas otra)

        Task<IViewModel> PopAsync(); // borra ventanas normales
        Task<IViewModel> PopModalAsync(); //borra ventanas modales
        Task PopToRootAsync();//borra todas las pantallas que estan en la pila de pantallas para agregar una limpia 

        Task<TViewModel> PushAsync<TViewModel>(Action<TViewModel> action = null) where TViewModel:class,IViewModel;//apilas ventanas normales
        Task<TViewModel> PushAsync<TViewModel>(TViewModel viewModel) where TViewModel : class, IViewModel;

        Task<TViewModel> PushModalAsync<TViewModel>(Action<TViewModel> action = null) where TViewModel : class, IViewModel;
        Task<TViewModel> PushModalAsync<TViewModel>(TViewModel viewModel) where TViewModel : class, IViewModel;
    }
}