using System.Text;
using Thalus.Forma.Formatter.Contracts;

namespace Thalus.Forma.Formatter.Csv
{
    /// <summary>
    /// Implemenst the <see cref="CharFormatter"/> functionality such like <see cref="Format(Thalus.Forma.CharParam)"/>
    /// </summary>
    public class CharFormatter : IFormatter<CharParam>
    {
        /// <inheritdoc>
        ///     <cref>IFormatter</cref>
        /// </inheritdoc>
        public void Format(CharParam p, StringBuilder b)
        {
            b.Append("'");
            b.Append(p.Value);
            b.Append("'");
        }

        /// <inheritdoc>
        ///     <cref>IFormatter</cref>
        /// </inheritdoc>
        public string Format(CharParam t)
        {
            StringBuilder b = new StringBuilder();

            Format(t, b);
            return b.ToString();
        }
    }
}

