﻿using AppS7.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppS7
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Elemento : ContentPage
    {
        public int IdSeleccionado;

        private SQLiteAsyncConnection _conn;
        IEnumerable<Estudiante> ResultadoDelete;
        IEnumerable<Estudiante> ResultadoUpdate;
        public Elemento(int id)
        {
            _conn = DependencyService.Get<DataBase>().GetConnection();
            IdSeleccionado = id;
            InitializeComponent();

        }

        private void btn_actualizar_Clicked(object sender, EventArgs e)
        {
            try
            {
                var DataBasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "uisrael.db3");
                var db = new SQLiteConnection(DataBasePath);
                ResultadoUpdate = Update(db, Nombre.Text, Usuario.Text, Contrasenia.Text, IdSeleccionado);
                DisplayAlert("Alerta", "Se actualizo correctamente", "OK");
            }
            catch (Exception ex)
            {
                DisplayAlert("Alerta", "ERROR" + ex.Message, "OK");
            }
        }

        private void btn_eliminar_Clicked(object sender, EventArgs e)
        {
            try
            {
                var DataBasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "uisrael.db3");
                var db = new SQLiteConnection(DataBasePath);
                ResultadoDelete = Delete(db, IdSeleccionado);
                DisplayAlert("Alerta", "Se elimino correctamente", "OK");
            }
            catch (Exception ex)
            {
                DisplayAlert("Alerta", "Error" + ex.Message, "OK");
            }

        }

        public static IEnumerable<Estudiante> Delete(SQLiteConnection db, int id)
        {
            return db.Query<Estudiante>("DELETE FROM estudiante where Id = ?", id);

        }


        public static IEnumerable<Estudiante> Update(SQLiteConnection db, string nombre, string usuario, string contrasenia, int id)
        {
            return db.Query<Estudiante>("UPDATE estudiante SET Nombre=?, Usuario=? ," + "Contrasenia=? where Id=?", nombre, usuario, contrasenia, id);
        }
    }
}