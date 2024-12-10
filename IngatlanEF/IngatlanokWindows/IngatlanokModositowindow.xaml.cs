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
    /// Interaction logic for IngatlanokModositowindow.xaml
    /// </summary>
    public partial class IngatlanokModositowindow : Window
    {
        List<Ingatlan> ingatlanok;
        List<Ugyintezo> ugyintezok = UgyintezoService.GetAllUgyintezo();
        public IngatlanokModositowindow()
        {
            InitializeComponent();
            CbxSelectFeltolt();
            cbxSelect.SelectedIndex = 0;
            cbxTipus.ItemsSource = MainWindow.tipusok;
            foreach (Ugyintezo ugyintezo in ugyintezok)
            {
                cbxUgyintezoId.Items.Add($"{ugyintezo.Id}. {ugyintezo.Nev}");
            }
        }

        private void CbxSelectFeltolt()
        {
            ingatlanok = IngatlanService.GetAllIngatlan();
            cbxSelect.Items.Clear();
            foreach (Ingatlan ingatlan in ingatlanok)
            {
                cbxSelect.Items.Add($"{ingatlan.Id}:{ingatlan.Telepules}, {ingatlan.Cim}");
            }
        }

        private void btnMegse_click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void cbxSelect_select(object sender, SelectionChangedEventArgs e)
        {
            Ingatlan kivalasztott=ingatlanok.FirstOrDefault(i=>i.Id==int.Parse(cbxSelect.SelectedItem.ToString().Split(":")[0]));
            if (kivalasztott!=null )
            {
                tbxTelepules.Text=kivalasztott.Telepules;
                tbxCim.Text=kivalasztott.Cim;
                tbxAr.Text=kivalasztott.Ar.ToString();
                tbxKepNev.Text=kivalasztott.KepNev;
                cbxTipus.Text=kivalasztott.Tipus;
                cbxUgyintezoId.SelectedItem = kivalasztott.UgyintezoId.ToString();
            }
            else
            {
                MessageBox.Show("nincs kiválasztva elem!");
            }
        }
    }
}
