using System;
using System.Threading.Tasks;
using BlocNotasCurso.ViewModel.Base;
using Xamarin.Forms;

namespace BlocNotasCurso.Factorias
{
    public class Navigator:INavigator //implementamos la clase navigator
    {
        private readonly Lazy<INavigation> _navigation;// se encarga del proceso lazy loading almacena el navigation (de xamarin porque navigator es el creado por mi)
        private readonly IViewFactory _viewFactory;// tiene las relaciones de las vistas con los viewmodel y la carga de estas
        

        public Navigator(Lazy<INavigation> navigation, IViewFactory viewFactory)//mantengo las instancias en memoria para poder utilizarlas
        {
            _navigation = navigation;
            _viewFactory = viewFactory;
            
        }
        public INavigation Navigation { get {return _navigation.Value; } }

        public async Task<IViewModel> PopAsync()//llama al metodo popasync del objeto navigation y nos devuelve cual es el viewmodel que tenia relacionado
        {
            Page vista = await Navigation.PopAsync();
            return vista.BindingContext as IViewModel;
        }

        public async Task<IViewModel> PopModalAsync()
        {
            Page vista = await Navigation.PopModalAsync();
            return vista.BindingContext as IViewModel;
        }

        public async Task PopToRootAsync()
        {
            await Navigation.PopToRootAsync();
        }

        public async Task<TViewModel> PushAsync<TViewModel>(Action<TViewModel> action = null) where TViewModel : class, IViewModel
        {
            TViewModel viewModel;
            var vista = _viewFactory.Resolve<TViewModel>(out viewModel, action);
            await Navigation.PushAsync(vista);
            return viewModel;
        }

        public async Task<TViewModel> PushAsync<TViewModel>(TViewModel viewModel) where TViewModel : class, IViewModel
        {
            
            var vista = _viewFactory.Resolve<TViewModel>(viewModel);
            await Navigation.PushAsync(vista);
            return viewModel;
        }

        public async Task<TViewModel> PushModalAsync<TViewModel>(Action<TViewModel> action = null) where TViewModel : class, IViewModel
        {
            TViewModel viewModel;
            var vista = _viewFactory.Resolve<TViewModel>(out viewModel, action);
            await Navigation.PushModalAsync(vista);
            return viewModel;
        }

        public async Task<TViewModel> PushModalAsync<TViewModel>(TViewModel viewModel) where TViewModel : class, IViewModel
        {
            var vista = _viewFactory.Resolve<TViewModel>(viewModel);
            await Navigation.PushModalAsync(vista);
            return viewModel;
        }
    }
}