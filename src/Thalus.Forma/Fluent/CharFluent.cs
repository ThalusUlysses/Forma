using System.Collections.Generic;

namespace Thalus.Forma.Fluent
{
    /// <summary>
    /// Implements the <see cref="CharFluent"/> functionality to hanlde <see cref="CharParam"/>
    /// such like <see cref="Append"/>
    /// </summary>
    public class CharFluent
    {
        private string _id;
        private char _value;
        private char _default;
        private string _regex;
        private bool _hasSettings;
        private string _displayText;
        private string _unitId;
        private string _unitText;
        private bool _hasUnit;
        private List<CharEnumMeta> _enum;

        private GroupFluent _fluent;

        /// <summary>
        /// Appends a <see cref="CharParam"/> to a <see cref="GroupParam"/> using <see cref="GroupFluent"/>
        /// </summary>
        /// <returns></returns>
        public GroupFluent Append()
        {
            _fluent.Add(Build());
            return _fluent;
        }

        /// <summary>
        /// Creates an instance of <see cref="CharFluent"/> initialized with defaults
        /// </summary>
        public CharFluent() : this(new GroupFluent())
        {

        }

        /// <summary>
        /// Creates an instance of <see cref="CharFluent"/> initialized with passed parameters
        /// </summary>
        public CharFluent(GroupFluent fluent)
        {
            _fluent = fluent;
            PresetValues();
        }

        /// <summary>
        /// Adds a unit to the <see cref="CharParam"/>
        /// </summary>
        /// <param name="id">Pass unit identifier such like siml</param>
        /// <param name="text">Pass a user readable text correspoinfing to id</param>
        /// <returns></returns>
        public CharFluent Unit(string id, string text)
        {
            _hasUnit = true;
            _unitId = id;
            _unitText = text;
            return this;
        }


        /// <summary>
        /// Adds a id to the <see cref="CharParam"/>
        /// </summary>
        /// <param name="id">Pass identifier such like myparam</param>
        /// <returns></returns>
        public CharFluent Id(string id)
        {
            _id = id;
            return this;
        }

        /// <summary>
        /// Adds a value to the <see cref="CharParam"/>
        /// </summary>
        /// <param name="val">Pass value such like 'c'</param>
        /// <returns></returns>
        public CharFluent Value(char val)
        {
            _value = val;
            return this;
        }
        /// <summary>
        /// Adds a default value to the <see cref="CharParam"/>
        /// </summary>
        /// <param name="dflt">Pass value such like 'c'</param>
        /// <returns></returns>
        public CharFluent Default(char dflt)
        {
            _hasSettings = true;
            _default = dflt;
            return this;
        }
        /// <summary>
        /// Adds a regex value to the <see cref="CharParam"/> for validation
        /// </summary>
        /// <param name="regex">Pass value such like [A|B|c|D]</param>
        /// <returns></returns>
        public CharFluent Regex(string regex)
        {
            _hasSettings = true;
            _regex = regex;
            return this;
        }

        /// <summary>
        /// Adds a display text value to the <see cref="CharParam"/>
        /// </summary>
        /// <param name="text">Pass value such like"My best char"</param>
        /// <returns></returns>
        public CharFluent DisplayText(string text)
        {
            _displayText = text;
            return this;
        }

        /// <summary>
        /// Adds a enum value to the <see cref="CharParam"/>
        /// </summary>
        /// <param name="id">Pass value as id such like 'A'</param>
        /// <param name="text">Pass the corresponding display text</param>
        /// <returns></returns>
        public CharFluent Enum(char id, string text)
        {
            _hasSettings = true;

            if(_enum == null)
            {
                _enum = new List<CharEnumMeta>();
            }

            _enum.Add(new CharEnumMeta() {Id = id.ToString(), Enum = id, DisplayText = text});
            return this;
        }

        private void PresetValues()
        {
            _id = null;
            _value = default(char);
            _default = default(char);
            _regex = null;
            _enum = null;
            _displayText = null;
            _hasSettings = false;

            _hasUnit = false;
            _unitId = null;
            _unitText = null;
        }

        /// <summary>
        /// Creates a <see cref="CharParam"/> out of the passed items
        /// </summary>
        /// <returns></returns>
        public CharParam Build()
        {
            CharParam p = new CharParam
            {
                Id = _id,
                Type = "char-param",
                Value = _value
            };

            if (_hasSettings)
            {
                CharParamMeta s = new CharParamMeta
                {
                    Default = _default,
                    Id = $"{_id}-meta",
                    Type = "char-meta",
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