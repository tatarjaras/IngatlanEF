using IngatlanEF.Models;
using IngatlanEF.Services;
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

namespace IngatlanEF.IngatlanokWindows
{
    /// <summary>
    /// Interaction logic for IngatlanokFelviteleWindow.xaml
    /// </summary>
    public partial class IngatlanokFelviteleWindow : Window
    {
        public IngatlanokFelviteleWindow()
        {
            InitializeComponent();
            cbxTipus.ItemsSource = MainWindow.tipusok;
        }



        private void btnMentes_click(object sender, RoutedEventArgs e)
        {
            Ingatlan ujIngatlan = new()
            {
                Id=0,
                Telepules=tbxTelepules.Text,
                Cim=tbxCim.Text,
                Ar=int.Parse(tbxAr.Text),
                Tipus=cbxTipus.Text,
                KepNev=tbxKepNev.Text,
                UgyintezoId=int.Parse(cbxUgyintezoId.Text)
            };
            IngatlanService.IngatlanInsert(ujIngatlan);
            MessageBox.Show("Sikeres rögzítés");
        }

        private void btnMegse_click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
