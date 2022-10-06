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
    /// Interaction logic for UpdatePage.xaml
    /// </summary>
    public partial class UpdatePage : Window
    {
        wpfCrudEntities _db = new wpfCrudEntities();
        int Id;

        public UpdatePage(int citizenId)
        {
            InitializeComponent();
            Id = citizenId;
        }

        private void updateBtn_Click(object sender, RoutedEventArgs e)
        {
            citizen updateCitizen = (from m in _db.citizens
                                  where m.id == Id
                                  select m).Single();
            updateCitizen.name = nametextBox.Text;
            updateCitizen.ageGroup = ageGroupcomboBox.Text;
            _db.SaveChanges();
            MainWindow.datagrid.ItemsSource = _db.citizens.ToList();
            this.Hide();
        }
    }
}
