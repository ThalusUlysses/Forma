using System.Text;
using Thalus.Forma.Formatter.Contracts;

namespace Thalus.Forma.Formatter.Csv
{
    /// <summary>
    /// Implememts the <see cref="StringFormatter"/> functionality
    /// </summary>
    public class StringFormatter : IFormatter<StringParam>
    {
        /// <inheritdoc>
        ///     <cref>IFormatter</cref>
        /// </inheritdoc>
        public void Format(StringParam p, StringBuilder b)
        {
            if (!p.Value.StartsWith("\""))
            {
                b.Append("\"");
            }

            b.Append(p.Value);

            if (!p.Value.EndsWith("\""))
            {
                b.Append("\"");
            }
        }

        /// <inheritdoc>
        ///     <cref>IFormatter</cref>
        /// </inheritdoc>
        public string Format(StringParam t)
        {
            StringBuilder b = new StringBuilder();

            Format(t, b);
            return b.ToString();
        }
    }
}