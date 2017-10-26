using System.Text;
using Newtonsoft.Json;

namespace Thalus.Forma.Formatter.Json
{
    /// <summary>
    /// Implements the <see cref="StringFormatter"/> functionality
    /// </summary>
    public class StringFormatter
    {
        /// <inheritdoc>
        ///     <cref>IFormatter</cref>
        /// </inheritdoc>
        public string Format(StringParam p)
        {
            return JsonConvert.SerializeObject(p);
        }

        /// <inheritdoc>
        ///     <cref>IFormatter</cref>
        /// </inheritdoc>
        public void Format(StringParam t, StringBuilder b)
        {
            b.Append(Format(t));
        }
    }
}