﻿using System;
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

namespace WpfEntityCRUD
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        wpfCrudEntities _db = new wpfCrudEntities();
        public static DataGrid datagrid;

        public MainWindow()
        {
            InitializeComponent();
            Load();
        }

        private void Load()
        {
            myDataGrid.ItemsSource = _db.citizens.ToList();
            datagrid = myDataGrid;
        }

        private void insertBtn_Click(object sender, RoutedEventArgs e)
        {
            InsertPage Ipage = new InsertPage();
            Ipage.ShowDialog();
        }

        private void updateBtn_Click(object sender, RoutedEventArgs e)
        {
            int Id = 0;

            if(myDataGrid.SelectedItem != null)
            {
                Id = (myDataGrid.SelectedItem as citizen).id;
                UpdatePage Upage = new UpdatePage(Id);
                Upage.ShowDialog();
            }           
        }

        private void deleteBtn_Click(object sender, RoutedEventArgs e)
        {
            int Id = (myDataGrid.SelectedItem as citizen).id;
            var deleteCitizen = _db.citizens.Where(m => m.id == Id).Single();
            _db.citizens.Remove(deleteCitizen);
            _db.SaveChanges();
            myDataGrid.ItemsSource = _db.citizens.ToList();
        }
    }
}