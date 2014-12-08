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
    /// Donchianautomate2
    /// </summary>
    [Description("Donchianautomate2")]
    public class Donchianautomate2 : Indicator
    {
        #region Variables
        // Wizard generated variables
        private int automateperiod = 14; // Default setting for Automateperiod
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
            Overlay = false;
        }

        /// <summary>
        /// Called on each bar update event (incoming tick)
        /// </summary>
        protected override void OnBarUpdate()
        {
            // Use this method for calculating your indicator values. Assign a value to each
            // plot below by replacing 'Close[0]' with your own formula.


            if (CurrentBar < 30)
                return;


            if ((Low[0] <= DonchianChannel(14)[0]) & (Low[1] > DonchianChannel(14)[1]))
            {
                Plot1.Set(1);

            }


            if ((High[0] >= DonchianChannel(14)[0]) & (High[1] < DonchianChannel(14)[1]))
            {
                Plot0.Set(1);

            }

            int up = 0;
            int down = 0;
            int y = 0;

            for (int x = 1; x <= 100; x++)
            {


                if ((Low[x] <= DonchianChannel(14)[x]) & (Low[x + 1] > DonchianChannel(14)[x + 1]))
                {
                    up = 1;
                    y = x;
                    break;
                }


                if ((High[x] >= DonchianChannel(14)[x]) & (High[x + 1] < DonchianChannel(14)[x + 1]))
                {
                    down = 1;
                    y = x;
                    break;
                }
            }


            int firstup = 0;
            int firstdown = 0;


            for (int x = 0; x <= 100; x++)
            {


                if ((up == 1) & (High[x] > High[x + 1]))
                {
                    if (x >= y)
                    {
                        break;
                    }

                    if (x != 0)
                    {
                        firstup = 1;
                        break;
                    }
                    /*
                    if (!(x < y))
                    {
                        break;
                    }*/

                }


                if ((down == 1) & (Low[x] < Low[x + 1]))
                {
                    if (x >= y)
                    {
                        break;
                    }

                    if (x != 0)
                    {
                        firstdown = 1;
                        break;
                    }
                    /*
                    if (!(x < y))
                    {
                        break;
                    }*/
                }
            }

            if ((firstup == 0) & (up == 1) & (High[0] > High[1]))
            {
                Plot3.Set(1);
            }

            if ((firstdown == 0) & (down == 1) & (Low[0] < Low[1]))
            {
                Plot2.Set(1);
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

        [Description("Period")]
        [GridCategory("Parameters")]
        public int Automateperiod
        {
            get { return automateperiod; }
            set { automateperiod = Math.Max(1, value); }
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
        private Donchianautomate2[] cacheDonchianautomate2 = null;

        private static Donchianautomate2 checkDonchianautomate2 = new Donchianautomate2();

        /// <summary>
        /// Donchianautomate2
        /// </summary>
        /// <returns></returns>
        public Donchianautomate2 Donchianautomate2(int automateperiod)
        {
            return Donchianautomate2(Input, automateperiod);
        }

        /// <summary>
        /// Donchianautomate2
        /// </summary>
        /// <returns></returns>
        public Donchianautomate2 Donchianautomate2(Data.IDataSeries input, int automateperiod)
        {
            if (cacheDonchianautomate2 != null)
                for (int idx = 0; idx < cacheDonchianautomate2.Length; idx++)
                    if (cacheDonchianautomate2[idx].Automateperiod == automateperiod && cacheDonchianautomate2[idx].EqualsInput(input))
                        return cacheDonchianautomate2[idx];

            lock (checkDonchianautomate2)
            {
                checkDonchianautomate2.Automateperiod = automateperiod;
                automateperiod = checkDonchianautomate2.Automateperiod;

                if (cacheDonchianautomate2 != null)
                    for (int idx = 0; idx < cacheDonchianautomate2.Length; idx++)
                        if (cacheDonchianautomate2[idx].Automateperiod == automateperiod && cacheDonchianautomate2[idx].EqualsInput(input))
                            return cacheDonchianautomate2[idx];

                Donchianautomate2 indicator = new Donchianautomate2();
                indicator.BarsRequired = BarsRequired;
                indicator.CalculateOnBarClose = CalculateOnBarClose;
#if NT7
                indicator.ForceMaximumBarsLookBack256 = ForceMaximumBarsLookBack256;
                indicator.MaximumBarsLookBack = MaximumBarsLookBack;
#endif
                indicator.Input = input;
                indicator.Automateperiod = automateperiod;
                Indicators.Add(indicator);
                indicator.SetUp();

                Donchianautomate2[] tmp = new Donchianautomate2[cacheDonchianautomate2 == null ? 1 : cacheDonchianautomate2.Length + 1];
                if (cacheDonchianautomate2 != null)
                    cacheDonchianautomate2.CopyTo(tmp, 0);
                tmp[tmp.Length - 1] = indicator;
                cacheDonchianautomate2 = tmp;
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
        /// Donchianautomate2
        /// </summary>
        /// <returns></returns>
        [Gui.Design.WizardCondition("Indicator")]
        public Indicator.Donchianautomate2 Donchianautomate2(int automateperiod)
        {
            return _indicator.Donchianautomate2(Input, automateperiod);
        }

        /// <summary>
        /// Donchianautomate2
        /// </summary>
        /// <returns></returns>
        public Indicator.Donchianautomate2 Donchianautomate2(Data.IDataSeries input, int automateperiod)
        {
            return _indicator.Donchianautomate2(input, automateperiod);
        }
    }
}

// This namespace holds all strategies and is required. Do not change it.
namespace NinjaTrader.Strategy
{
    public partial class Strategy : StrategyBase
    {
        /// <summary>
        /// Donchianautomate2
        /// </summary>
        /// <returns></returns>
        [Gui.Design.WizardCondition("Indicator")]
        public Indicator.Donchianautomate2 Donchianautomate2(int automateperiod)
        {
            return _indicator.Donchianautomate2(Input, automateperiod);
        }

        /// <summary>
        /// Donchianautomate2
        /// </summary>
        /// <returns></returns>
        public Indicator.Donchianautomate2 Donchianautomate2(Data.IDataSeries input, int automateperiod)
        {
            if (InInitialize && input == null)
                throw new ArgumentException("You only can access an indicator with the default input/bar series from within the 'Initialize()' method");

            return _indicator.Donchianautomate2(input, automateperiod);
        }
    }
}
#endregion
