using System.Text;
using Thalus.Forma.Formatter.Contracts;

namespace Thalus.Forma.Formatter.Csv
{
    /// <summary>
    /// Implements the <see cref="IntFomratter"/> functionality
    /// </summary>
    public class IntFomratter : IFormatter<IntParam>
    {  /// <inheritdoc>
        ///     <cref>IFormatter</cref>
        /// </inheritdoc>
        public void Format(IntParam p, StringBuilder b)
        {
            b.Append(p.Value);
        }

        /// <inheritdoc>
        ///     <cref>IFormatter</cref>
        /// </inheritdoc>
        public string Format(IntParam t)
        {
            StringBuilder b = new StringBuilder();

            Format(t, b);
            return b.ToString();
        }
    }
}