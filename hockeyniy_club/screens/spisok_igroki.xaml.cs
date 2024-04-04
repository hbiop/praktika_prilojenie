using hockeyniy_club.models;
using Npgsql;
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

namespace hockeyniy_club.screens
{
    public class MyItem
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string Familia { get; set; }
        public string Otchestvo { get; set; }
        public int NomerIgroka { get; set; }
        public DateTime DataRojdenia { get; set; }
        public string Pozicia { get; set; }
        public string Komanda { get; set; }

    }
    /// <summary>
    /// Логика взаимодействия для spisok_igroki.xaml
    /// </summary>
    public partial class spisok_igroki : Window
    {

        public List<MyItem> igroki = new List<MyItem>();
        public spisok_igroki()
        {
            getIgrok();
            InitializeComponent();
            myListView.ItemsSource = igroki;
        }
        private void getIgrok()
        {
            string Connection = @"Host=localhost;Username=postgres;Password=YngtDrtv276hjkQw8221;Database=HockeyniyClub";
            Npgsql.NpgsqlConnection nc = new Npgsql.NpgsqlConnection(Connection);
            try
            {
                nc.Open();
                Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand("select * from public.igroki\r\njoin pozicia_igroka on igroki.pozicia_igroka = pozicia_igroka.kod_pozicii\r\njoin komandi on igroki.kod_komandi = komandi.kod_komandi", nc);
                NpgsqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        igroki.Add(new MyItem { id = reader.GetInt32(0), Name = reader.GetString(1), Familia = reader.GetString(2), Otchestvo = reader.GetString(3), NomerIgroka = reader.GetInt32(4), DataRojdenia = reader.GetDateTime(5), Pozicia = reader.GetString(10), Komanda = reader.GetString(12) });
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int ind = myListView.SelectedIndex;
            if (ind != -1)
            {
                string Connection = @"Host=localhost;Username=postgres;Password=YngtDrtv276hjkQw8221;Database=HockeyniyClub";
                Npgsql.NpgsqlConnection nc = new Npgsql.NpgsqlConnection(Connection);
                try
                {
                    nc.Open();
                    Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand("Delete from public.igroki where kod_igroka = " + igroki[ind], nc);
                    int reader = command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Поле не выбрано");
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            int ind = myListView.SelectedIndex;
            if (ind != -1)
            {
                izmenenie_igroka izmenenie_Igroka = new izmenenie_igroka(igroki[ind]);
                izmenenie_Igroka.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Поле не выбрано");
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            izmenenie_igroka izmenenie_Igroka = new izmenenie_igroka();
            izmenenie_Igroka.Show();
            this.Close();
        }
    }
}
