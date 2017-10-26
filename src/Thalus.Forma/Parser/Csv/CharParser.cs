using Thalus.Forma.Fluent;
using Thalus.Forma.Parser.Contracts;

namespace Thalus.Forma.Parser.Csv
{
    /// <summary>
    /// Implements the <see cref="CharParser"/> functionality
    /// </summary>
    public class CharParser : IParser<CharParam>, IParser<Part>, IParser<object>
    {
        private string _cache;
        private char _parsed;
        private CharFluent _fluent;

        /// <summary>
        /// Creates an instance of <see cref="CharParser"/> initialized with the passed parameters
        /// </summary>
        /// <param name="fluent"></param>
        public CharParser(CharFluent fluent)
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
            if (st.Length == 3)
            {
                if (!st.StartsWith("\'") || !st.EndsWith("\'"))
                {
                    return false;
                }

                st = $"{st[1]}";
            }
            else if (st.Length != 1)
            {
                return false;
            }

            char i;
            if (char.TryParse(st, out i))
            {
                _cache = st;
                _parsed = i;
                return true;
            }
            _cache = null;
            _parsed = default(char);

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
        public CharParam Parse(string st, string id = null)
        {
            if (st.Length == 3)
            {
                st = $"{st[1]}";
            }

            var p = st == _cache ? _parsed : st.ToCharArray()[0];
            return _fluent.Id(id).Value(p).Build();
        }
    }
}