using System;
using System.Text;
using Thalus.Forma.Formatter.Contracts;

namespace Thalus.Forma.Formatter.Csv
{
    /// <summary>
    /// Implements the <see cref="DoubleFormatter"/> functionality
    /// </summary>
    public class DoubleFormatter : IFormatter<DoubleParam>
    {
        /// <inheritdoc>
        ///     <cref>IFormatter</cref>
        /// </inheritdoc>
        public void Format(DoubleParam p, StringBuilder b)
        {
            string format;
            double val;
            if (p.Meta != null)
            {
                int digits = p.Meta.Precision;
                val = Math.Round(p.Value, digits);
                format = $"F{digits}";
            }
            else
            {
                val = p.Value;
                format = "F";
            }

            b.Append(val.ToString(format));
        }

        /// <inheritdoc>
        ///     <cref>IFormatter</cref>
        /// </inheritdoc>
        public string Format(DoubleParam t)
        {
            StringBuilder b = new StringBuilder();

            Format(t, b);
            return b.ToString();
        }
    }


}