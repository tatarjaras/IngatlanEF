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

namespace IngatlanEF.UgyintezokWindows
{
    /// <summary>
    /// Interaction logic for UgyintezokListaWindow.xaml
    /// </summary>
    public partial class UgyintezokListaWindow : Window
    {
        public UgyintezokListaWindow()
        {
            InitializeComponent();
            List<Ugyintezo> ugyintezok = UgyintezoService.GetAllUgyintezo();
            dgrUgyintezok.ItemsSource = ugyintezok;
        }

        private void btnBezar(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
