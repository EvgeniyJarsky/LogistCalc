using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;


namespace LogisticCalcLib
{
    /// <summary>
    /// Главная модель
    /// </summary>
    public class MainModel : INotifyPropertyChanged
    {
        /// <summary>
        /// Начальная ставка 
        /// </summary>
        /// 
        private int price = 30000;
        public int Price
        {
            get => price;
            set
            {
                price = value;
                OnPropertyChanged("Price");
            }
        }

        /// <summary>
        /// Откат
        /// </summary>
        private int rollBack = 1000;
        public int RollBack
        {
            get { return rollBack; }
            set
            {
                rollBack = value;
                OnPropertyChanged("RollBack");
            }
        }

        /// <summary>
        /// округлять расчет или нет
        /// </summary>
        private bool roundUp = false;
        public bool RoundUp
        {
            get { return roundUp; }
            set
            {
                roundUp = value;
                OnPropertyChanged("RoudUp");
            }
        }

        /// <summary>
        /// Запас
        /// </summary>
        private int reserve = 2000;
        public int Reserve
        {
            get { return reserve; }
            set
            {
                reserve = value;
                OnPropertyChanged("Reserve");
            }
        }

        /// <summary>
        /// Цена для выкладывания в АТИ с НДС
        /// </summary>
        private int priceForATIWithRate = 0;
        public int PriceForATIWithRate
        {
            get { return priceForATIWithRate; }
            set
            {
                priceForATIWithRate = value;
                OnPropertyChanged("PriceForATIWithRate");
            }
        }

        /// <summary>
        /// Цена для выкладывания в АТИ без НДС
        /// </summary>
        private int priceForATIWithOutRate = 0;
        public int PricengForATIWithOutRate
        {
            get { return priceForATIWithOutRate; }
            set
            {
                priceForATIWithOutRate = value;
                OnPropertyChanged("PricengForATIWithOutRate");
            }
        }

        /// <summary>
        /// Максимальная цена с НДС
        /// </summary>
        private int maxPriceWithRate = 0;
        public int MaxPriceWithRate
        {
            get { return maxPriceWithRate; }
            set
            {
                maxPriceWithRate = value;
                OnPropertyChanged("MaxPriceWithRate");
            }
        }

