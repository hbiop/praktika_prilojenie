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
    public class Match
    {
        public int id { get; set; }
        public DateTime DataProvedenia { get; set; }
        public TimeSpan VremiaNachala { get; set; }
        public TimeSpan VremiaKonca { get; set; }
        public string DomashnyaKomanda { get; set; }
        public string Sopernik { get; set; }
        public int SchetDom { get; set; }
        public int SchetSop { get; set; }

    }
    /// <summary>
    /// Логика взаимодействия для matchi.xaml
    /// </summary>
    public partial class matchi : Window
    {
        public List<Match> spisokMatchi = new List<Match>();

        public matchi()
        {
            getMatch();
            InitializeComponent();
            myListView.ItemsSource = spisokMatchi;
        }



        public void getMatch()
        {
            string Connection = @"Host=localhost;Username=postgres;Password=YngtDrtv276hjkQw8221;Database=HockeyniyClub";
            Npgsql.NpgsqlConnection nc = new Npgsql.NpgsqlConnection(Connection);
            try
            {
                nc.Open();
                Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand("select * from public.matchi\r\njoin komandi as dom on dom.kod_komandi = matchi.kod_domashney_komandi\r\njoin komandi as gost on gost.kod_komandi = matchi.kod_komandi_gostey", nc);
                NpgsqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        spisokMatchi.Add(new Match { id = reader.GetInt32(0), DataProvedenia = reader.GetDateTime(1), VremiaNachala = reader.GetTimeSpan(2), VremiaKonca = reader.GetTimeSpan(3), DomashnyaKomanda = reader.GetString(9), Sopernik = reader.GetString(13), SchetDom = reader.GetInt32(6), SchetSop = reader.GetInt32(7) });
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            izmenenie_match izmenenie_Igroka = new izmenenie_match();
            izmenenie_Igroka.Show();
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
                    Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand("Delete from public.matchi where kod_matcha = " + spisokMatchi[ind].id, nc);
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
                izmenenie_match izmenenie_Igroka = new izmenenie_match(spisokMatchi[ind]);
                izmenenie_Igroka.Show();
            }
            else
            {
                MessageBox.Show("Поле не выбрано");
            }
        }
    }
}
