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
    /// StochasticPOP1strategy
    /// </summary>
    [Description("StochasticPOP1strategy")]
    public class StochasticPOP1strategy : Strategy
    {
        #region Variables
        // Wizard generated variables
        private int myInput0 = 1; // Default setting for MyInput0
        private int myInput1 = 1; // Default setting for MyInput1
        private int myInput2 = 1; // Default setting for MyInput2
        private int myInput3 = 1; // Default setting for MyInput3
        private int myInput4 = 1; // Default setting for MyInput4
        private int myInput5 = 1; // Default setting for MyInput5
        private int myInput6 = 1; // Default setting for MyInput6
        private int myInput7 = 1; // Default setting for MyInput7
		private int longt = 0;
        private int shortt = 0;
        private double ll = 0;
        private double hh = 0;
        private double target = 0;
        private double stop = 0;
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
        	
            if ((Stochastics(3, 14, 5).K[1] < 60) & (Stochastics(3, 14, 5).K[0] > 60))
            {
      
                if ((Position.Quantity.ToString() == "0") & (longt == 0))
                {
                    longt = 1;
                    EnterLong(myInput0);
                }

            }


            if ((Stochastics(3, 14, 5).K[1] > 60) & (Stochastics(3, 14, 5).K[0] < 60))
            {
                
                if ((Position.Quantity.ToString() != "0") & (longt == 1))
                {
                    longt = 0;
                    ExitLong(myInput0);
                }
 
            }


            if ((Stochastics(3, 14, 5).K[1] > 30) & (Stochastics(3, 14, 5).K[0] < 30))
            {
               

                if ((Position.Quantity.ToString() == "0") & (shortt == 0))
                {
                    shortt = 1;
                    EnterShort(myInput0);
                }

            }


            if ((Stochastics(3, 14, 5).K[1] < 30) & (Stochastics(3, 14, 5).K[0] > 30))
            {

                if ((Position.Quantity.ToString() != "0") & (shortt == 1))
                {
                    shortt = 0;
                    ExitShort(myInput0);
                }

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

        [Description("")]
        [GridCategory("Parameters")]
        public int MyInput1
        {
            get { return myInput1; }
            set { myInput1 = Math.Max(1, value); }
        }

        [Description("")]
        [GridCategory("Parameters")]
        public int MyInput2
        {
            get { return myInput2; }
            set { myInput2 = Math.Max(1, value); }
        }

        [Description("")]
        [GridCategory("Parameters")]
        public int MyInput3
        {
            get { return myInput3; }
            set { myInput3 = Math.Max(1, value); }
        }

        [Description("")]
        [GridCategory("Parameters")]
        public int MyInput4
        {
            get { return myInput4; }
            set { myInput4 = Math.Max(1, value); }
        }

        [Description("")]
        [GridCategory("Parameters")]
        public int MyInput5
        {
            get { return myInput5; }
            set { myInput5 = Math.Max(1, value); }
        }

        [Description("")]
        [GridCategory("Parameters")]
        public int MyInput6
        {
            get { return myInput6; }
            set { myInput6 = Math.Max(1, value); }
        }

        [Description("")]
        [GridCategory("Parameters")]
        public int MyInput7
        {
            get { return myInput7; }
            set { myInput7 = Math.Max(1, value); }
        }
        #endregion
    }
}
