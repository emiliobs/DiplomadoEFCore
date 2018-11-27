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
using NorthWind.Entities;
using NortWind.DAL;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private NorthWindContext db;

        public MainWindow()
        {
            InitializeComponent();

            db = new NorthWindContext();

            LoadCategories();
        }

        private void BtnCreate_OnClick(object sender, RoutedEventArgs e)
        {
            var newCategory = new Category()
            {
                CategoryName = txtName.Text,  
            };

            db.Categories.Add(newCategory);

            var records = db.SaveChanges();
            if (records == 0)
            {
                MessageBox.Show("Los datos no fueron guardados");
            }

              LoadCategories();

        }

        void LoadCategories()
        {
            var categories = db.Categories.ToList();



            DGCategprias.ItemsSource = categories;
        }

        private void DGCategprias_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var categorySelect = DGCategprias.SelectedItem as Category;
            UpdateAndDelete4 windows = new UpdateAndDelete4(categorySelect, db);
            windows.ShowDialog();
        }

        private void BtnUpdateData_OnClick(object sender, RoutedEventArgs e)
        {
           LoadCategories();
        }
    }
}
