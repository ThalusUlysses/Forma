using System.Text;
using Newtonsoft.Json;
using Thalus.Forma.Formatter.Contracts;

namespace Thalus.Forma.Formatter.Json
{
    /// <summary>
    /// Implements the <see cref="IntFormatter"/> functionality
    /// </summary>
    public class IntFormatter : IFormatter<IntParam>
    { /// <inheritdoc>
        ///     <cref>IFormatter</cref>
        /// </inheritdoc>
        public string Format(IntParam p)
        {
            return JsonConvert.SerializeObject(p);
        }

        /// <inheritdoc>
        ///     <cref>IFormatter</cref>
        /// </inheritdoc>
        public void Format(IntParam t, StringBuilder b)
        {
            b.Append(Format(t));
        }
    }
}