using System.Collections.Generic;
using System.Linq;

namespace Thalus.Forma.Fluent
{
    /// <summary>
    /// Implemenst the <see cref="StringParam"/> functionality such lik e<see cref="Build"/>
    /// or <see cref="Append"/>/. used for <see cref="DoubleParam"/>
    /// </summary>
    public class StringFluent
    {
        private string _id;
        private string _value;
        private string _default;
        private string _regex;
        private string _displayText;
        private bool _hasSettings;
        private string _unitId;
        private string _unitText;
        private bool _hasUnit;
        private List<StringEnumMeta> _enum;


        private List<object> _parentFluents;

        internal TType Fluent<TType>()
        {
            return (TType)_parentFluents.First(i => i.GetType() == typeof(TType));
        }

        /// <summary>
        /// Creates an instance of <see cref="StringFluent"/> initialized with defaults
        /// </summary>
        public StringFluent() : this(new GroupFluent())
        {

        }
        /// <summary>
        /// Creates an instance of <see cref="StringFluent"/> initialized with passed parameters
        /// </summary>
        public StringFluent(params object[] fluent)
        {
            _parentFluents = fluent?.ToList();
            PresetValues();
        }
        /// <summary>
        /// Adds a id to the <see cref="StringParam"/>
        /// </summary>
        /// <param name="id">Pass identifier such like myparam</param>
        /// <returns></returns>
        public StringFluent Id(string id)
        {
            _id = id;
            return this;
        }
        /// <summary>
        /// Adds a value to the <see cref="StringParam"/>
        /// </summary>
        /// <param name="val">Pass value such like 0.02</param>
        /// <returns></returns>
        public StringFluent Value(string val)
        {
            _value = val;
            return this;
        }
        /// <summary>
        /// Adds a default value to the <see cref="StringParam"/>
        /// </summary>
        /// <param name="dflt">Pass value such like 0.0</param>
        /// <returns></returns>
        public StringFluent Default(string dflt)
        {
            _hasSettings = true;
            _default = dflt;
            return this;
        }

        /// <summary>
        /// Adds a regex value to the <see cref="StringParam"/> for validation
        /// </summary>
        /// <param name="regex">Pass value such like [A|B|c|D]</param>
        /// <returns></returns>
        public StringFluent Regex(string regex)
        {
            _hasSettings = true;
            _regex = regex;
            return this;
        }
        /// <summary>
        /// Adds a display text value to the <see cref="StringParam"/>
        /// </summary>
        /// <param name="text">Pass value such like"My best double"</param>
        /// <returns></returns>
        public StringFluent DisplayText(string text)
        {
            _hasSettings = true;
            _displayText = text;
            return this;
        }
        /// <summary>
        /// Adds a enum value to the <see cref="StringParam"/>
        /// </summary>
        /// <param name="id">Pass value as id such like 'A'</param>
        /// <param name="value">Pass the corresponding display text</param>
        /// <returns></returns>
        public StringFluent Enum(string id, string value)
        {
            _hasSettings = true;
            if (_enum == null)
            {
                _enum = new List<StringEnumMeta>();
            }

            _enum.Add(new StringEnumMeta {Id = id, Enum = id, DisplayText = value});
            return this;
        }

        /// <summary>
        /// Adds a unit to the <see cref="StringParam"/>
        /// </summary>
        /// <param name="id">Pass unit identifier such like siml</param>
        /// <param name="text">Pass a user readable text correspoinfing to id</param>
        /// <returns></returns>
        public StringFluent Unit(string id, string text)
        {
            _hasUnit = true;
            _unitId = id;
            _unitText = text;
            return this;
        }

        private void PresetValues()
        {
            _id = null;
            _value = default(string);
            _default = default(string);
            _regex = null;
            _displayText = null;
            _hasUnit = false;
            _unitId = null;
            _unitText = null;
            _enum = null;

            _hasSettings = false;
        }

        /// <summary>
        /// Creates a <see cref="StringParam"/> out of the passed items
        /// </summary>
        /// <returns></returns>
        public StringParam Build()
        {
            StringParam p = new StringParam
            {
                Id = _id,
                Type = "string-param",
                Value = _value
            };

            if (_hasSettings)
            {
                StringParamMeta s = new StringParamMeta
                {
                    Default = _default,
                    Id = $"{_id}-meta",
                    Type = "string-meta",
                    Regex = _regex,
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