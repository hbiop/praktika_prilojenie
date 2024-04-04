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
    public class Pozicii
    {
        public int id { get; set; }
        public string name { get; set; }

    }
    
    public class Komandi
    {
        public int id { get; set; }
        public string nazvanie_komandi { get; set; }

    }
    /// <summary>
    /// Логика взаимодействия для izmenenie_igroka.xaml
    /// </summary>
    public partial class izmenenie_igroka : Window
    {
        int ind;
        int a = -1;
        List<Pozicii> poziciis = new List<Pozicii>();
        List<Komandi> komandi = new List<Komandi>();
        public int id_i;
        public izmenenie_igroka()
        {
            getMaxInd();
            InitializeComponent();
            getRoli();
            getKomandi();
            pozicia.ItemsSource = poziciis;
            pozicia.DisplayMemberPath = "name";
            komanda.ItemsSource = komandi;
            komanda.DisplayMemberPath = "nazvanie_komandi";
            a = 0;
        }
        public izmenenie_igroka(MyItem igrok)
        {
            a = 1;
            getRoli();
            getKomandi();
            InitializeComponent();
            id_i = igrok.id;
            name.Text = igrok.Name;
            familia.Text = igrok.Familia;
            otchestvo.Text = igrok.Otchestvo;
            nomer.Text = igrok.NomerIgroka.ToString();
            data.Text = igrok.DataRojdenia.ToString();
            pozicia.ItemsSource = poziciis;
            pozicia.DisplayMemberPath = "name";
            pozicia.Text = igrok.Pozicia.ToString();
            komanda.ItemsSource = komandi;
            komanda.DisplayMemberPath = "nazvanie_komandi";
            komanda.Text = igrok.Komanda.ToString();
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
                        komandi.Add(new Komandi { id = reader.GetInt32(0), nazvanie_komandi = reader.GetString(1) });
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
        public void Change()
        {
            string Connection = @"Host=localhost;Username=postgres;Password=YngtDrtv276hjkQw8221;Database=HockeyniyClub";
            Npgsql.NpgsqlConnection nc = new Npgsql.NpgsqlConnection(Connection);
            try
            {
                nc.Open();
                Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand("Update public.igroki set imia = '" + name.Text+"', familia = '" + familia.Text +"', otchestvo = '"+ otchestvo.Text+ "', nomer_igroka = "+ Convert.ToInt32(nomer.Text)+ ", data_rojdenia = '" + Convert.ToDateTime(data.Text).Year + "-" + Convert.ToDateTime(data.Text).Month + "-" + Convert.ToDateTime(data.Text).Day  + "', pozicia_igroka = "+ Convert.ToInt32(poziciis[Convert.ToInt32(pozicia.SelectedIndex)].id) + ", kod_komandi = " + Convert.ToInt32(komandi[Convert.ToInt32(komanda.SelectedIndex)].id) + " where kod_igroka = " + id_i, nc);
                int reader = command.ExecuteNonQuery();
                MessageBox.Show("Данные были успешно сохранены");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
       
        public void getRoli()
        {
            string Connection = @"Host=localhost;Username=postgres;Password=YngtDrtv276hjkQw8221;Database=HockeyniyClub";
            Npgsql.NpgsqlConnection nc = new Npgsql.NpgsqlConnection(Connection);
            try
            {
                nc.Open();
                Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand("SELECT * FROM public.pozicia_igroka", nc);
                NpgsqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        poziciis.Add(new Pozicii { id = reader.GetInt32(0), name = reader.GetString(1) });
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
        public void getMaxInd()
        {
            ind = -1;
            string Connection = @"Host=localhost;Username=postgres;Password=YngtDrtv276hjkQw8221;Database=HockeyniyClub";
            Npgsql.NpgsqlConnection nc = new Npgsql.NpgsqlConnection(Connection);
            try
            {
                nc.Open();
                Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand("select max(kod_igroka) + 1 from public.igroki", nc);
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
        public void Add()
        {
            string Connection = @"Host=localhost;Username=postgres;Password=YngtDrtv276hjkQw8221;Database=HockeyniyClub";
            Npgsql.NpgsqlConnection nc = new Npgsql.NpgsqlConnection(Connection);
            try
            {
                nc.Open();
                Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand("INSERT INTO public.igroki values (" + ind +", '" + name.Text + "','" + familia.Text+ "','" + otchestvo.Text + "'," + Convert.ToInt32(nomer.Text) + ",'" + Convert.ToDateTime(data.Text).Year + "-" + Convert.ToDateTime(data.Text).Month + "-" + Convert.ToDateTime(data.Text).Day + "', " + Convert.ToInt32(poziciis[Convert.ToInt32(pozicia.SelectedIndex)].id) + ", " + Convert.ToInt32(komandi[Convert.ToInt32(komanda.SelectedIndex)].id) + ") ", nc);
                int i = command.ExecuteNonQuery();
                MessageBox.Show("Данные были успешно сохранены");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void Button_Change(object sender, RoutedEventArgs e)
        {
            if(a == 1)
            {
                Change();
            }
            else
            {
                Add();
            }
        }
    }
}
