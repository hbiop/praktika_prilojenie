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
    /// <summary>
    /// Логика взаимодействия для admin.xaml
    /// </summary>
    public partial class admin : Window
    {
        public admin()
        {
            InitializeComponent();            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            spisok_igroki spisok_Igroki = new spisok_igroki();
            spisok_Igroki.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            matchi matchi = new matchi();
            matchi.Show();
        }
    }
}
