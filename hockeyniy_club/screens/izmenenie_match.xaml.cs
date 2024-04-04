using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Xml.Linq;

namespace hockeyniy_club.screens
{
    /// <summary>
    /// Логика взаимодействия для izmenenie_match.xaml
    /// </summary>
    public partial class izmenenie_match : Window
    {
        public List<Komandi> komandis = new List<Komandi>();
        public int id;
        public int ind;
        public int a = -1;
        public izmenenie_match()
        {
            a = 0;
            InitializeComponent();
            getMaxInd();
            getKomandi();
            dom_komanda.ItemsSource = komandis;
            dom_komanda.DisplayMemberPath = "nazvanie_komandi";
            gost_komandda.ItemsSource = komandis;
            gost_komandda.DisplayMemberPath = "nazvanie_komandi";
        }
        public void getMaxInd()
        {
            ind = -1;
            string Connection = @"Host=localhost;Username=postgres;Password=YngtDrtv276hjkQw8221;Database=HockeyniyClub";
            Npgsql.NpgsqlConnection nc = new Npgsql.NpgsqlConnection(Connection);
            try
            {
                nc.Open();
                Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand("select max(kod_matcha) + 1 from public.matchi", nc);
                NpgsqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        ind = reader.GetInt32(0);
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void AddMatch()
        {
            string Connection = @"Host=localhost;Username=postgres;Password=YngtDrtv276hjkQw8221;Database=HockeyniyClub";
            Npgsql.NpgsqlConnection nc = new Npgsql.NpgsqlConnection(Connection);
            try
            {
                nc.Open();
                Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand("INSERT INTO public.matchi values (" + ind + ", '" + Convert.ToDateTime(data.Text).Year + "-" + Convert.ToDateTime(data.Text).Month + "-" + Convert.ToDateTime(data.Text).Day + "' ,'" + vremia_nachal.Text + "','" + vremia_konca.Text + "'," + Convert.ToInt32(komandis[Convert.ToInt32(dom_komanda.SelectedIndex)].id) + ", " + Convert.ToInt32(komandis[Convert.ToInt32(gost_komandda.SelectedIndex)].id) + ", " + Convert.ToInt32(Schet_dom_kom.Text) + ", " + Convert.ToInt32(schet_gost_kom.Text) + ") ", nc);
                int i = command.ExecuteNonQuery();
                MessageBox.Show("Данные были успешно сохранены");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public izmenenie_match(Match match)
        {
            a = 1;
            getKomandi();
            InitializeComponent();
            id = match.id;
            data.Text = match.DataProvedenia.ToString();
            vremia_nachal.Text = match.VremiaNachala.ToString();
            vremia_konca.Text = match.VremiaKonca.ToString();
            dom_komanda.ItemsSource = komandis;
            dom_komanda.DisplayMemberPath = "nazvanie_komandi";
            dom_komanda.Text = match.DomashnyaKomanda.ToString();
            gost_komandda.ItemsSource = komandis;
            gost_komandda.DisplayMemberPath = "nazvanie_komandi";
            gost_komandda.Text = match.Sopernik;
            Schet_dom_kom.Text = match.SchetDom.ToString();
            schet_gost_kom.Text = match.SchetSop.ToString();
        }
        public void ChangeMatch()
        {
            string Connection = @"Host=localhost;Username=postgres;Password=YngtDrtv276hjkQw8221;Database=HockeyniyClub";
            Npgsql.NpgsqlConnection nc = new Npgsql.NpgsqlConnection(Connection);
            try
            {
                nc.Open();
                Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand("Update public.matchi set data_provedenia = '" + Convert.ToDateTime(data.Text).Year + "-" + Convert.ToDateTime(data.Text).Month + "-" + Convert.ToDateTime(data.Text).Day + "', vremia_nachala = '" + vremia_nachal.Text + "', vremia_konec = '" + vremia_konca.Text + "', kod_domashney_komandi = "+ Convert.ToInt32(komandis[Convert.ToInt32(dom_komanda.SelectedIndex)].id) + ", kod_komandi_gostey = " + Convert.ToInt32(komandis[Convert.ToInt32(gost_komandda.SelectedIndex)].id) + ", schet_domashney_komandi = "+ Convert.ToInt32( Schet_dom_kom.Text)+ ", schet_komandi_sopernika = " + Convert.ToInt32(schet_gost_kom.Text) + " where kod_matcha = " + id, nc);
                int reader = command.ExecuteNonQuery();
                MessageBox.Show("Данные были успешно сохранены");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void getKomandi()
        {
            string Connection = @"Host=localhost;Username=postgres;Password=YngtDrtv276hjkQw8221;Database=HockeyniyClub";
            Npgsql.NpgsqlConnection nc = new Npgsql.NpgsqlConnection(Connection);
            try
            {
                nc.Open();
                Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand("SELECT kod_komandi, nazvanie_komandi FROM public.komandi", nc);
                NpgsqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        komandis.Add(new Komandi { id = reader.GetInt32(0), nazvanie_komandi = reader.GetString(1) });
                    }
                }
                else
                {
                    MessageBox.Show("Такого пользователя не существует");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(a == 1)
            {
                ChangeMatch();

            }
            else
            {
                AddMatch();
            }
        }
    }
}
