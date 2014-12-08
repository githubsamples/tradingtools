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
    /// NR7
    /// </summary>
    [Description("NR7")]
    public class NR7 : Indicator
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
            Add(new Plot(Color.FromKnownColor(KnownColor.Orange), PlotStyle.Bar, "Plot0"));
            Overlay				= false;
        }

        /// <summary>
        /// Called on each bar update event (incoming tick)
        /// </summary>
        protected override void OnBarUpdate()
        {
            // Use this method for calculating your indicator values. Assign a value to each
            // plot below by replacing 'Close[0]' with your own formula.
            if (CurrentBar < 6)
            	return;
			
			decimal price0 = (decimal)(High[0]-Low[0]);
			decimal price1 = (decimal)(High[1]-Low[1]);
			decimal price2 = (decimal)(High[2]-Low[2]);
			decimal price3 = (decimal)(High[3]-Low[3]);
			decimal price4 = (decimal)(High[4]-Low[4]);
			decimal price5 = (decimal)(High[5]-Low[5]);
			decimal price6 = (decimal)(High[6]-Low[6]);
				
			
			price0 = decimal.Round(price0,2,MidpointRounding.AwayFromZero);
			price1 = decimal.Round(price1,2,MidpointRounding.AwayFromZero);
			price2 = decimal.Round(price2,2,MidpointRounding.AwayFromZero);
			price3 = decimal.Round(price3,2,MidpointRounding.AwayFromZero);
			price4 = decimal.Round(price4,2,MidpointRounding.AwayFromZero);
			price5 = decimal.Round(price5,2,MidpointRounding.AwayFromZero);
			price6 = decimal.Round(price6,2,MidpointRounding.AwayFromZero);
			
				
			if ( (price0<price1) && (price0<price2) && (price0<price3) && (price0<price4) && (price0<price5) && (price0<price6) )
			{
            	Plot0.Set(1);
            }  
        }

        #region Properties
        [Browsable(false)]	// this line prevents the data series from being displayed in the indicator properties dialog, do not remove
        [XmlIgnore()]		// this line ensures that the indicator can be saved/recovered as part of a chart template, do not remove
        public DataSeries Plot0
        {
            get { return Values[0]; }
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
        private NR7[] cacheNR7 = null;

        private static NR7 checkNR7 = new NR7();

        /// <summary>
        /// NR7
        /// </summary>
        /// <returns></returns>
        public NR7 NR7()
        {
            return NR7(Input);
        }

        /// <summary>
        /// NR7
        /// </summary>
        /// <returns></returns>
        public NR7 NR7(Data.IDataSeries input)
        {
            if (cacheNR7 != null)
                for (int idx = 0; idx < cacheNR7.Length; idx++)
                    if (cacheNR7[idx].EqualsInput(input))
                        return cacheNR7[idx];

            lock (checkNR7)
            {
                if (cacheNR7 != null)
                    for (int idx = 0; idx < cacheNR7.Length; idx++)
                        if (cacheNR7[idx].EqualsInput(input))
                            return cacheNR7[idx];

                NR7 indicator = new NR7();
                indicator.BarsRequired = BarsRequired;
                indicator.CalculateOnBarClose = CalculateOnBarClose;
#if NT7
                indicator.ForceMaximumBarsLookBack256 = ForceMaximumBarsLookBack256;
                indicator.MaximumBarsLookBack = MaximumBarsLookBack;
#endif
                indicator.Input = input;
                Indicators.Add(indicator);
                indicator.SetUp();

                NR7[] tmp = new NR7[cacheNR7 == null ? 1 : cacheNR7.Length + 1];
                if (cacheNR7 != null)
                    cacheNR7.CopyTo(tmp, 0);
                tmp[tmp.Length - 1] = indicator;
                cacheNR7 = tmp;
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
        /// NR7
        /// </summary>
        /// <returns></returns>
        [Gui.Design.WizardCondition("Indicator")]
        public Indicator.NR7 NR7()
        {
            return _indicator.NR7(Input);
        }

        /// <summary>
        /// NR7
        /// </summary>
        /// <returns></returns>
        public Indicator.NR7 NR7(Data.IDataSeries input)
        {
            return _indicator.NR7(input);
        }
    }
}

// This namespace holds all strategies and is required. Do not change it.
namespace NinjaTrader.Strategy
{
    public partial class Strategy : StrategyBase
    {
        /// <summary>
        /// NR7
        /// </summary>
        /// <returns></returns>
        [Gui.Design.WizardCondition("Indicator")]
        public Indicator.NR7 NR7()
        {
            return _indicator.NR7(Input);
        }

        /// <summary>
        /// NR7
        /// </summary>
        /// <returns></returns>
        public Indicator.NR7 NR7(Data.IDataSeries input)
        {
            if (InInitialize && input == null)
                throw new ArgumentException("You only can access an indicator with the default input/bar series from within the 'Initialize()' method");

            return _indicator.NR7(input);
        }
    }
}
#endregion
