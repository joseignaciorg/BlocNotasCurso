using System;
using System.ComponentModel;

namespace BlocNotasCurso.ViewModel.Base
{
    //notifica cuando cambia el valor de la propiedad para que actualize el valor en la pantalla
    public interface IViewModel:INotifyPropertyChanged
    {
      string Titulo { get; set; }//Todos los viewmodels implementen un titulo de forma automatica en la pantalla

      void SetState<T>(Action<T> action) where T : class, IViewModel;// setstate fija el estado del viewmodel, fuerza a que el objeto que se pasa
       //tiene que ser una implementacion de IViewModel

      
    }
}