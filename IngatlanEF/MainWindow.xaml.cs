using IngatlanEF.IngatlanokWindows;
using IngatlanEF.UgyintezokWindows;
using Microsoft.Win32;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace IngatlanEF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public const string JELSZO = "asd";
        public static bool isLogged = false;
        public static string logName = "";
        public static string[] tipusok = {"családi ház","Lakás","építési telek","raktárépület","nyaraló","ba"};
        public MainWindow()
        {
            InitializeComponent();
        }

        private void LogInOut(object sender, RoutedEventArgs e)
        {
            if (isLogged)
            {
                lblBejelentkezve.Content = "Bejelentkezve:";
                isLogged = false;
                mnuBelepes.Header = "Bejelentkezés";
            }
            else
            {
                LoginWindow loginWindow = new LoginWindow();
                loginWindow.ShowDialog();
                if (isLogged)
                {
                    mnuBelepes.Header = "Kilépés";
                    mnuIngatlanok.IsEnabled = true;
                    mnuUgyintezok.IsEnabled = true;
                    mnuExport.IsEnabled = true;
                    lblBejelentkezve.Content = $"Bejelentkezve: {logName}";
                }
            }
        }

        private void IngatlanokListaja(object sender, RoutedEventArgs e)
        {
            IngatlanListaWindow ingatlanListaWindow = new IngatlanListaWindow();
            ingatlanListaWindow.ShowDialog();
        }

        private void UgyintezokListaja(object sender, RoutedEventArgs e)
        {
            UgyintezokListaWindow ugyintezokListaWindow = new UgyintezokListaWindow();
            ugyintezokListaWindow.ShowDialog();
        }

        private void Ingatlanokfelvitele(object sender, RoutedEventArgs e)
        {
            IngatlanokFelviteleWindow ingatlanokFelviteleWindow=new IngatlanokFelviteleWindow();
            ingatlanokFelviteleWindow.ShowDialog();
        }

        private void IngatlanokModositasa_Click(object sender, RoutedEventArgs e)
        {
            IngatlanokModositowindow ingatlanokModositowindow = new IngatlanokModositowindow();
            ingatlanokModositowindow.ShowDialog();
        }

        private void Export_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog()
            {
                FileName = "export.txt",
                DefaultExt="*.txt",
                Filter="txt|*.txt"
            };
            if (sfd.ShowDialog()==true)
            {

            }
            else
            {
                MessageBox.Show("nincs állomány");
            }
            

        }
    }
}