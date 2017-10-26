using System.Text;
using Newtonsoft.Json;

namespace Thalus.Forma.Formatter.Json
{
    /// <summary>
    /// Implements the <see cref="Formatter"/> functionality
    /// </summary>
    public class Formatter
    { /// <inheritdoc>
        ///     <cref>IFormatter</cref>
        /// </inheritdoc>
        public string Format(Part[] p)
        {
            return JsonConvert.SerializeObject(p);
        }

        /// <inheritdoc>
        ///     <cref>IFormatter</cref>
        /// </inheritdoc>
        public void Format(Part[] t, StringBuilder b)
        {
            b.Append(Format(t));
        }
    }
}