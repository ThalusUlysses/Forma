using System.Text;
using Newtonsoft.Json;
using Thalus.Forma.Formatter.Contracts;

namespace Thalus.Forma.Formatter.Json
{

    /// <summary>
    /// Implements the <see cref="GroupFormatter"/> functionality
    /// </summary>
    public class GroupFormatter : IFormatter<GroupParam>
    { 
        /// <inheritdoc>
        ///     <cref>IFormatter</cref>
        /// </inheritdoc>
        public void Format(GroupParam p, StringBuilder b)
        {
            b.Append(JsonConvert.SerializeObject(p));
        }
        /// <inheritdoc>
        ///     <cref>IFormatter</cref>
        /// </inheritdoc>
        public string Format(GroupParam t)
        {
            StringBuilder b = new StringBuilder();

            Format(t, b);
            return b.ToString();
        }
    }
}