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
                cbxTipus.SelectedItem = MainWindow.tipusok.Contains(kivalasztott.Tipus) ? kivalasztott.Tipus : "ba";
                cbxUgyintezoId.SelectedItem = $"{kivalasztott.UgyintezoId}. {ugyintezok.FirstOrDefault(u=>u.Id==kivalasztott.UgyintezoId).Nev}";
                
            }
            else
            {
                MessageBox.Show("nincs kiválasztva elem!");
            }
        }

        private void btnMentes_click(object sender, RoutedEventArgs e)
        {
            int ujAr = 0;
            int ujUgyi = 0;
            if (int.TryParse(tbxAr.Text, out ujAr) && int.TryParse(cbxUgyintezoId.Text.Split(".")[0], out ujUgyi))
            {


                Ingatlan ujIngatlan = new()
                {
                    Id = int.Parse(cbxSelect.SelectedItem.ToString().Split(":")[0]) ,
                    Telepules = tbxTelepules.Text,
                    Cim = tbxCim.Text,
                    Ar = ujAr,
                    Tipus = cbxTipus.Text,
                    KepNev = tbxKepNev.Text,
                    UgyintezoId = ujUgyi
                };
                IngatlanService.IngatlanUpdate(ujIngatlan);
                MessageBox.Show("Sikeres rögzítés");
                CbxSelectFeltolt();
            }
            else
            {
                MessageBox.Show("nem megfelő ár/ügyintéző");
            }
        }
    }
}
