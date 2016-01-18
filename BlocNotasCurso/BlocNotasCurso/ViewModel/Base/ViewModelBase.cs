using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BlocNotasCurso.ViewModel.Base
{
    public class ViewModelBase:IViewModel
    {
        // tres properties para manejar en todas las pantallas los tiempos de espera para que el usuario sepa que se esta realizando una tarea
        private bool _isBusy;
        private double _opacity;
        private bool _enabled;

        public event PropertyChangedEventHandler PropertyChanged;//manejador del cambio de las propiedades
        public string Titulo { get; set; }

        public ViewModelBase()
        {
            //para que al arrancar la aplicacion tenga por defecto estos valores y el usuario pueda ver lo que muestra la aplicación
            Opacity=1;
            Enabled = true;
        }

        public bool IsBusy
        {
            get { return _isBusy; }
            set
            {
                if (value)
                    Opacity = 0.5;
                else
                    Opacity = 1;
                Enabled = !value;   
                SetProperty(ref _isBusy, value);
            }
        }

        public double Opacity
        {
            get { return _opacity; }
            set { SetProperty(ref _opacity, value); }
        }

        public bool Enabled
        {
            get { return _enabled; }
            set { SetProperty(ref _enabled, value); }
        }

        //Variable, el valor de la variable y el nombre de la variable
        protected virtual bool SetProperty<T>(ref T variable,T valor,[CallerMemberName]string nombre=null)
        {
            if (object.Equals(variable, valor))//si la variable y el valor que me has dado es lo mismo 
                return false;// no hagas nada
            variable = valor;
            OnPropertyChanged(nombre);
            return true;
        }

        protected void OnPropertyChanged([CallerMemberName] string nombre = null)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                // el this es el que este en ejecucion en ese momento o el viewmodelbase o cualquiera de sus hijos
                handler(this,new PropertyChangedEventArgs(nombre));
            }
        }

        public void SetState<T>(Action<T> action) where T : class, IViewModel
        {
            //referencia de cual es el objeto viewmodel que está trabajando
            if (action!=null)
                action(this as T);
        }
    }
}