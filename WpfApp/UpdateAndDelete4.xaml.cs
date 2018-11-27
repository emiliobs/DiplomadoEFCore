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
using NorthWind.Entities;
using NortWind.DAL;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for UpdateAndDelete4.xaml
    /// </summary>
    public partial class UpdateAndDelete4 : Window
    {
        private NorthWindContext db;
        private Category category;
        public UpdateAndDelete4(Category category, NorthWindContext db)
        {
            InitializeComponent();

            this.db = db;
            this.category = category;

            txtId.Text = category.CategoryId.ToString();
            txtName.Text = category.CategoryName.ToString();

        }

       

        private void BtnUpdate_OnClick(object sender, RoutedEventArgs e)
        {
            category.CategoryName = txtName.Text;
            db.Categories.Update(category);

            var update = db.SaveChanges();

            if (update > 0)
            {
                MessageBox.Show("Los datos fueron actualizados.");
            }
        }

        private void Btndelete_OnClick(object sender, RoutedEventArgs e)
        {
            db.Categories.Remove(category);
            var delete = db.SaveChanges();
            if (delete > 0)
            {
                MessageBox.Show("Los datos fueron eliminados.");
                txtId.Text = string.Empty;
                txtName.Text = string.Empty;

                db.Categories.Update(category);

            }

        }
    }
}
