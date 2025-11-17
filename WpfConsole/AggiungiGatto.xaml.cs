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
using Domain.Model.ValueObject;
namespace WpfConsole
{
    /// <summary>
    /// Logica di interazione per AggiungiGatto.xaml
    /// </summary>
    public partial class AggiungiGatto : Window
    {
        CatService CatService;
        Cat cat;
        public AggiungiGatto()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
             cat = new(nome.Text,cognome.Text, Enum.Parse(sesso.Text),desc.Text,nascita,arrivo,uscita,null);
            CatService.AddCat(cat);
        }
    }
}
