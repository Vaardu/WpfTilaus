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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfTilaus
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DateTime tanaan = DateTime.Today;

        public MainWindow()
        {
            InitializeComponent();

            dpTilausPvm.SelectedDate = tanaan;
            dpToimitusPvm.SelectedDate = tanaan.AddDays(14);

            DataGridTextColumn TextColumn1 = new DataGridTextColumn();
            TextColumn1.Binding = new Binding("TilausNumero");
            DataGridTextColumn TextColumn2 = new DataGridTextColumn();
            TextColumn2.Binding = new Binding("TuoteNumero");
            DataGridTextColumn TextColumn3 = new DataGridTextColumn();
            TextColumn3.Binding = new Binding("TuoteNimi");
            DataGridTextColumn TextColumn4 = new DataGridTextColumn();
            TextColumn4.Binding = new Binding("TuotteenMaara");
            DataGridTextColumn TextColumn5 = new DataGridTextColumn();
            TextColumn5.Binding = new Binding("TuotteenHinta");

            TextColumn1.Header = "Tilausnumero";
            dgTilausRivit.Columns.Add(TextColumn1);
            TextColumn2.Header = "Tuotenumero";
            dgTilausRivit.Columns.Add(TextColumn2);
            TextColumn3.Header = "Tuotteen nimi";
            dgTilausRivit.Columns.Add(TextColumn3);
            TextColumn4.Header = "Määrä";
            dgTilausRivit.Columns.Add(TextColumn4);
            TextColumn5.Header = "Hinta";
            dgTilausRivit.Columns.Add(TextColumn5);


        }

        private void BtnTallenna_Click(object sender, RoutedEventArgs e)
        {
            TilausOtsikko Tilaus = new TilausOtsikko();

            try
            {
            Tilaus.TilausNumero = int.Parse(txtTilausnumero.Text);
            Tilaus.TilausPvm = dpTilausPvm.SelectedDate.Value;
            Tilaus.ToimitusPvm = dpToimitusPvm.SelectedDate.Value;
            Tilaus.AsiakasNumero = int.Parse(txtAsiakasnumero.Text);
            Tilaus.AsiakkaanNimi = txtAsiakkaanNimi.Text;
            Tilaus.ToimitusOsoite = txtToimitusosoite.Text;

            MessageBox.Show("Tilaus talennettu." + "\r\n"
                            + "Tilausnumero: " + Tilaus.TilausNumero.ToString() + "\r\n"
                            + "Tilauspäivämäärä: " + Tilaus.TilausPvm.ToString() + "\r\n"
                            + "Tilaajan nimi: " + Tilaus.AsiakkaanNimi + "\r\n"
                            + "Asiakasnumero: " + Tilaus.AsiakasNumero + "\r\n"
                            + "Toimitusosoite: " + Tilaus.ToimitusOsoite + "\r\n"
                            + "Toimituspäivämäärä: " + Tilaus.ToimitusPvm
                            );
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnLisaaRivi_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                TilausRivi TilausR = new TilausRivi();
                TilausR.TilausNumero = int.Parse(txtTilausnumero.Text);
                TilausR.TuoteNumero = int.Parse(txtTuoteNumero.Text);
                TilausR.TuoteNimi = txtTuotteenNimi.Text;
                TilausR.TuotteenHinta = Convert.ToDecimal(txtTuotteenHinta.Text);
                TilausR.TuotteenMaara = int.Parse(txtTuotteenMaara.Text);

                MessageBox.Show("Tilausrivi talennettu." + "\r\n"
                                + "Tilausnumero: " + TilausR.TilausNumero.ToString() + "\r\n"
                                + "Tuotenumero: " + TilausR.TuoteNumero.ToString() + "\r\n"
                                + "Tuotteen nimi: " + TilausR.TuoteNimi + "\r\n"
                                + "Hinta: " + TilausR.TuotteenHinta + "\r\n"
                                + "Määrä: " + TilausR.TuotteenMaara
                                );

                dgTilausRivit.Items.Add(TilausR);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
