#region Using declarations
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Xml.Serialization;
using NinjaTrader.Cbi;
using NinjaTrader.Data;
using NinjaTrader.Gui.Chart;
#endregion

// This namespace holds all indicators and is required. Do not change it.
namespace NinjaTrader.Indicator
{
    /// <summary>
    /// MACDDiff
    /// </summary>
    [Description("MACDDiff")]
    public class MACDDiff : Indicator
    {
        #region Variables
        // Wizard generated variables
            private int var0 = 1; // Default setting for Var0
            private int var1 = 1; // Default setting for Var1
            private int var2 = 1; // Default setting for Var2
            private int var3 = 1; // Default setting for Var3
        // User defined variables (add any user defined variables below)
        #endregion

        /// <summary>
        /// This method is used to configure the indicator and is called once before any bar data is loaded.
        /// </summary>
        protected override void Initialize()
        {
            Add(new Plot(Color.FromKnownColor(KnownColor.Red), PlotStyle.Bar, "Plot0"));
            Add(new Plot(Color.FromKnownColor(KnownColor.Green), PlotStyle.Bar, "Plot1"));
            Add(new Plot(Color.FromKnownColor(KnownColor.Black), PlotStyle.Bar, "Plot2"));
            Add(new Plot(Color.FromKnownColor(KnownColor.Blue), PlotStyle.Bar, "Plot3"));
			Add(new Plot(Color.FromKnownColor(KnownColor.Orange), PlotStyle.Bar, "Plot4"));
            Add(new Plot(Color.FromKnownColor(KnownColor.Aqua), PlotStyle.Bar, "Plot5"));
            Add(new Plot(Color.FromKnownColor(KnownColor.Purple), PlotStyle.Bar, "Plot6"));
            Add(new Plot(Color.FromKnownColor(KnownColor.DodgerBlue), PlotStyle.Bar, "Plot7"));	
            Overlay				= false;
        }

        /// <summary>
        /// Called on each bar update event (incoming tick)
        /// </summary>
        protected override void OnBarUpdate()
        {
            if (CurrentBar < 5)
                return;
			
		
			if (MACD(12, 26, 9).Diff[0] >= MACD(12, 26, 9).Diff[1])
			{
				if ((MACD(12, 26, 9).Diff[1] < MACD(12, 26, 9).Diff[2]) & (MACD(12, 26, 9).Diff[2] < MACD(12, 26, 9).Diff[3]) & (MACD(12, 26, 9).Diff[3] < MACD(12, 26, 9).Diff[4]) & (MACD(12, 26, 9).Diff[4] < MACD(12, 26, 9).Diff[5]))
				{
					Plot5.Set(MACD(12, 26, 9).Diff[0]);	
				}
				
				else
				{
					Plot5.Set(0);
					Plot1.Set(MACD(12, 26, 9).Diff[0]);
				}
			}
			
			else
			{
				Plot1.Set(0);
			}
				
			if (MACD(12, 26, 9).Diff[0] < MACD(12, 26, 9).Diff[1])
			{
				if ((MACD(12, 26, 9).Diff[1] >= MACD(12, 26, 9).Diff[2]) & (MACD(12, 26, 9).Diff[2] >= MACD(12, 26, 9).Diff[3]) & (MACD(12, 26, 9).Diff[3] >= MACD(12, 26, 9).Diff[4]) & (MACD(12, 26, 9).Diff[4] >= MACD(12, 26, 9).Diff[5]))
				{
					Plot4.Set(MACD(12, 26, 9).Diff[0]);
				}
				
				else
				{
					Plot4.Set(0);
					Plot0.Set(MACD(12, 26, 9).Diff[0]);
				}
			}
			
			else
			{
				Plot0.Set(0);
			}
		
        }

