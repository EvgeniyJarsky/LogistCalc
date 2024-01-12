using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace LogisticCalcLib
{
    /// <summary>
    /// Второстепенная модель
    /// </summary>
    public class SecondModel
    {
        public int Price {  get; set; } 

        public int RollBack {  get; set; }

        public bool RoundUp {  get; set; }

        public int Reserve {  get; set; }
        
        public int PriceForATIWithRate {  get; set; }

        public int PricengForATIWithOutRate {  get; set; }

        public int MaxPriceWithRate {  get; set; }

        public int MaxPriceWithOutRate { get; set; }


    }
}
