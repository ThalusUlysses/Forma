using Newtonsoft.Json;
using Thalus.Forma.Parser.Contracts;

namespace Thalus.Forma.Parser.Json
{
    /// <summary>
    /// implements the <see cref="DoubleParser"/> functionality
    /// </summary>
    public class DoubleParser : IParser<DoubleParam>
    {
        ///<inheritdoc/>
        public DoubleParam Parse(string st, string id = null)
        {
            return JsonConvert.DeserializeObject<DoubleParam>(st, new DtoConverter());
        }

        ///<inheritdoc/>
        public bool CanParse(string part)
        {
            return true;
        }
    }
}