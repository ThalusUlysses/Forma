using System.Text;
using Newtonsoft.Json;
using Thalus.Forma.Formatter.Contracts;

namespace Thalus.Forma.Formatter.Json
{
    /// <summary>
    /// Implements the <see cref="CharFormatter"/> functionality
    /// </summary>
    public class CharFormatter : IFormatter<CharParam>
    {
        /// <inheritdoc>
        ///     <cref>IFormatter</cref>
        /// </inheritdoc>
        public void Format(CharParam t, StringBuilder b)
        {
            b.Append(Format(t));
        }

        /// <inheritdoc>
        ///     <cref>IFormatter</cref>
        /// </inheritdoc>
        public string Format(CharParam p)
        {
            return JsonConvert.SerializeObject(p);
        }
    }
}