        #region Properties
        [Browsable(false)]	// this line prevents the data series from being displayed in the indicator properties dialog, do not remove
        [XmlIgnore()]		// this line ensures that the indicator can be saved/recovered as part of a chart template, do not remove
        public DataSeries Plot0
        {
            get { return Values[0]; }
        }

        [Browsable(false)]	// this line prevents the data series from being displayed in the indicator properties dialog, do not remove
        [XmlIgnore()]		// this line ensures that the indicator can be saved/recovered as part of a chart template, do not remove
        public DataSeries Plot1
        {
            get { return Values[1]; }
        }

        [Browsable(false)]	// this line prevents the data series from being displayed in the indicator properties dialog, do not remove
        [XmlIgnore()]		// this line ensures that the indicator can be saved/recovered as part of a chart template, do not remove
        public DataSeries Plot2
        {
            get { return Values[2]; }
        }

        [Browsable(false)]	// this line prevents the data series from being displayed in the indicator properties dialog, do not remove
        [XmlIgnore()]		// this line ensures that the indicator can be saved/recovered as part of a chart template, do not remove
        public DataSeries Plot3
        {
            get { return Values[3]; }
        }

		 [Browsable(false)]	// this line prevents the data series from being displayed in the indicator properties dialog, do not remove
        [XmlIgnore()]		// this line ensures that the indicator can be saved/recovered as part of a chart template, do not remove
        public DataSeries Plot4
        {
            get { return Values[4]; }
        }


        [Browsable(false)]	// this line prevents the data series from being displayed in the indicator properties dialog, do not remove
        [XmlIgnore()]		// this line ensures that the indicator can be saved/recovered as part of a chart template, do not remove
        public DataSeries Plot5
        {
            get { return Values[5]; }
        }

        [Browsable(false)]	// this line prevents the data series from being displayed in the indicator properties dialog, do not remove
        [XmlIgnore()]		// this line ensures that the indicator can be saved/recovered as part of a chart template, do not remove
        public DataSeries Plot6
        {
            get { return Values[6]; }
        }

        [Browsable(false)]	// this line prevents the data series from being displayed in the indicator properties dialog, do not remove
        [XmlIgnore()]		// this line ensures that the indicator can be saved/recovered as part of a chart template, do not remove
        public DataSeries Plot7
        {
            get { return Values[7]; }
        }
		
        [Description("")]
        [GridCategory("Parameters")]
        public int Var0
        {
            get { return var0; }
            set { var0 = Math.Max(1, value); }
        }

        [Description("")]
        [GridCategory("Parameters")]
        public int Var1
        {
            get { return var1; }
            set { var1 = Math.Max(1, value); }
        }

        [Description("")]
        [GridCategory("Parameters")]
        public int Var2
        {
            get { return var2; }
            set { var2 = Math.Max(1, value); }
        }

        [Description("")]
        [GridCategory("Parameters")]
        public int Var3
        {
            get { return var3; }
            set { var3 = Math.Max(1, value); }
        }
        #endregion
    }
}

#region NinjaScript generated code. Neither change nor remove.
// This namespace holds all indicators and is required. Do not change it.
namespace NinjaTrader.Indicator
{
    public partial class Indicator : IndicatorBase
    {
        private MACDDiff[] cacheMACDDiff = null;

        private static MACDDiff checkMACDDiff = new MACDDiff();

        /// <summary>
        /// MACDDiff
        /// </summary>
        /// <returns></returns>
        public MACDDiff MACDDiff(int var0, int var1, int var2, int var3)
        {
            return MACDDiff(Input, var0, var1, var2, var3);
        }

