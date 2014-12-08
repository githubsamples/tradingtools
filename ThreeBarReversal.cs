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
    /// ThreeBarReversal
    /// </summary>
    [Description("ThreeBarReversal")]
    public class ThreeBarReversal : Indicator
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
            Overlay				= false;
        }

        /// <summary>
        /// Called on each bar update event (incoming tick)
        /// </summary>
        protected override void OnBarUpdate()
        {
            // Use this method for calculating your indicator values. Assign a value to each
            // plot below by replacing 'Close[0]' with your own formula.
            if (CurrentBar < 2)
           		return;

			
			if((Open[2] < Close[2]) & (High[2]<High[1]) & (Low[2]<Low[1]) & (Close[0] < Open[0]) & (High[0] < High[1]) & (Close[0] < Low[1]))
			{
            	Plot0.Set(1);
            }  
			
			
			if((Open[2] > Close[2]) & (High[2]>High[1]) & (Low[2]>Low[1]) & (Close[0] > Open[0]) & (Low[0] > Low[1]) & (Close[0] > High[1]))
			{
            	Plot1.Set(1);
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
        private ThreeBarReversal[] cacheThreeBarReversal = null;

        private static ThreeBarReversal checkThreeBarReversal = new ThreeBarReversal();

        /// <summary>
        /// ThreeBarReversal
        /// </summary>
        /// <returns></returns>
        public ThreeBarReversal ThreeBarReversal()
        {
            return ThreeBarReversal(Input);
        }

        /// <summary>
        /// ThreeBarReversal
        /// </summary>
        /// <returns></returns>
        public ThreeBarReversal ThreeBarReversal(Data.IDataSeries input)
        {
            if (cacheThreeBarReversal != null)
                for (int idx = 0; idx < cacheThreeBarReversal.Length; idx++)
                    if (cacheThreeBarReversal[idx].EqualsInput(input))
                        return cacheThreeBarReversal[idx];

            lock (checkThreeBarReversal)
            {
                if (cacheThreeBarReversal != null)
                    for (int idx = 0; idx < cacheThreeBarReversal.Length; idx++)
                        if (cacheThreeBarReversal[idx].EqualsInput(input))
                            return cacheThreeBarReversal[idx];

                ThreeBarReversal indicator = new ThreeBarReversal();
                indicator.BarsRequired = BarsRequired;
                indicator.CalculateOnBarClose = CalculateOnBarClose;
#if NT7
                indicator.ForceMaximumBarsLookBack256 = ForceMaximumBarsLookBack256;
                indicator.MaximumBarsLookBack = MaximumBarsLookBack;
#endif
                indicator.Input = input;
                Indicators.Add(indicator);
                indicator.SetUp();

                ThreeBarReversal[] tmp = new ThreeBarReversal[cacheThreeBarReversal == null ? 1 : cacheThreeBarReversal.Length + 1];
                if (cacheThreeBarReversal != null)
                    cacheThreeBarReversal.CopyTo(tmp, 0);
                tmp[tmp.Length - 1] = indicator;
                cacheThreeBarReversal = tmp;
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
        /// ThreeBarReversal
        /// </summary>
        /// <returns></returns>
        [Gui.Design.WizardCondition("Indicator")]
        public Indicator.ThreeBarReversal ThreeBarReversal()
        {
            return _indicator.ThreeBarReversal(Input);
        }

        /// <summary>
        /// ThreeBarReversal
        /// </summary>
        /// <returns></returns>
        public Indicator.ThreeBarReversal ThreeBarReversal(Data.IDataSeries input)
        {
            return _indicator.ThreeBarReversal(input);
        }
    }
}

// This namespace holds all strategies and is required. Do not change it.
namespace NinjaTrader.Strategy
{
    public partial class Strategy : StrategyBase
    {
        /// <summary>
        /// ThreeBarReversal
        /// </summary>
        /// <returns></returns>
        [Gui.Design.WizardCondition("Indicator")]
        public Indicator.ThreeBarReversal ThreeBarReversal()
        {
            return _indicator.ThreeBarReversal(Input);
        }

        /// <summary>
        /// ThreeBarReversal
        /// </summary>
        /// <returns></returns>
        public Indicator.ThreeBarReversal ThreeBarReversal(Data.IDataSeries input)
        {
            if (InInitialize && input == null)
                throw new ArgumentException("You only can access an indicator with the default input/bar series from within the 'Initialize()' method");

            return _indicator.ThreeBarReversal(input);
        }
    }
}
#endregion
