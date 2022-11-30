using System.Windows;

using System.Configuration;
using System.Collections.Specialized;
using System.ComponentModel;

namespace WpfUserInterface
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        LogisticCalcLib.MainModel model = new LogisticCalcLib.MainModel("36000", "1000", true);

        public MainWindow()
        {
            // var d = ConfigurationManager.AppSettings["key0"];

            InitializeComponent();

            this.Closing += MainWindow_Closing;

            // Цена для АТИ
            PriceForAti.Text = ConfigurationManager.AppSettings["atiPrice"];
            // Макс. цена
            MaxPrice.Text = ConfigurationManager.AppSettings["maxPrice"];
            // Рассчитать ставку
            count.Content = ConfigurationManager.AppSettings["countPrice"];
            // Ставка с НДС
            labelNDS.Content = ConfigurationManager.AppSettings["bidWithRate"];
            // Ставка без НДС
            labelNoNDS.Content = ConfigurationManager.AppSettings["bidWithOutRate"];
            
            // Ставка 36000
            Price.Text = ConfigurationManager.AppSettings["price"];
            // Откат 1000
            RollBack.Text = ConfigurationManager.AppSettings["rollBack"];
        }

        /// <summary>
        /// Общая кнопка "Расчитать"
        /// </summary>
        private void Calc(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(Price.Text, out var price))
            {
                model.Price = price;
                if (int.TryParse(RollBack.Text, out var rollBack))
                    model.RollBack = rollBack;
                else
                {
                    MessageBox.Show("Введите корректный откат");
                    return;
                }
            }
            else 
            {
                MessageBox.Show("Введите корректную ставку");
                return;
            }

            model.DecreaseBid(0);

            PriceForAtiWithNDS.Text = model.PriceForATIWithRate.ToString();
            PriceForAtiNoNDS.Text = model.PricengForATIWithOutRate.ToString();

            MaxPriceForAtiWithNDS.Text = model.MaxPriceWithRate.ToString();
            MaxPriceForAtiNoNDS.Text = model.MaxPriceWithOutRate.ToString();
        }

        /// <summary>
        /// Кнопка "Повысить ставку"
        /// </summary>
        private void IncreaseBidBut(object sender, RoutedEventArgs e)
        {
            model.IncreaseBid(1000);

            Price.Text = model.Price.ToString();

            PriceForAtiWithNDS.Text = model.PriceForATIWithRate.ToString();
            PriceForAtiNoNDS.Text = model.PricengForATIWithOutRate.ToString();

            MaxPriceForAtiWithNDS.Text = model.MaxPriceWithRate.ToString();
            MaxPriceForAtiNoNDS.Text = model.MaxPriceWithOutRate.ToString();
        }

        /// <summary>
        /// Кнопка "Понизить ставку"
        /// </summary>
        private void DecreaseBidBut(object sender, RoutedEventArgs e)
        {
            model.DecreaseBid(1000);

            Price.Text = model.Price.ToString();

            PriceForAtiWithNDS.Text = model.PriceForATIWithRate.ToString();
            PriceForAtiNoNDS.Text = model.PricengForATIWithOutRate.ToString();

            MaxPriceForAtiWithNDS.Text = model.MaxPriceWithRate.ToString();
            MaxPriceForAtiNoNDS.Text = model.MaxPriceWithOutRate.ToString();
        }

        /// <summary>
        /// Кнопка "Повысить откат"
        /// </summary>
        private void IncreaseRollBackBut(object sender, RoutedEventArgs e)
        {
            model.IncreaseRollBack(1000);

            RollBack.Text = model.RollBack.ToString();

            PriceForAtiWithNDS.Text = model.PriceForATIWithRate.ToString();
            PriceForAtiNoNDS.Text = model.PricengForATIWithOutRate.ToString();

            MaxPriceForAtiWithNDS.Text = model.MaxPriceWithRate.ToString();
            MaxPriceForAtiNoNDS.Text = model.MaxPriceWithOutRate.ToString();
        }

        /// <summary>
        /// Кнопка "Понизить откат"
        /// </summary>
        private void DecreaseRollBackBut(object sender, RoutedEventArgs e)
        {
            model.DecreaseRollBack(1000);

            RollBack.Text = model.RollBack.ToString();

            PriceForAtiWithNDS.Text = model.PriceForATIWithRate.ToString();
            PriceForAtiNoNDS.Text = model.PricengForATIWithOutRate.ToString();

            MaxPriceForAtiWithNDS.Text = model.MaxPriceWithRate.ToString();
            MaxPriceForAtiNoNDS.Text = model.MaxPriceWithOutRate.ToString();
        }

        private void ChekedRound(object sender, RoutedEventArgs e)
        {
            model.ChangeRoundUp();
            //model.ChangeRoundUp();

            PriceForAtiWithNDS.Text = model.PriceForATIWithRate.ToString();
            PriceForAtiNoNDS.Text = model.PricengForATIWithOutRate.ToString();

            MaxPriceForAtiWithNDS.Text = model.MaxPriceWithRate.ToString();
            MaxPriceForAtiNoNDS.Text = model.MaxPriceWithOutRate.ToString();

        }
        
        private void CheckNoRound(object sender, RoutedEventArgs e)
        {
            model.ChangeRoundUp();
            //model.ChangeRoundUp();

            PriceForAtiWithNDS.Text = model.PriceForATIWithRate.ToString();
            PriceForAtiNoNDS.Text = model.PricengForATIWithOutRate.ToString();

            MaxPriceForAtiWithNDS.Text = model.MaxPriceWithRate.ToString();
            MaxPriceForAtiNoNDS.Text = model.MaxPriceWithOutRate.ToString();

        }

        /// <summary>
        /// Событие закрытия окна
        /// </summary>
        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            
            
            config.AppSettings.Settings["price"].Value = Price.Text;
            config.AppSettings.Settings["rollBack"].Value = RollBack.Text;

            config.Save();
            ConfigurationManager.RefreshSection("appSettings");

            //MessageBox.Show("Closing called");
        }
    }
}
