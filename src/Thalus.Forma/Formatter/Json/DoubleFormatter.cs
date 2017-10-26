using System.Text;
using Newtonsoft.Json;

namespace Thalus.Forma.Formatter.Json
{/// <summary>
 /// Implements the <see cref="DoubleFormatter"/> functionality
 /// </summary>
    public class DoubleFormatter
    { /// <inheritdoc>
        ///     <cref>IFormatter</cref>
        /// </inheritdoc>
        public string Format(DoubleParam p)
        {
            return JsonConvert.SerializeObject(p);
        }

        /// <inheritdoc>
        ///     <cref>IFormatter</cref>
        /// </inheritdoc>
        public void Format(DoubleParam t, StringBuilder b)
        {
            b.Append(Format(t));
        }
    }
}