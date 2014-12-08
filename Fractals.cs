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
    /// Fractals
    /// </summary>
    [Description("Fractals")]
    public class Fractals : Indicator
    {
        #region Variables
        // Wizard generated variables
        // User defined variables (add any user defined variables below)
        #endregion

        /// <summary>
        /// This method is used to configure the indicator and is called once before any bar data is loaded.
        /// </summary>
        protected override void Initialize()
        {
            Add(new Plot(Color.FromKnownColor(KnownColor.Red), PlotStyle.Bar, "Plot0"));
            Add(new Plot(Color.FromKnownColor(KnownColor.Green), PlotStyle.Bar, "Plot1"));
            Overlay = false;
        }

        /// <summary>
        /// Called on each bar update event (incoming tick)
        /// </summary>
        protected override void OnBarUpdate()
        {
            // Use this method for calculating your indicator values. Assign a value to each
            // plot below by replacing 'Close[0]' with your own formula.
            if (CurrentBar < 4)
                return;


            if ((High[2] >= High[0]) && (High[2] >= High[1]) && (High[2] >= High[3]) && (High[2] >= High[4]))
            {
                Plot0.Set(2,1);
                return;
            }


            if ((Low[2] <= Low[0]) && (Low[2] <= Low[1]) && (Low[2] <= Low[3]) && (Low[2] <= Low[4]))
            {
                Plot1.Set(2,1);
                return;
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

        #endregion
    }
}

#region NinjaScript generated code. Neither change nor remove.
// This namespace holds all indicators and is required. Do not change it.
namespace NinjaTrader.Indicator
{
    public partial class Indicator : IndicatorBase
    {
        private Fractals[] cacheFractals = null;

        private static Fractals checkFractals = new Fractals();

        /// <summary>
        /// Fractals
        /// </summary>
        /// <returns></returns>
        public Fractals Fractals()
        {
            return Fractals(Input);
        }

        /// <summary>
        /// Fractals
        /// </summary>
        /// <returns></returns>
        public Fractals Fractals(Data.IDataSeries input)
        {
            if (cacheFractals != null)
                for (int idx = 0; idx < cacheFractals.Length; idx++)
                    if (cacheFractals[idx].EqualsInput(input))
                        return cacheFractals[idx];

            lock (checkFractals)
            {
                if (cacheFractals != null)
                    for (int idx = 0; idx < cacheFractals.Length; idx++)
                        if (cacheFractals[idx].EqualsInput(input))
                            return cacheFractals[idx];

                Fractals indicator = new Fractals();
                indicator.BarsRequired = BarsRequired;
                indicator.CalculateOnBarClose = CalculateOnBarClose;
#if NT7
                indicator.ForceMaximumBarsLookBack256 = ForceMaximumBarsLookBack256;
                indicator.MaximumBarsLookBack = MaximumBarsLookBack;
#endif
                indicator.Input = input;
                Indicators.Add(indicator);
                indicator.SetUp();

                Fractals[] tmp = new Fractals[cacheFractals == null ? 1 : cacheFractals.Length + 1];
                if (cacheFractals != null)
                    cacheFractals.CopyTo(tmp, 0);
                tmp[tmp.Length - 1] = indicator;
                cacheFractals = tmp;
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
        /// Fractals
        /// </summary>
        /// <returns></returns>
        [Gui.Design.WizardCondition("Indicator")]
        public Indicator.Fractals Fractals()
        {
            return _indicator.Fractals(Input);
        }

        /// <summary>
        /// Fractals
        /// </summary>
        /// <returns></returns>
        public Indicator.Fractals Fractals(Data.IDataSeries input)
        {
            return _indicator.Fractals(input);
        }
    }
}

// This namespace holds all strategies and is required. Do not change it.
namespace NinjaTrader.Strategy
{
    public partial class Strategy : StrategyBase
    {
        /// <summary>
        /// Fractals
        /// </summary>
        /// <returns></returns>
        [Gui.Design.WizardCondition("Indicator")]
        public Indicator.Fractals Fractals()
        {
            return _indicator.Fractals(Input);
        }

        /// <summary>
        /// Fractals
        /// </summary>
        /// <returns></returns>
        public Indicator.Fractals Fractals(Data.IDataSeries input)
        {
            if (InInitialize && input == null)
                throw new ArgumentException("You only can access an indicator with the default input/bar series from within the 'Initialize()' method");

            return _indicator.Fractals(input);
        }
    }
}
#endregion
