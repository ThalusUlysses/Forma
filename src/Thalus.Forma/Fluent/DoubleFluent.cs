using System.Collections.Generic;

namespace Thalus.Forma.Fluent
{
    /// <summary>
    /// Implemenst the <see cref="DoubleFluent"/> functionality such lik e<see cref="Build"/>
    /// or <see cref="Append"/>/. used for <see cref="DoubleParam"/>
    /// </summary>
    public class DoubleFluent
    {
        private string _id;
        private double _value;
        private int _precision;
        private double _default;
        private string _displayText;
        private List<DoubleRange> _ranges;
        private List<DoubleEnumMeta> _enum;
        private string _unitId;
        private string _unitText;
        private bool _hasUnit;

        private bool _hasSettings;

        private GroupFluent _fluent;
        /// <summary>
        /// Appends a <see cref="DoubleParam"/> to a <see cref="GroupParam"/> using <see cref="GroupFluent"/>
        /// </summary>
        /// <returns></returns>
        public GroupFluent Append()
        {
            _fluent.Add(Build());
            return _fluent;
        }
        /// <summary>
        /// Creates an instance of <see cref="DoubleFluent"/> initialized with defaults
        /// </summary>
        public DoubleFluent() : this(new GroupFluent())
        {

        }
        /// <summary>
        /// Creates an instance of <see cref="DoubleFluent"/> initialized with passed parameters
        /// </summary>
        public DoubleFluent(GroupFluent fluent)
        {
            _fluent = fluent;
            PresetValues();
        }

        /// <summary>
        /// Adds a id to the <see cref="DoubleParam"/>
        /// </summary>
        /// <param name="id">Pass identifier such like myparam</param>
        /// <returns></returns>
        public DoubleFluent Id(string id)
        {
            _id = id;
            return this;
        }
        /// <summary>
        /// Adds a value to the <see cref="DoubleParam"/>
        /// </summary>
        /// <param name="val">Pass value such like 0.02</param>
        /// <returns></returns>
        public DoubleFluent Value(double val)
        {
            _value = val;
            return this;
        }

        /// <summary>
        /// Adds a precision value in digits to the <see cref="DoubleParam"/>
        /// </summary>
        /// <param name="prec">Pass precision value</param>
        /// <returns></returns>
        public DoubleFluent Precison(int prec)
        {
            _hasSettings = true;
            _precision = prec;
            return this;
        }
        /// <summary>
        /// Adds a precision value in digits to the <see cref="DoubleParam"/>
        /// </summary>
        /// <param name="prec">Pass precision value</param>
        /// <returns></returns>
        public DoubleFluent Precison(string prec)
        {
            _hasSettings = true;
            _precision = GetPrecision(prec);
            return this;
        }

        /// <summary>
        /// Adds a default value to the <see cref="DoubleParam"/>
        /// </summary>
        /// <param name="dflt">Pass value such like 0.0</param>
        /// <returns></returns>
        public DoubleFluent Default(double dflt)
        {
            _hasSettings = true;
            _default = dflt;
            return this;
        }

        /// <summary>
        /// Adds a display text value to the <see cref="DoubleParam"/>
        /// </summary>
        /// <param name="text">Pass value such like"My best double"</param>
        /// <returns></returns>
        public DoubleFluent DisplayText(string text)
        {
            _hasSettings = true;
            _displayText = text;
            return this;
        }

        /// <summary>
        /// Adds a unit to the <see cref="DoubleParam"/>
        /// </summary>
        /// <param name="id">Pass unit identifier such like siml</param>
        /// <param name="text">Pass a user readable text correspoinfing to id</param>
        /// <returns></returns>
        public DoubleFluent Unit(string id, string text)
        {
            _hasUnit = true;
            _unitId = id;
            _unitText = text;
            return this;
        }

        /// <summary>
        /// Adds a unit range to <see cref="DoubleParam"/>
        /// </summary>
        /// <param name="min">Pass the min value</param>
        /// <param name="max">Pass the max value</param>
        /// <returns></returns>
        public DoubleFluent AddRange(double min, double max)
        {
            _hasSettings = true;

            if (_ranges == null)
            {
                _ranges = new List<DoubleRange>();
            }

            _ranges.Add(new DoubleRange {Id = $"range-{_ranges.Count + 1}",Min = min, Max = max});

            return this;
        }

        /// <summary>
        /// Adds a enum value to the <see cref="DoubleParam"/>
        /// </summary>
        /// <param name="id">Pass value as id such like 'A'</param>
        /// <param name="text">Pass the corresponding display text</param>
        /// <returns></returns>
        public DoubleFluent Enum(double id, string text)
        {
            _hasSettings = true;

            if (_enum == null)
            {
                _enum = new List<DoubleEnumMeta>();
            }

            _enum.Add(new DoubleEnumMeta {Id = id.ToString(), Enum = id, DisplayText = text});

            return this;
        }

        private void PresetValues()
        {
            _id = null;
            _value = default(double);
            _precision = default(int);
            _default = default(double);
            _ranges = null;
            _enum = null;
            _displayText = null;
            _hasSettings = false;

            _hasUnit = false;
            _unitId = null;
            _unitText = null;
        }

        private int GetPrecision(string st)
        {
            int stIdx = st.IndexOf('.') + 1;
            return st.Length - stIdx;
        }

        /// <summary>
        /// Creates a <see cref="DoubleParam"/> out of the passed items
        /// </summary>
        /// <returns></returns>
        public DoubleParam Build()
        {
            DoubleParam p = new DoubleParam
            {
                Id = _id,
                Type = "double-param",
                Value = _value
            };
            
            if (_hasSettings)
            {
                DoubleParamMeta s = new DoubleParamMeta
                {
                    Default = _default,
                    Id = $"{_id}-meta",
                    Type = "double-meta",
                    Precision = _precision,
                    Ranges = _ranges?.ToArray(),
                    Enum = _enum?.ToArray(),
                    DisplayText = _displayText
                };
                p.Meta = s;
            }

            if (_hasUnit)
            {
                UnitParam u = new UnitParam
                {
                    Id = _unitId,
                    DisplayText = _unitText
                };

                p.Unit = u;
            }

            PresetValues();

            return p;
        }

    }
}