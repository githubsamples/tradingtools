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
    /// EMACrossover
    /// </summary>
    [Description("EMACrossover")]
    public class EMACrossover : Indicator
    {
        #region Variables
        // Wizard generated variables
        private int fastEMA = 10; // Default setting for FastEMA
        private int slowEMA = 50; // Default setting for SlowEMA
        // User defined variables (add any user defined variables below)
        #endregion

        /// <summary>
        /// This method is used to configure the indicator and is called once before any bar data is loaded.
        /// </summary>
        protected override void Initialize()
        {
            Add(new Plot(Color.FromKnownColor(KnownColor.Blue), PlotStyle.Bar, "Plot0"));
            Add(new Plot(Color.FromKnownColor(KnownColor.Red), PlotStyle.Bar, "Plot1"));
            Overlay = false;
        }

        /// <summary>
        /// Called on each bar update event (incoming tick)
        /// </summary>
        protected override void OnBarUpdate()
        {
            // Use this method for calculating your indicator values. Assign a value to each
            // plot below by replacing 'Close[0]' with your own formula.

            if (CurrentBar < 1)
                return;

            if ((EMA(fastEMA)[0] > EMA(slowEMA)[0]) & !(EMA(fastEMA)[1] > EMA(slowEMA)[1]))
            {
                Plot0.Set(1); //blue
            }

            if ((EMA(slowEMA)[0] > EMA(fastEMA)[0]) & !(EMA(slowEMA)[1] > EMA(fastEMA)[1]))
            {
                Plot1.Set(1); //red
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

        [Description("FastEMA")]
        [GridCategory("Parameters")]
        public int FastEMA
        {
            get { return fastEMA; }
            set { fastEMA = Math.Max(1, value); }
        }

        [Description("SlowEMA")]
        [GridCategory("Parameters")]
        public int SlowEMA
        {
            get { return slowEMA; }
            set { slowEMA = Math.Max(1, value); }
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
        private EMACrossover[] cacheEMACrossover = null;

        private static EMACrossover checkEMACrossover = new EMACrossover();

        /// <summary>
        /// EMACrossover
        /// </summary>
        /// <returns></returns>
        public EMACrossover EMACrossover(int fastEMA, int slowEMA)
        {
            return EMACrossover(Input, fastEMA, slowEMA);
        }

        /// <summary>
        /// EMACrossover
        /// </summary>
        /// <returns></returns>
        public EMACrossover EMACrossover(Data.IDataSeries input, int fastEMA, int slowEMA)
        {
            if (cacheEMACrossover != null)
                for (int idx = 0; idx < cacheEMACrossover.Length; idx++)
                    if (cacheEMACrossover[idx].FastEMA == fastEMA && cacheEMACrossover[idx].SlowEMA == slowEMA && cacheEMACrossover[idx].EqualsInput(input))
                        return cacheEMACrossover[idx];

            lock (checkEMACrossover)
            {
                checkEMACrossover.FastEMA = fastEMA;
                fastEMA = checkEMACrossover.FastEMA;
                checkEMACrossover.SlowEMA = slowEMA;
                slowEMA = checkEMACrossover.SlowEMA;

                if (cacheEMACrossover != null)
                    for (int idx = 0; idx < cacheEMACrossover.Length; idx++)
                        if (cacheEMACrossover[idx].FastEMA == fastEMA && cacheEMACrossover[idx].SlowEMA == slowEMA && cacheEMACrossover[idx].EqualsInput(input))
                            return cacheEMACrossover[idx];

                EMACrossover indicator = new EMACrossover();
                indicator.BarsRequired = BarsRequired;
                indicator.CalculateOnBarClose = CalculateOnBarClose;
#if NT7
                indicator.ForceMaximumBarsLookBack256 = ForceMaximumBarsLookBack256;
                indicator.MaximumBarsLookBack = MaximumBarsLookBack;
#endif
                indicator.Input = input;
                indicator.FastEMA = fastEMA;
                indicator.SlowEMA = slowEMA;
                Indicators.Add(indicator);
                indicator.SetUp();

                EMACrossover[] tmp = new EMACrossover[cacheEMACrossover == null ? 1 : cacheEMACrossover.Length + 1];
                if (cacheEMACrossover != null)
                    cacheEMACrossover.CopyTo(tmp, 0);
                tmp[tmp.Length - 1] = indicator;
                cacheEMACrossover = tmp;
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
        /// EMACrossover
        /// </summary>
        /// <returns></returns>
        [Gui.Design.WizardCondition("Indicator")]
        public Indicator.EMACrossover EMACrossover(int fastEMA, int slowEMA)
        {
            return _indicator.EMACrossover(Input, fastEMA, slowEMA);
        }

        /// <summary>
        /// EMACrossover
        /// </summary>
        /// <returns></returns>
        public Indicator.EMACrossover EMACrossover(Data.IDataSeries input, int fastEMA, int slowEMA)
        {
            return _indicator.EMACrossover(input, fastEMA, slowEMA);
        }
    }
}

// This namespace holds all strategies and is required. Do not change it.
namespace NinjaTrader.Strategy
{
    public partial class Strategy : StrategyBase
    {
        /// <summary>
        /// EMACrossover
        /// </summary>
        /// <returns></returns>
        [Gui.Design.WizardCondition("Indicator")]
        public Indicator.EMACrossover EMACrossover(int fastEMA, int slowEMA)
        {
            return _indicator.EMACrossover(Input, fastEMA, slowEMA);
        }

        /// <summary>
        /// EMACrossover
        /// </summary>
        /// <returns></returns>
        public Indicator.EMACrossover EMACrossover(Data.IDataSeries input, int fastEMA, int slowEMA)
        {
            if (InInitialize && input == null)
                throw new ArgumentException("You only can access an indicator with the default input/bar series from within the 'Initialize()' method");

            return _indicator.EMACrossover(input, fastEMA, slowEMA);
        }
    }
}
#endregion
