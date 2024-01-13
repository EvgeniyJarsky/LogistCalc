namespace LogisticCalcLib.Calc
{
    /// <summary>
    /// Расчет ставки без НДС, которую нужно выставить в АТИ
    /// и максимальной ставки
    /// </summary>
    internal static class CalcPrice
    {
        /// <summary>
        /// Без НДС для АТИ
        /// </summary>
        /// <param name="price">Ставка</param>
        /// <param name="rollBack">Откат</param>
        /// <param name="IsRound">Округлять или нет</param>
        /// <returns></returns>
        public static int NoNDSForATI(int price, int rollBack, int reserve, bool IsRound)
        {
            double rezult = (price - rollBack) / 1.2;
            if (IsRound)
                return ((int)rezult / 1000) * 1000 - reserve;
            else
                return (int)rezult - reserve;
        }

        /// <summary>
        /// С НДС для АТИ
        /// </summary>
        /// <param name="price">Ставка</param>
        /// <param name="rollBack">Откат</param>
        /// <param name="IsRound">Округлять или нет</param>
        /// <returns></returns>
        public static int WithNDSForATI(int price, int rollBack, bool IsRound)
        {
            double rezult = (price - rollBack) - (price - rollBack) * 0.1;
            if (IsRound)
                return ((int)rezult / 1000) * 1000;
            else
                return (int)rezult;
        }

        /// <summary>
        /// Максимальная ставка без НДС
        /// </summary>
        /// <param name="price">Ставка</param>
        /// <param name="rollBack">Откат</param>
        /// <param name="IsRound">Округлять или нет</param>
        /// <returns></returns>
        public static int NoNDSMax(int price, int rollBack, bool IsRound)
        {
            double rezult = (price - rollBack) / 1.2;
            if (IsRound)
                return ((int)rezult / 1000) * 1000;
            else
                return (int)rezult;
        }

        /// <summary>
        /// Максимальная ставка с НДС
        /// </summary>
        /// <param name="price">Ставка</param>
        /// <param name="rollBack">Откат</param>
        /// <param name="IsRound">Округлять или нет</param>
        /// <returns></returns>
        public static int WithNDSMax(int price, int rollBack, bool IsRound)
        {
            double rezult = (price - rollBack) - (price - rollBack) * 0.1;
            if (IsRound)
                return ((int)rezult / 1000) * 1000;
            else
                return (int)rezult;
        }
    }
}