        /// <summary>
        /// MACDDiff
        /// </summary>
        /// <returns></returns>
        public MACDDiff MACDDiff(Data.IDataSeries input, int var0, int var1, int var2, int var3)
        {
            if (cacheMACDDiff != null)
                for (int idx = 0; idx < cacheMACDDiff.Length; idx++)
                    if (cacheMACDDiff[idx].Var0 == var0 && cacheMACDDiff[idx].Var1 == var1 && cacheMACDDiff[idx].Var2 == var2 && cacheMACDDiff[idx].Var3 == var3 && cacheMACDDiff[idx].EqualsInput(input))
                        return cacheMACDDiff[idx];

            lock (checkMACDDiff)
            {
                checkMACDDiff.Var0 = var0;
                var0 = checkMACDDiff.Var0;
                checkMACDDiff.Var1 = var1;
                var1 = checkMACDDiff.Var1;
                checkMACDDiff.Var2 = var2;
                var2 = checkMACDDiff.Var2;
                checkMACDDiff.Var3 = var3;
                var3 = checkMACDDiff.Var3;

                if (cacheMACDDiff != null)
                    for (int idx = 0; idx < cacheMACDDiff.Length; idx++)
                        if (cacheMACDDiff[idx].Var0 == var0 && cacheMACDDiff[idx].Var1 == var1 && cacheMACDDiff[idx].Var2 == var2 && cacheMACDDiff[idx].Var3 == var3 && cacheMACDDiff[idx].EqualsInput(input))
                            return cacheMACDDiff[idx];

                MACDDiff indicator = new MACDDiff();
                indicator.BarsRequired = BarsRequired;
                indicator.CalculateOnBarClose = CalculateOnBarClose;
#if NT7
                indicator.ForceMaximumBarsLookBack256 = ForceMaximumBarsLookBack256;
                indicator.MaximumBarsLookBack = MaximumBarsLookBack;
#endif
                indicator.Input = input;
                indicator.Var0 = var0;
                indicator.Var1 = var1;
                indicator.Var2 = var2;
                indicator.Var3 = var3;
                Indicators.Add(indicator);
                indicator.SetUp();

                MACDDiff[] tmp = new MACDDiff[cacheMACDDiff == null ? 1 : cacheMACDDiff.Length + 1];
                if (cacheMACDDiff != null)
                    cacheMACDDiff.CopyTo(tmp, 0);
                tmp[tmp.Length - 1] = indicator;
                cacheMACDDiff = tmp;
                return indicator;
            }
        }
    }
}

// This namespace holds all market analyzer column definitions and is required. Do not change it.
namespace NinjaTrader.MarketAnalyzer
{
    public partial class Column : ColumnBase
    {
        /// <summary>
        /// MACDDiff
        /// </summary>
        /// <returns></returns>
        [Gui.Design.WizardCondition("Indicator")]
        public Indicator.MACDDiff MACDDiff(int var0, int var1, int var2, int var3)
        {
            return _indicator.MACDDiff(Input, var0, var1, var2, var3);
        }

        /// <summary>
        /// MACDDiff
        /// </summary>
        /// <returns></returns>
        public Indicator.MACDDiff MACDDiff(Data.IDataSeries input, int var0, int var1, int var2, int var3)
        {
            return _indicator.MACDDiff(input, var0, var1, var2, var3);
        }
    }
}

// This namespace holds all strategies and is required. Do not change it.
namespace NinjaTrader.Strategy
{
    public partial class Strategy : StrategyBase
    {
        /// <summary>
        /// MACDDiff
        /// </summary>
        /// <returns></returns>
        [Gui.Design.WizardCondition("Indicator")]
        public Indicator.MACDDiff MACDDiff(int var0, int var1, int var2, int var3)
        {
            return _indicator.MACDDiff(Input, var0, var1, var2, var3);
        }

        /// <summary>
        /// MACDDiff
        /// </summary>
        /// <returns></returns>
        public Indicator.MACDDiff MACDDiff(Data.IDataSeries input, int var0, int var1, int var2, int var3)
        {
            if (InInitialize && input == null)
                throw new ArgumentException("You only can access an indicator with the default input/bar series from within the 'Initialize()' method");

            return _indicator.MACDDiff(input, var0, var1, var2, var3);
        }
    }
}
#endregion
