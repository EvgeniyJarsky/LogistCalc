using System.Security.Principal;
using System.Xml.Serialization;
using System;
using System.Transactions;
using System.Text;
using System.Reflection.Metadata;
using System.Windows; // Window, RoutedEventArgs, MessageBox

namespace SDKSample
{
    public partial class AWindow : Window
    {
        public AWindow()
        {
            // InitializeComponent call is required to merge the UI
            // that is defined in markup with this class, including  
            // setting properties and registering event handlers
            InitializeComponent();
            countPrice();  
            
        }

        
        void calc(object sender, RoutedEventArgs e)
        {
            countPrice();  
        }

        void but0(object sender, RoutedEventArgs e)
        {
            string pv = PriceValue.Text;
            int delta = -1000;
            PriceValue.Text = countVal(pv, delta, 30000);
            countPrice();  
        }

        void but1(object sender, RoutedEventArgs e)
        {
            string pv = PriceValue.Text;
            int delta = 1000;
            PriceValue.Text = countVal(pv, delta, 30000);
            countPrice();  
        }

        void but2(object sender, RoutedEventArgs e)
        {
            string commis = Сommision.Text;
            int delta = -1000;
            Сommision.Text = countVal(commis, delta, 1000);
            countPrice();  
        }

        void but3(object sender, RoutedEventArgs e)
        {
            string commis = Сommision.Text;
            int delta = 1000;
            Сommision.Text = countVal(commis, delta, 1000);
            countPrice();         
        }


        bool isDigit(string val)
            {
                int maximmalValue = 1000000;
                int minimumValue = 0;
                int i = 0;
                bool rez = int.TryParse(val, out i);
                return rez;
            }

        int StrToInt(string val)
            {
                int x = 0;
                if (Int32.TryParse(val, out x))
                    {
                        return x;
                    }
                return -100000;
            }

        string countVal(string val, int delta, int defaultVal)
        {
            if (isDigit(val) == true)
            {
                int int_commis = StrToInt(val);
                int rez = int_commis + delta;
                return rez.ToString();
            }
            else
                {
                MessageBox.Show("Введите целое число");
                return defaultVal.ToString();
                }
        }

        void countPrice()
        {
            string price = PriceValue.Text;
            string commis = Сommision.Text;
            int priceWithNDS_ = 0;
            int priceWithoutNDS_ = 0;
            int priceWithNDS = 0;
            int priceWithoutNDS = 0;

            if (isDigit(price) & isDigit(commis))
            {
                int price_ = StrToInt(price);
                int commis_ = StrToInt(commis);

                priceWithNDS_ = Convert.ToInt32(Math.Round((price_ - commis_) - ((price_ - commis_)*0.1)));
                priceWithoutNDS_ = Convert.ToInt32(Math.Round((price_ - commis_)/1.2));
            }
            if (checkBox1.IsChecked == true)
                {
                    // 2666/100=26.6
                    // 26.6 to int 
                    // 26 * 100
                    priceWithNDS = (Convert.ToInt32(priceWithNDS_/1000))*1000;
                    priceWithoutNDS = (Convert.ToInt32(priceWithoutNDS_/1000))*1000;
                }
            else
                {
                    priceWithNDS = priceWithNDS_;
                    priceWithoutNDS = priceWithoutNDS_;
                }
            label1.Text = priceWithNDS.ToString();
            label2.Text = priceWithNDS.ToString();
            label3.Text = (priceWithoutNDS-1000).ToString();
            label4.Text = priceWithoutNDS.ToString();
            }
        


        private void checkboxChecked(Object sender, RoutedEventArgs e)
        {
           string l1 = label1.Text;
           string l2 = label2.Text;
           string l3 = label3.Text;
           string l4 = label4.Text;
        }


        private void checkboxUnchecked(Object sender, RoutedEventArgs e)
        {
           string l1 = label1.Text;
           string l2 = label2.Text;
           string l3 = label3.Text;
           string l4 = label4.Text;
           
        }
    }
}