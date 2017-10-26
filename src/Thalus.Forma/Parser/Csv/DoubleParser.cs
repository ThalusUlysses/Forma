using Thalus.Forma.Fluent;
using Thalus.Forma.Parser.Contracts;

namespace Thalus.Forma.Parser.Csv
{/// <summary>
 /// Implements the <see cref="DoubleParser"/> functionality
 /// </summary>
    public class DoubleParser : IParser<DoubleParam>, IParser<Part>, IParser<object>
    {
        private string _cache;
        private double _parsed;
        private DoubleFluent _fluent;

        /// <summary>
        /// Creates an instance of <see cref="DoubleParser"/> initialized with the passed parameters
        /// </summary>
        public DoubleParser(DoubleFluent fluent)
        {
            _fluent = fluent;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="st"></param>
        /// <returns></returns>
        public bool CanParse(string st)
        {
            if (!st.Contains("."))
            {
                return false;
            }

            double i;
            if (double.TryParse(st, out i))
            {
                _cache = st;
                _parsed = i;
                return true;
            }
            _cache = null;
            _parsed = default(double);

            return false;
        }

        object IParser<object>.Parse(string part, string id)
        {
            return Parse(part, id);
        }

        Part IParser<Part>.Parse(string part, string id)
        {
            return Parse(part, id);
        }
        ///<inheritdoc/>
        public DoubleParam Parse(string st, string id = null)
        {
            var p = st == _cache ? _parsed : double.Parse(st);
            return _fluent.Id(id).Value(p).Precison(st).Build();
        }
    }
}