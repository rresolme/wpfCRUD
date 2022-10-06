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

namespace WpfEntityCRUD
{
    /// <summary>
    /// Interaction logic for InsertPage.xaml
    /// </summary>
    public partial class InsertPage : Window
    {
        wpfCrudEntities _db = new wpfCrudEntities();

        public InsertPage()
        {
            InitializeComponent();
        }

        private void insertBtn_Click(object sender, RoutedEventArgs e)
        {
            citizen newCitizen = new citizen()
            {
                name = nametextBox.Text,
                ageGroup = ageGroupcomboBox.Text
            };

            _db.citizens.Add(newCitizen);
            _db.SaveChanges();
            MainWindow.datagrid.ItemsSource = _db.citizens.ToList();
            this.Hide();
        }
    }
}
