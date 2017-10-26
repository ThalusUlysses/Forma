using System.Linq;
using System.Text;
using Thalus.Forma.Formatter.Contracts;

namespace Thalus.Forma.Formatter.Csv
{
    /// <summary>
    /// Implements the <see cref="Formatter"/> functionality
    /// </summary>
    public class Formatter : IFormatter<Part[]>
    {
        private IntFomratter _int;
        private CharFormatter _char;
        private DoubleFormatter _double;
        private StringFormatter _string;
        private char _appendChar;
        /// <summary>
        /// Creates an instance of <see cref="Formatter"/> initialized with defaults
        /// </summary>
        public Formatter() : this(new IntFomratter(), new CharFormatter(), new DoubleFormatter(),
            new StringFormatter(), ',')
        {
        }
        /// <summary>
        /// Creates an instance of <see cref="Formatter"/> initialized with passed parameters
        /// </summary>
        public Formatter(char appendChar) : this(new IntFomratter(), new CharFormatter(), new DoubleFormatter(),
            new StringFormatter(), appendChar)
        {
        }
        /// <summary>
        /// Creates an instance of <see cref="Formatter"/> initialized with passed parameters
        /// </summary>
        public Formatter(IntFomratter i, CharFormatter c, DoubleFormatter d, StringFormatter s, char appendChar)
        {
            _int = i;
            _char = c;
            _double = d;
            _string = s;
            _appendChar = appendChar;
        }

        /// <inheritdoc>
        ///     <cref>IFormatter</cref>
        /// </inheritdoc>
        public string Format(Part[] t)
        {
            StringBuilder b = new StringBuilder();

            Format(t, b);
            return b.ToString();
        }

        /// <inheritdoc>
        ///     <cref>IFormatter</cref>
        /// </inheritdoc>
        public void Format(Part[] parts, StringBuilder b)
        {
            foreach (Part part in parts)
            {
                switch (part.Type)
                {
                    case "double-param":
                        _double.Format(part as DoubleParam, b);
                        break;
                    case "int-param":
                        _int.Format(part as IntParam, b);
                        break;
                    case "char-param":
                        _char.Format(part as CharParam, b);
                        break;
                    case "string-param":
                        _string.Format(part as StringParam, b);
                        break;
                }

                if (parts.Last() != part)
                {
                    b.Append(_appendChar);
                }
            }
        }
    }
}