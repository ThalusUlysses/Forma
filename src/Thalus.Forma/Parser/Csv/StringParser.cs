using Thalus.Forma.Fluent;
using Thalus.Forma.Parser.Contracts;

namespace Thalus.Forma.Parser.Csv
{
    /// <summary>
    /// Implements the <see cref="StringParser"/> functionality
    /// </summary>
    public class StringParser : IParser<StringParam>, IParser<Part>, IParser<object>
    {
        private StringFluent _fluent;

        /// <summary>
        /// Creates an instance of <see cref="StringParser"/> initialized with the passed parameters
        /// </summary>
        /// <param name="fluent"></param>
        public StringParser(StringFluent fluent)
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
            if (st.StartsWith("\"") && !st.EndsWith("\""))
            {
                return false;
            }

            if (!st.StartsWith("\"") && st.EndsWith("\""))
            {
                return false;
            }

            return true;
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
        public StringParam Parse(string st, string id = null)
        {
            if (st.StartsWith("\""))
            {
                st = st.Substring(1);
            }

            if (st.EndsWith("\""))
            {
                st = st.Remove(st.Length - 1);
            }

            return _fluent.Id(id).Value(st).Build();
        }
    }
}