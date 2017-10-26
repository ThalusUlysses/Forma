using Thalus.Forma.Fluent;
using Thalus.Forma.Parser.Contracts;

namespace Thalus.Forma.Parser.Csv
{
    /// <summary>
    /// Implements the <see cref="GroupParser"/> functionality
    /// </summary>
    public class GroupParser : IParser<GroupParam>, IParser<Part>, IParser<object>
    {
        private GroupFluent _fluent;
        private Parser _parser;

        /// <summary>
        /// Creates an instance of <see cref="GroupParser"/> initialized with defaults
        /// </summary>
        public GroupParser() : this(new GroupFluent())
        {

        }
        /// <summary>
        /// Creates an instance of <see cref="GroupParser"/> initialized with the passed parameters
        /// </summary>
        public GroupParser(GroupFluent fluent) : this(fluent, new Parser(fluent))
        {

        }
        /// <summary>
        /// Creates an instance of <see cref="GroupParser"/> initialized with the passed parameters
        /// </summary>
        public GroupParser(GroupFluent fluent, Parser parser)
        {
            _fluent = fluent;
            _parser = parser;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="st"></param>
        /// <returns></returns>
        public bool CanParse(string st)
        {
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
        public GroupParam Parse(string st, string id = null)
        {
            int idx = st.IndexOf(' ');
            string param = st.Substring(idx + 1);
            if (id == null)
            {
                id = st.Substring(0, idx);

            }
            var pars = _parser.Parse(param, id);

            return _fluent.Id(id).AddRange(pars).Build();
        }
    }
}