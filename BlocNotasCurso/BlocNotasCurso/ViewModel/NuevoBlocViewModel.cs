using System;
using System.Collections.ObjectModel;
using System.Diagnostics.Contracts;
using System.Windows.Input;
using BlocNotasCurso.Factorias;
using BlocNotasCurso.Model;
using BlocNotasCurso.Service;
using BlocNotasCurso.Util;
using Xamarin.Forms;

namespace BlocNotasCurso.ViewModel
{
    public class NuevoBlocViewModel:GeneralViewModel
    {
        public ObservableCollection<Bloc> Blocs { get; set; }
        private Bloc _bloc;
        public ICommand CmdGuardar { get; set; }

        public Bloc Bloc
        {
            get { return _bloc; }
            set { SetProperty(ref _bloc, value); }
        }

        public NuevoBlocViewModel(INavigator navigator, IServicioDatos servicio, Session session) : base(navigator, servicio, session)
        {
            _bloc = new Bloc();
            CmdGuardar=new Command(Guardar);

        }

        private async void Guardar()
        {
            Bloc.Fecha=DateTime.Now;
            Bloc.IdUsuario = (Session["usuario"] as Usuario).Id;
            Bloc.Icono = "";

            await _servicio.AddBloc(Bloc);// añade en la base de datos en la nube
            Blocs.Add(Bloc);//añade la informacion a la lista observablecollection
        }
    }
}