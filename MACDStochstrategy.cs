#region Using declarations
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Xml.Serialization;
using NinjaTrader.Cbi;
using NinjaTrader.Data;
using NinjaTrader.Indicator;
using NinjaTrader.Gui.Chart;
using NinjaTrader.Strategy;
#endregion

// This namespace holds all strategies and is required. Do not change it.
namespace NinjaTrader.Strategy
{
    /// <summary>
    /// DIstrategy
    /// </summary>
    [Description("Stochstrategy")]
    public class DIstrategy : Strategy
    {
        #region Variables
        // Wizard generated variables
        private int myInput0 = 1; // Default setting for MyInput0
        private int longt = 0;
        private int shortt = 0;
        private double ll = 0;
        private double hh = 0;
        private double target = 0;
        private double stop = 0;
        //private double targett = 0;  //determines if trade is a target trade or not?

        // User defined variables (add any user defined variables below)
        #endregion

        /// <summary>
        /// This method is used to configure the strategy and is called once before any strategy method is called.
        /// </summary>
        protected override void Initialize()
        {
            CalculateOnBarClose = true;
        }

        /// <summary>
        /// Called on each bar update event (incoming tick)
        /// </summary>
        protected override void OnBarUpdate()
        {
            //add conditions so stops and targets are only activated under certain conditions?
            /*
            if ((Close[0] > stop) & (Position.Quantity.ToString() != "0") & (shortt == 1))
            {
                //Print(Position.GetProfitLoss(Close[0], PerformanceUnit.Currency));
                shortt = 0;
                ExitShort(1);

            }

            if ((Close[0] < stop) & (Position.Quantity.ToString() != "0") & (longt == 1))
            {
                //Print(Position.GetProfitLoss(Close[0], PerformanceUnit.Currency));
                longt = 0;
                ExitLong(1);
            }


            if ((Close[0] < target) & (Position.Quantity.ToString() != "0") & (shortt == 1))
            {
                //Print(Position.GetProfitLoss(Close[0], PerformanceUnit.Currency));
                shortt = 0;
                ExitShort(1);

            }

            if ((Close[0] > target) & (Position.Quantity.ToString() != "0") & (longt == 1))
            {
                //Print(Position.GetProfitLoss(Close[0], PerformanceUnit.Currency));
                longt = 0;
                ExitLong(1);
            }
            */

            //K blue  D red in NT   "CrossAbove()" or "CrossBelow()"
            //if (DM(14)[0] < 20)
            //{
            
            //if ((Stochastics(3, 14, 3).K[0] > Stochastics(3, 14, 3).D[0]) & (Stochastics(3, 14, 3).K[1] < Stochastics(3, 14, 3).D[1]) & (Stochastics(3, 14, 3).K[1] < 20))
            if ((Stochastics(3, 14, 3).K[1] < 20) & (Stochastics(3, 14, 3).K[0] > 20))
            {
                
                if ((Position.Quantity.ToString() != "0") & (shortt == 1))
                {
                    shortt = 0;
                    ExitShort(myInput0);
                    //ExitShort(500);
                }
                 

                if (MACD(12, 26, 9)[0] > 0)
                {
                    //if (Close[0] > SMA(50)[0])
                    //{
                    if (Position.Quantity.ToString() == "0")
                    {
                        longt = 1;
                        EnterLong(myInput0);
                        //EnterLong(500);
                        ll = Low[LowestBar(Low, 5)];
                        stop = Close[0] - (ATR(14)[0] * 1.5); //test other values besides Close[0]
                        target = Close[0] + (ATR(14)[0] * 2); //another value besides Close[0], adjust multipliers according to certain conditions?
                        //stop = Close[0] - (ATR(10)[0] * 2);
                        //target = Close[0] + (ATR(10)[0] * 4);

                    }
                }
                //}
            }

            //if ((Stochastics(3, 14, 3).K[0] < Stochastics(3, 14, 3).D[0]) & (Stochastics(3, 14, 3).K[1] > Stochastics(3, 14, 3).D[1]) & (Stochastics(3, 14, 3).K[1] > 80))
            if ((Stochastics(3, 14, 3).K[1] > 80) & (Stochastics(3, 14, 3).K[0] < 80))
            {
                
                if ((Position.Quantity.ToString() != "0") & (longt == 1))
                {
                    longt = 0;
                    ExitLong(myInput0);
                    //ExitLong(500);
                }
                

                if (MACD(12, 26, 9)[0] < 0)
                {
                    //if (Close[0] < SMA(50)[0])
                    //{
                    if (Position.Quantity.ToString() == "0")
                    {
                        shortt = 1;
                        EnterShort(myInput0);
                        //EnterShort(500);
                        hh = High[HighestBar(High, 5)];
                        stop = Close[0] + (ATR(14)[0] * 1.5);
                        target = Close[0] - (ATR(14)[0] * 2);
                        //stop = Close[0] + (ATR(10)[0] * 2);
                        //target = Close[0] - (ATR(10)[0] * 4);

                    }
                    //}
                }
                //}
            }

        }

        #region Properties
        [Description("")]
        [GridCategory("Parameters")]
        public int MyInput0
        {
            get { return myInput0; }
            set { myInput0 = Math.Max(1, value); }
        }
        #endregion
    }
}
