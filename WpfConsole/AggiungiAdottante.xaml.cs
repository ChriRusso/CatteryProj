using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Application.UseCases;
using Domain.Model.Entities;
namespace WpfConsole
{
    /// <summary>
    /// Logica di interazione per AggiungiAdottante.xaml
    /// </summary>
    public partial class AggiungiAdottante : Window
    {
        Adopter adopter;
        AdoptionService AdopterService;
        public AggiungiAdottante()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            adopter= new(nome.Text, cognome.Text, Enum.Parse(sesso.Text), indirizzo.Text, telefono.Text, email.Text);
            AdopterService.AddAdopter(adopter);
        }
    }
}
