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

namespace pz_13
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    { 
        Connector db;
    
        public MainWindow()
        {
            db = new Connector();
            InitializeComponent();
                dataGrid.ItemsSource = db.Product.ToList();
        }

        private void dataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ProductItem item = dataGrid.SelectedItem as ProductItem;
            Edit edit = new Edit(item.model,item.maker,item.type);
            edit.Show();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ProductItem item = dataGrid.SelectedItem as ProductItem;
           
                db.Remove(item);
                db.SaveChanges();
                dataGrid.ItemsSource = db.Product.ToList(); 
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (cmb_bx.SelectedIndex)
            {
                case 0:
                    dataGrid.ItemsSource = db.Product.OrderBy(w => w.model).ToList();
                    break;
                case 1:
                    dataGrid.ItemsSource = db.Product.OrderBy(w => w.maker).ToList();
                    break;
                case 2:
                    dataGrid.ItemsSource = db.Product.OrderBy(w => w.type).ToList();
                    break;
            }
            
        }

        private void group_txt_Click(object sender, RoutedEventArgs e)
        {
            var joinQuery = db.Product.AsEnumerable().Join(db.Laptop, product => product.model, laptop => laptop.model,
            (p, l) => new
            {
                model = p.model,
                code = l.CodeID.ToString(),
                marker = p.maker.ToString(),
                price = l.price.ToString(),
            }).ToList();
            dataGrid.ItemsSource = joinQuery;
            foreach(var item in joinQuery)
            {
                price_all_txt.Text = (int.Parse(price_all_txt.Text.ToString())+int.Parse(item.price)).ToString();
            }                               
        }
    }
}
