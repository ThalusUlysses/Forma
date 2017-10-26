using System.Collections.Generic;
using Thalus.Forma.Fluent;
using Thalus.Forma.Parser.Contracts;

namespace Thalus.Forma.Parser.Csv
{

    /// <summary>
    /// Implements the <see cref="Parser"/> functionality
    /// </summary>
    public class Parser :  IParser<Part[]>, IParser<object>
    {
        private IntParser _intParser;
        private DoubleParser _doubleParser;
        private CharParser _charParser;
        private StringParser _stringParser;
        /// <summary>
        /// Creates an instance of <see cref="Parser"/> initialized with the passed parameters
        /// </summary>
        public Parser(GroupFluent p) : this(new IntParser(new IntFluent(p)), new DoubleParser(new DoubleFluent(p)),
            new CharParser(new CharFluent(p)), new StringParser(new StringFluent(p)))
        {
        }

        /// <summary>
        /// Creates an instance of <see cref="Parser"/> initialized with the passed parameters
        /// </summary>
        public Parser(IntParser intParser, DoubleParser doubleParser, CharParser charParser, StringParser stringParser)
        {
            _intParser = intParser;
            _doubleParser = doubleParser;
            _charParser = charParser;
            _stringParser = stringParser;
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

        ///<inheritdoc/>
        public Part[] Parse(string st, string id = null)
        {
            if (id == null)
            {
                id = string.Empty;
            }
            else
            {
                id = $"{id}-";
            }

            List<Part> parst = new List<Part>();
            bool isQuoteOpen = false;
            bool isDoubleQuoteOpen = false;
            List<string> segemets = new List<string>();
            int lastidx = 0;
            for (int i = 0; i < st.Length; i++)
            {
                if (st[i] == ',' && !isQuoteOpen && !isDoubleQuoteOpen)
                {
                    var segmet = st.Substring(lastidx, i - lastidx);
                    segemets.Add(segmet);
                    lastidx = i + 1;
                    continue;

                }

                if (IsDoubleQuote(st[i]))
                {
                    isDoubleQuoteOpen = !isDoubleQuoteOpen;
                    continue;

                }

                if (IsQuote(st[i]))
                {
                    isQuoteOpen = !isQuoteOpen;
                }
            }

            if (lastidx != st.Length)
            {
                var segment = st.Substring(lastidx);
                segemets.Add(segment);
            }

            for (var index = 0; index < segemets.Count; index++)
            {
                string paramId = $"{id}{index + 1}";
                string segemet = segemets[index];
                if (_intParser.CanParse(segemet))
                {
                    parst.Add(_intParser.Parse(segemet, paramId));
                    continue;
                }

                if (_charParser.CanParse(segemet))
                {
                    parst.Add(_charParser.Parse(segemet, paramId));
                    continue;
                }

                if (_doubleParser.CanParse(segemet))
                {
                    parst.Add(_doubleParser.Parse(segemet, paramId));
                    continue;
                }

                if (_stringParser.CanParse(segemet))
                {
                    parst.Add(_stringParser.Parse(segemet, paramId));
                }
            }

            return parst.ToArray();
        }

        bool IsDoubleQuote(char c)
        {
            return c == '"';
        }

        bool IsQuote(char c)
        {
            return c == '\'';
        }

        object IParser<object>.Parse(string part, string id)
        {
            return Parse(part, id);
        }
    }
}