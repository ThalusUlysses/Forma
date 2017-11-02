using System;
using System.Collections.Generic;
using System.Linq;

namespace Thalus.Forma.Fluent
{
    /// <summary>
    /// Implements the <see cref="GroupFluent"/> functionality such like <see cref="Double"/>
    /// </summary>
    public class GroupFluent
    {
        private Lazy<List<Part>> _parts;
        private string _id;
        private string _dislayValue;

        private Lazy<DoubleFluent> _double;
        private Lazy<CharFluent> _char;
        private Lazy<StringFluent> _string;
        private Lazy<IntFluent> _int;

        private List<object> _parentFluents;

        public TType Fluent<TType>()
        {
            return (TType)_parentFluents.First(i => i.GetType() == typeof(TType));
        }

        /// <summary>
        /// Creates an instance of <see cref="GroupFluent"/> initialized with defaults
        /// </summary>
        public GroupFluent(params object[] parentFluents)
        {
            _parentFluents = parentFluents?.ToList();
            _double = new Lazy<DoubleFluent>(() => new DoubleFluent(this));
            _char = new Lazy<CharFluent>(() => new CharFluent(this));
            _string = new Lazy<StringFluent>(() => new StringFluent(this));
            _int = new Lazy<IntFluent>(() => new IntFluent(this));

            _parts = new Lazy<List<Part>>(() => new List<Part>());
        }

        /// <summary>
        /// Adds a <see cref="DoubleParam"/> to the <see cref="GroupParam"/> using <see cref="GroupFluent"/>
        /// </summary>
        /// <param name="id">Pass a valid id for parameter</param>
        /// <returns></returns>
        public DoubleFluent Double(string id=null)
        {
            if (id == null)
            {
                id = $"{_id}-{_parts.Value.Count + 1}";
            }
            _double.Value.Id(id);
            return _double.Value;
        }

        /// <summary>
        /// Adds a <see cref="StringParam"/> to the <see cref="GroupParam"/> using <see cref="GroupFluent"/>
        /// </summary>
        /// <param name="id">Pass a valid id for parameter</param>
        /// <returns></returns>
        public StringFluent String(string id=null)
        {
            if (id == null)
            {
                id = $"{_id}-{_parts.Value.Count + 1}";

            }

            _string.Value.Id(id);
            return _string.Value;
        }

        /// <summary>
        /// Adds a <see cref="IntParam"/> to the <see cref="GroupParam"/> using <see cref="GroupFluent"/>
        /// </summary>
        /// <param name="id">Pass a valid id for parameter</param>
        /// <returns></returns>
        public IntFluent Int(string id=null)
        {
            if (id == null)
            {
                id = $"{_id}-{_parts.Value.Count + 1}";

            }
            _int.Value.Id(id);
            return _int.Value;
        }

        /// <summary>
        /// Adds a <see cref="CharParam"/> to the <see cref="GroupParam"/> using <see cref="GroupFluent"/>
        /// </summary>
        /// <param name="id">Pass a valid id for parameter</param>
        /// <returns></returns>
        public CharFluent Char(string id=null)
        {
            if (id == null)
            {
                id = $"{_id}-{_parts.Value.Count + 1}";

            }
            _char.Value.Id(id);
            return _char.Value;
        }
        
        /// <summary>
        /// Adds a <see cref="Part"/> to the <see cref="GroupParam"/>
        /// </summary>
        /// <param name="p">Pass the to be added part</param>
        /// <returns></returns>
        public GroupFluent Add(Part p)
        {
            _parts.Value.Add(p);

            return this;
        }


        /// <summary>
        /// Adds a <see cref="Part"/>[] to the <see cref="GroupParam"/>
        /// </summary>
        /// <param name="p">Pass the to be added parts</param>
        /// <returns></returns>
        public GroupFluent AddRange(Part[] p)
        {
            _parts.Value.AddRange(p);

            return this;
        }

        /// <summary>
        /// Adds a id to the <see cref="GroupParam"/> using <see cref="GroupFluent"/>
        /// </summary>
        /// <param name="id">Pass a valid id for parameter</param>
        /// <returns></returns>
        public GroupFluent Id(string id)
        {
            _id = id;
            return this;
        }

        /// <summary>
        /// Adds a display text to the <see cref="GroupParam"/> using <see cref="GroupFluent"/>
        /// </summary>
        /// <param name="text">Pass a valid text for parameter</param>
        /// <returns></returns>
        public GroupFluent DisplayText(string text)
        {
            _dislayValue = text;
            return this;
        }

        private void PresetValues()
        {
            _id = null;
            _parts = new Lazy<List<Part>>(() => new List<Part>());
            _dislayValue = null;
        }


        /// <summary>
        /// Creates a <see cref="GroupParam"/> out of the passed items
        /// </summary>
        /// <returns></returns>
        public GroupParam Build()
        {
            var grp  = new GroupParam
            {
                Id = _id,
                Type = "group",
                Parts = _parts?.Value.ToArray()
            };


            if (_dislayValue != null)
            {
                grp.Meta = new GroupParamMeta
                {
                    Id = $"{_id}-meta",
                    Type = "group-meta",
                    DisplayText = _dislayValue

                };
            }
            PresetValues();
            return grp;
        }
        
    }

    public static class Extensions
    {
        public static  GroupFluent AddToParams(this DoubleFluent p)
        {
            var item = p.Build();

            var fluent = p.Fluent<GroupFluent>();

            fluent.Add(item);

            return fluent;
        }

        public static GroupFluent AddToParams(this IntFluent p)
        {
            var item = p.Build();

            var fluent = p.Fluent<GroupFluent>();

            fluent.Add(item);

            return fluent;
        }

        public static GroupFluent AddToParams(this CharFluent p)
        {
            var item = p.Build();

            var fluent = p.Fluent<GroupFluent>();

            fluent.Add(item);

            return fluent;
        }

        public static GroupFluent AddToParams(this StringFluent p)
        {
            var item = p.Build();

            var fluent = p.Fluent<GroupFluent>();

            fluent.Add(item);

            return fluent;
        }
    }
}