        /// <summary>
        /// Максимальная цена без НДС
        /// </summary>
        private int maxPriceWithOutRate = 0;
        public int MaxPriceWithOutRate
        {
            get { return maxPriceWithOutRate; }
            set
            {
                maxPriceWithOutRate = value;
                OnPropertyChanged("MaxPriceWithOutRate");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="price">Ставка - целое число</param>
        /// <param name="rollBack">Откат - целое число</param>
        /// <param name="roundUp">Округлять до числа кратного 100 или нет </param>
        public MainModel(string price, string rollBack, bool roundUp)
        {
            #region Проверка ставки
            if (price == null)
                throw new ArgumentNullException("Ставка не может быть NULL", nameof(price));
            if (!int.TryParse(price, out int result))
                throw new ArgumentException("Ошибка преобразования ставки в целое число", nameof(price));
            if (result < 0)
                throw new NegativeValueException("Ставка не может быть отрицательной", nameof(result));
            #endregion
            Price = result;

            #region Проверка отката
            if (rollBack == null)
                throw new ArgumentNullException("Ставка не может быть NULL", nameof(rollBack));
            if (!int.TryParse(rollBack, out int result2))
                throw new ArgumentException("Ошибка преобразования отката в целое число", nameof(rollBack));
            if (result < 0)
                throw new NegativeValueException("Откат не может быть отрицательным", nameof(result));
            #endregion
            RollBack = result2;

            this.RoundUp = roundUp;

            this.PriceForATIWithRate = Calc.CalcPrice.WithNDSForATI(this.Price, this.RollBack, roundUp);
            this.PricengForATIWithOutRate = Calc.CalcPrice.NoNDSForATI(this.Price, this.RollBack, this.Reserve, roundUp);

            this.MaxPriceWithRate = Calc.CalcPrice.WithNDSMax(this.Price, this.RollBack, roundUp);
            this.MaxPriceWithOutRate = Calc.CalcPrice.NoNDSMax(this.Price, this.RollBack, roundUp);
        }

        ////////////////////////////////////////////////////////////////////////////

        /// <summary>
        /// Увеличить запас
        /// </summary>
        /// <param name="val">на сколько увеличиваем запас</param>
        public void IncreaseReserve(int val)
        {
            this.Reserve += val;

            this.PriceForATIWithRate = Calc.CalcPrice.WithNDSForATI(this.Price, this.RollBack, this.RoundUp);
            this.PricengForATIWithOutRate = Calc.CalcPrice.NoNDSForATI(this.Price, this.RollBack, this.Reserve, this.RoundUp);

            this.MaxPriceWithRate = Calc.CalcPrice.WithNDSMax(this.Price, this.RollBack, this.RoundUp);
            this.MaxPriceWithOutRate = Calc.CalcPrice.NoNDSMax(this.Price, this.RollBack, this.RoundUp);
        }

        /// <summary>
        /// Уменьшить запас
        /// </summary>
        /// <param name="val">на сколько уменьшаем запас</param>
        public void DecreaseReserve(int val)
        {
            this.Reserve -= val;

            this.PriceForATIWithRate = Calc.CalcPrice.WithNDSForATI(this.Price, this.RollBack, this.RoundUp);
            this.PricengForATIWithOutRate = Calc.CalcPrice.NoNDSForATI(this.Price, this.RollBack, this.Reserve, this.RoundUp);

            this.MaxPriceWithRate = Calc.CalcPrice.WithNDSMax(this.Price, this.RollBack, this.RoundUp);
            this.MaxPriceWithOutRate = Calc.CalcPrice.NoNDSMax(this.Price, this.RollBack, this.RoundUp);
        }


        //////////////////////////////////////////////////////////////////////////////

        /// <summary>
        /// Увеличить ставку
        /// </summary>
        /// <param name="val">на сколько увеличиваем ставку</param>
        public void IncreaseBid(int val)
        {
            this.Price += val;

            this.PriceForATIWithRate = Calc.CalcPrice.WithNDSForATI(this.Price, this.RollBack, this.RoundUp);
            this.PricengForATIWithOutRate = Calc.CalcPrice.NoNDSForATI(this.Price, this.RollBack, this.Reserve, this.RoundUp);

            this.MaxPriceWithRate = Calc.CalcPrice.WithNDSMax(this.Price, this.RollBack, this.RoundUp);
            this.MaxPriceWithOutRate = Calc.CalcPrice.NoNDSMax(this.Price, this.RollBack, this.RoundUp);
        }

        /// <summary>
        /// Уменьшить ставку
        /// </summary>
        /// <param name="val">на сколько уменьшаем ставку</param>
        public void DecreaseBid(int val)
        {
            this.Price -= val;

            this.PriceForATIWithRate = Calc.CalcPrice.WithNDSForATI(this.Price, this.RollBack, this.RoundUp);
            this.PricengForATIWithOutRate = Calc.CalcPrice.NoNDSForATI(this.Price, this.RollBack, this.Reserve, this.RoundUp);

            this.MaxPriceWithRate = Calc.CalcPrice.WithNDSMax(this.Price, this.RollBack, this.RoundUp);
            this.MaxPriceWithOutRate = Calc.CalcPrice.NoNDSMax(this.Price, this.RollBack, this.RoundUp);
        }

        /// <summary>
        /// Увеличить откат
        /// </summary>
        /// <param name="val">на сколько увеличиваем откат</param>
        public void IncreaseRollBack(int val)
        {
            this.RollBack += val;

            this.PriceForATIWithRate = Calc.CalcPrice.WithNDSForATI(this.Price, this.RollBack, this.RoundUp);
            this.PricengForATIWithOutRate = Calc.CalcPrice.NoNDSForATI(this.Price, this.RollBack, this.Reserve, this.RoundUp);

            this.MaxPriceWithRate = Calc.CalcPrice.WithNDSMax(this.Price, this.RollBack, this.RoundUp);
            this.MaxPriceWithOutRate = Calc.CalcPrice.NoNDSMax(this.Price, this.RollBack, this.RoundUp);
        }

        /// <summary>
        /// Уменьшить откат
        /// </summary>
        /// <param name="val">на сколько уменьшаем откат</param>
        public void DecreaseRollBack(int val)
        {
            this.RollBack -= val;

            this.PriceForATIWithRate = Calc.CalcPrice.WithNDSForATI(this.Price, this.RollBack, this.RoundUp);
            this.PricengForATIWithOutRate = Calc.CalcPrice.NoNDSForATI(this.Price, this.RollBack, this.Reserve, this.RoundUp);

            this.MaxPriceWithRate = Calc.CalcPrice.WithNDSMax(this.Price, this.RollBack, this.RoundUp);
            this.MaxPriceWithOutRate = Calc.CalcPrice.NoNDSMax(this.Price, this.RollBack, this.RoundUp);
        }

        /// <summary>
        /// Изменить параметр - округлять или нет
        /// </summary>
        public void ChangeRoundUp()
        {
            if (this.RoundUp)
                this.RoundUp = false;
            else
                this.RoundUp = true;

            this.PriceForATIWithRate = Calc.CalcPrice.WithNDSForATI(this.Price, this.RollBack, this.RoundUp);
            this.PricengForATIWithOutRate = Calc.CalcPrice.NoNDSForATI(this.Price, this.RollBack, this.Reserve, this.RoundUp);

            this.MaxPriceWithRate = Calc.CalcPrice.WithNDSMax(this.Price, this.RollBack, this.RoundUp);
            this.MaxPriceWithOutRate = Calc.CalcPrice.NoNDSMax(this.Price, this.RollBack, this.RoundUp);
        }


    }

}
