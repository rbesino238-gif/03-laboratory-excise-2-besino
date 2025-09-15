using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Inventory
{
    public partial class Form1 : Form
    {

        private string _ProductName;
        private string _Category;
        private string _MfgDate;
        private string _ExpDate;
        private string _Description;

        private int _Quantity;
        private double _SellPrice;

        public Form1()
        {
            InitializeComponent();           
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                _ProductName = Product_Name(txtProductName.Text);
                _Category = cbCategory.Text;
                _MfgDate = dtPickerMfgDate.Value.ToString("yyyy-MM-dd");
                _ExpDate = dtPickerExpDate.Value.ToString("yyyy-MM-dd");
                _Description = richTxtDescription.Text;
                _Quantity = Quantity(txtQuantity.Text);
                _SellPrice = SellingPrice(txtSellPrice.Text);
                showProductList.Add(new ProductClass(_ProductName, _Category, _MfgDate,
                _ExpDate, _SellPrice, _Quantity, _Description));
                gridViewProductList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                gridViewProductList.DataSource = showProductList;
            }
            catch () 
            {

            }

                    class NumberFormatException : Exception
        {
            public NumberFormatException(string message) : base(message) { }
        }

        class StringFormatException : Exception
        {
            public StringFormatException(string message) : base(message) { }
        }

        class CurrencyFormatException : Exception
        {
            public CurrencyFormatException(string message) : base(message) { }
        }



        

        public string Product_Name(string name)
        {
            if (!Regex.IsMatch(name, @"^[a-zA-Z]+$"))
                throw new Exception("");
            return name;
        }
        public int Quantity(string qty)
        {
            if (!Regex.IsMatch(qty, @"^[0-9]"))
                throw new Exception("");
            return Convert.ToInt32(qty);
        }
        public double SellingPrice(string price)
        {
            if (!Regex.IsMatch(price.ToString(), @"^(\d*\.)?\d+$"))
                throw new Exception("");
                return Convert.ToDouble(price);
        }
        BindingSource showProductList = new BindingSource();

        private void Form1_Load(object sender, EventArgs e)
        {
            string[] ListOfProductCategory = new string[]
{
        "Beverages",
        "Bread/Bakery",
        "Canned/Jarred Goods",
        "Dairy",
        "Frozen Goods",
        "Meat",
        "Personal Care",
        "Other"
};


            cbCategory.Items.AddRange(ListOfProductCategory);
        }
    }
    }

