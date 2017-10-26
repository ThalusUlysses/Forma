using System.Collections.Generic;

namespace Thalus.Forma.Fluent
{
    /// <summary>
    /// Implemenst the <see cref="IntFluent"/> functionality such lik e<see cref="Build"/>
    /// or <see cref="Append"/>/. used for <see cref="IntParam"/>
    /// </summary>
    public class IntFluent
    {
        private string _id;
        private int _value;
        private int _default;
        private List<IntRange> _ranges;
        private List<IntEnumMeta> _enums;
        private bool _hasSettings;
        private string _displayText;
        private string _unitId;
        private string _unitText;
        private bool _hasUnit;

        private GroupFluent _fluent;

        /// <summary>
        /// Appens a <see cref="IntParam"/> to <see cref="GroupParam"/> using <see cref="GroupFluent"/>
        /// </summary>
        /// <returns></returns>
        public GroupFluent Append()
        {
            _fluent.Add(Build());
            return _fluent;
        }

        /// <summary>
        /// Creates an instance of <see cref="IntFluent"/> initialized with defaults
        /// </summary>
        public IntFluent() : this(new GroupFluent())
        {
            
        }

        /// <summary>
        /// Creates an instance of <see cref="IntFluent"/> initialized with passed parameters
        /// </summary>
        public IntFluent(GroupFluent fluent)
        {
            _fluent = fluent;
            PresetValues();
        }

        /// <summary>
        /// Adds a unit to the <see cref="IntParam"/>
        /// </summary>
        /// <param name="id">Pass unit identifier such like siml</param>
        /// <param name="text">Pass a user readable text correspoinfing to id</param>
        /// <returns></returns>
        public IntFluent Unit(string id, string text)
        {
            _hasUnit = true;
            _unitId = id;
            _unitText = text;
            return this;
        }

        /// <summary>
        /// Adds a id to the <see cref="IntParam"/>
        /// </summary>
        /// <param name="id">Pass identifier such like myparam</param>
        /// <returns></returns>
        public IntFluent Id(string id)
        {
            _id = id;
            return this;
        }
        /// <summary>
        /// Adds a value to the <see cref="IntParam"/>
        /// </summary>
        /// <param name="val">Pass value such like 'c'</param>
        /// <returns></returns>
        public IntFluent Value(int val)
        {
            _value = val;
            return this;
        }
        /// <summary>
        /// Adds a default value to the <see cref="IntParam"/>
        /// </summary>
        /// <param name="dflt">Pass value such like 'c'</param>
        /// <returns></returns>
        public IntFluent Default(int dflt)
        {
            _hasSettings = true;
            _default = dflt;
            return this;
        }

        /// <summary>
        /// Adds a display text value to the <see cref="IntParam"/>
        /// </summary>
        /// <param name="text">Pass value such like"My best char"</param>
        /// <returns></returns>
        public IntFluent DisplayText(string text)
        {
            _hasSettings = true;
            _displayText = text;
            return this;
        }
        /// <summary>
        /// Adds a unit range to <see cref="IntParam"/>
        /// </summary>
        /// <param name="min">Pass the min value</param>
        /// <param name="max">Pass the max value</param>
        /// <returns></returns>
        public IntFluent AddRange(int min, int max)
        {
            _hasSettings = true;

            if (_ranges == null)
            {
                _ranges = new List<IntRange>();
            }

            _ranges.Add(new IntRange { Id = $"range-{_ranges.Count + 1}",Min = min, Max = max });

            return this;
        }
        /// <summary>
        /// Adds a enum value to the <see cref="IntParam"/>
        /// </summary>
        /// <param name="id">Pass value as id such like 'A'</param>
        /// <param name="value">Pass the corresponding display text</param>
        /// <returns></returns>
        public IntFluent Enum(int id, string value)
        {
            _hasSettings = true;
            if (_enums == null)
            {
                _enums = new List<IntEnumMeta>();
            }

            _enums.Add(new IntEnumMeta {Id = id.ToString(), Enum = id, DisplayText = value});
            return this;
        }

        private void PresetValues()
        {
            _id = null;
            _value = default(int);
            _default = default(int);
            _ranges = null;
            _displayText = null;
            _hasSettings = false;
            _hasUnit = false;
            _unitId = null;
            _unitText = null;
            _enums = null;
        }

        /// <summary>
        /// Creates a <see cref="IntParam"/> out of the passed items
        /// </summary>
        /// <returns></returns>
        public IntParam Build()
        {
            IntParam p = new IntParam
            {
                Id = _id,
                Type = "int-param",
                Value = _value
            };

            if (_hasSettings)
            {
                IntParamMeta s = new IntParamMeta
                {
                    Default = _default,
                    Id = $"{_id}-meta",
                    Type = "int-meta",
                    Ranges = _ranges?.ToArray(),
                    Enum = _enums?.ToArray(),
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