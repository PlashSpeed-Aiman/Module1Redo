using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace Module1Redo.Model
{
    public class Order
    {
        private List<OrderDetail> orderDetailList;

        public List<OrderDetail> OrderDetailList
        {
            get { return orderDetailList; }
            set { orderDetailList = value; }
        }


    }
    public class Item
    {
        public Item(string id,string name,string description,int price)
        {

        }
        public Item()
        {
            Random _random = new Random();
            _id = _random.Next(0,10000).ToString();
             
        }
        public override string ToString()
        {
            return Id;
        }
        private string _id ="default";
        private string _name="default";
        private string _description;
        private string _price;
        public string Id { get { return _id; } set { _id = value; } }
        public string Name { get { return _name; } set { _name = value; } }

        public string Description { get { return _description; } }
    }
    public class OrderDetail:INotifyPropertyChanged
    {
        private int _quantity;

        private Item _item;
        private string _id;

        public event PropertyChangedEventHandler PropertyChanged;
        private void onPropertyChanged(object sender, string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                PropertyChanged(sender, new PropertyChangedEventArgs(propertyName));
            }
        }

        public OrderDetail(object selectedItem)
        {
            SelectedItem = selectedItem;
        }

        public OrderDetail(Item selectedItem, int quantity, string id)
        {
            _item = selectedItem;
            Quantity = quantity;
            _id = selectedItem.Id;
        }
        public override string ToString()
        {
            onPropertyChanged(this, "OrderDetail");
            return Quantity.ToString();
        }
        public int Quantity { get { return (int)_quantity;} set {
                _quantity = value;
                onPropertyChanged(this, "OrderDetail");
            } }
        public Item Item { get { return _item; } set { _item = value; } }
        public string id { get { return _id; } }
        public object SelectedItem { get; }
    }
}
