using hockeyniy_club.screens;
using Npgsql;
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

namespace hockeyniy_club
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int? id = null;
            string Connection = @"Host=localhost;Username=postgres;Password=YngtDrtv276hjkQw8221;Database=HockeyniyClub";
            Npgsql.NpgsqlConnection nc = new Npgsql.NpgsqlConnection(Connection);
            try
            {
                nc.Open();
                Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand("SELECT kod_roli FROM public.authentifikacia where authentifikacia.login = '"+ login.Text.Trim() + "' and authentifikacia.parol = '"+ parol.Text.Trim()+"'", nc);
                NpgsqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        id = reader.GetInt32(0);
                    }
                    if (id != null)
                    {
                        switch (id)
                        {
                            case 1:
                                admin admin = new admin();
                                admin.Show();
                                Close();
                                break;
                            case 2:
                                igrok igrok = new igrok();
                                igrok.Show();
                                Close();
                                break;
                            case 3:
                                polzovatel polzovatel = new polzovatel();
                                polzovatel.Show();
                                Close(); 
                                break;
                            case 4:
                                trener trener = new trener();
                                trener.Show();
                                Close();
                                break;
                        }
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
    }
}