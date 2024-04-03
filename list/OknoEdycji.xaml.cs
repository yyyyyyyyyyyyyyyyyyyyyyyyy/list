using list;
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

namespace list
{

    public partial class OknoEdycji : Window
    {
        private Parki AlterPark;
        public Parki Edycja
        {
            get { return AlterPark; }
        }

        public OknoEdycji(Parki parki)
        {
            InitializeComponent();
            Typ.ItemsSource = Enum.GetValues(typeof(RodzajParku));
            AlterPark = parki;
            Wypełniacz(parki);
        }

        private void Wypełniacz(Parki parki)
        {
            txtMiejsce.Text = parki.Nazwa;
            txtNazwa.Text = parki.Miejsce;
            otwarotsc.IsChecked = parki.CzyOtwarty;
            Typ.SelectedItem = parki.Typ;
            rozmiar.Text = parki.Rozmiar.ToString();
            inspekcja.IsChecked = parki.CzyInspekcja;

        }



        private void btnZapisz_Click(object sender, RoutedEventArgs e)
        {
            int rozmiar;
            AlterPark.Nazwa = txtNazwa.Text;
            AlterPark.Miejsce = txtMiejsce.Text;
            AlterPark.CzyOtwarty = (bool)otwarotsc.IsChecked;
            AlterPark.Typ = (RodzajParku)Typ.SelectedItem;
            if (int.TryParse(this.rozmiar.Text, out rozmiar))
            {
                AlterPark.Rozmiar = rozmiar;
            }
            else
            {
                MessageBox.Show("Niepoprawna wartość rozmiaru");
                return;
            }
            AlterPark.CzyInspekcja = (bool)inspekcja.IsChecked;

            this.DialogResult = true;
            Close();
        }

        private void btnAnuluj_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            Close();
        }

    }
}

