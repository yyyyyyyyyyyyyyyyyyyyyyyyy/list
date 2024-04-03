using System.IO;
using System.IO;
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

namespace list
{

    public partial class MainWindow : Window
    {

        private List
<Parki> parki = new List
    <Parki>();
        public MainWindow()
        {
            InitializeComponent();
        }


        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            Odczytywanie("pliczek.txt");
            Odświeżanie();
        }

        private void Odświeżanie()
        {
            listViewMieszkania.Items.Clear();
            foreach (var Mieszkania in parki)
            {
                listViewMieszkania.Items.Add(Mieszkania);
            }
        }

        private void ZapiszDaneDoPliku(string nazwaPliku)
        {
            using (StreamWriter writer = new StreamWriter(nazwaPliku))
            {
                foreach (var Parki in parki)
                {
                    writer.WriteLine($"{Parki.ID_Parku},{Parki.Nazwa},{Parki.Miejsce},{Parki.CzyOtwarty},{Parki.Typ},{Parki.Rozmiar},{Parki.CzyInspekcja},");
                }
            }
        }

        private void Odczytywanie(string nazwaPliku)
        {
            parki.Clear();
            if (File.Exists(nazwaPliku))
            {
                using (StreamReader reader = new StreamReader(nazwaPliku))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] parts = line.Split(',');
                        if (parts.Length == 8)
                        {
                            Parki Parki = new Parki();
                            Parki.ID_Parku = int.Parse(parts[0]);
                            Parki.Nazwa = parts[1];
                            Parki.Miejsce = parts[2];
                            Parki.CzyOtwarty = bool.Parse(parts[3]);
                            Parki.Typ = (RodzajParku)Enum.Parse(typeof(RodzajParku), parts[4]);
                            Parki.Rozmiar = int.Parse(parts[5]);
                            Parki.CzyInspekcja = bool.Parse(parts[6]);
                            parki.Add(Parki);
                        }
                    }
                }
            }
        }

        private void ZapiszToolStripMenuItem_Click(object sender, RoutedEventArgs e)
        {
            ZapiszDaneDoPliku("pliczek.txt");
        }

        private void PobierzToolStripMenuItem_Click(object sender, RoutedEventArgs e)
        {
            Odczytywanie("pliczek.txt");
            Odświeżanie();
        }

        private void ZamknijToolStripMenuItem_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void PomocToolStripMenuItem_Click(object sender, RoutedEventArgs e)
        {
            ThePomoc kontaktForm = new ThePomoc();
            kontaktForm.ShowDialog();
        }

        private void EdytujToolStripMenuItem_Click(object sender, RoutedEventArgs e)
        {
            if (listViewMieszkania.SelectedItem != null)
            {
                Parki selectedMieszkania = (Parki)listViewMieszkania.SelectedItem;
                OknoEdycji edytujWindow = new OknoEdycji(selectedMieszkania);
                if (edytujWindow.ShowDialog() == true)
                {
                    selectedMieszkania = edytujWindow.Edycja;
                    Odświeżanie();
                }
            }
            else
            {
                MessageBox.Show("Zaznacz element do edycji");
            }
        }

        private void UsunToolStripMenuItem_Click(object sender, RoutedEventArgs e)
        {
            if (listViewMieszkania.SelectedItem != null)
            {
                Parki SelPark = (Parki)listViewMieszkania.SelectedItem;
                parki.Remove(SelPark);
                Odświeżanie();
            }
            else
            {
                MessageBox.Show("Zaznacz element do usuniecia");
            }
        }

        private void DodajToolStripMenuItem_Click(object sender, RoutedEventArgs e)
        {
            OknoEdycji edyt = new OknoEdycji(new Parki());
            if (edyt.ShowDialog() == true)
            {
                Parki newPark = edyt.Edycja;
                if (parki.Any())
                {
                    newPark.ID_Parku = parki.Max(p => p.ID_Parku) + 1;
                }
                else
                {
                    newPark.ID_Parku = 1;
                }
                parki.Add(newPark);
                Odświeżanie();
            }
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}