using Thalus.Forma.Fluent;
using Thalus.Forma.Parser.Contracts;

namespace Thalus.Forma.Parser.Csv
{
    /// <summary>
    /// Implements the <see cref="IntParser"/> functionality
    /// </summary>
    public class IntParser : IParser<IntParam>, IParser<Part>, IParser<object>
    {
        private string _cache;
        private int _parsed;

        private IntFluent _fluent;

        /// <summary>
        /// Creates an instance of <see cref="IntParser"/> initialized with the passed parameters
        /// </summary>
        /// <param name="fluent"></param>
        public IntParser(IntFluent fluent)
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
            int i;
            if (int.TryParse(st, out i))
            {
                _cache = st;
                _parsed = i;
                return true;
            }
            _cache = null;
            _parsed = default(int);

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
        public IntParam Parse(string st, string id = null)
        {
            var p = st == _cache ? _parsed : int.Parse(st);
            return _fluent.Id(id).Value(p).Build();
        }
    }
}
