using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
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

namespace Module1Redo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int counter = 0;
        private List<Model.Item> itemList;
        ObservableCollection<Model.OrderDetail> itemList2;
        public MainWindow()
        {
            
            InitializeComponent();
            joust.Text = counter.ToString();
            itemList = new List<Model.Item>();
            itemList2 = new ObservableCollection<Model.OrderDetail>();
            for(int i = 0; i < 5; i++)
            {
                itemList.Add(new Model.Item());
            }
            ItemList2.ItemsSource = itemList;
            ItemList3.ItemsSource = itemList2;
           
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            counter--;
            joust.Text = counter.ToString();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            counter++; 
            joust.Text = counter.ToString();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)

        {
            
            if (ItemList3.Items.IsEmpty)
            {
                Console.WriteLine("test");
                if (Int32.Parse(joust.Text) != 0)
                {
                    var item = ItemList2.SelectedItem as Model.Item;
                    itemList2.Add(new Model.OrderDetail(item, Int32.Parse(joust.Text),item.Id));
                }
                
            }
            else if(!ItemList3.Items.IsEmpty)
            {
                Trace.WriteLine("text");
                var item1 = ItemList2.SelectedItem as Model.Item;
                var index = from item in itemList2 where item.id.Contains(item1.Id) select itemList2.IndexOf(item);
                
                if (index.Any())
                {
                    var result = index.First();
                    Trace.WriteLine(result);
                    if (result != -1)
                    {
                        itemList2[result].Quantity += int.Parse(joust.Text);
                       
                    }
                    
                }
                else
                {
                    itemList2.Add(new Model.OrderDetail(item1, Int32.Parse(joust.Text), item1.Id));
                }
                

            }
           
        }
        private void OnSelected(object sender, RoutedEventArgs e)
        {
            ListBox lol = sender as ListBox;
            var splat = lol.SelectedItem as Model.OrderDetail;
            quantityBox.Text = splat.Quantity.ToString();
        }

        private void TextBlock_SourceUpdated(object sender, DataTransferEventArgs e)
        {

        }
    }
}
