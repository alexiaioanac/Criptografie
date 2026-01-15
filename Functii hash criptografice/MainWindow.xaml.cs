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

namespace Functii_hash_criptografice
{
    public partial class MainWindow : Window
    {
        SimpleHash sh = new SimpleHash();

        public MainWindow() => InitializeComponent();

        private void SelectFile_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == true) InputPath.Text = ofd.FileName;
        }

        private void Radio_Checked(object sender, RoutedEventArgs e)
        {
            if (sender is System.Windows.Controls.RadioButton rb)
                if (rb?.Tag != null)
                {
                    sh.hashIdx = int.Parse(rb.Tag.ToString());
                }
        }

        private async void Calculate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                await sh.HashFileAsync(InputPath.Text, "rezultat_hash.txt");
                MessageBox.Show("Gata! Verifică fișierul rezultat_hash.txt");
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
    }
}