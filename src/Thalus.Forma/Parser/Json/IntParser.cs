using Newtonsoft.Json;
using Thalus.Forma.Parser.Contracts;

namespace Thalus.Forma.Parser.Json
{
    /// <summary>
    /// Implements the <see cref="IntParser"/> functionality
    /// </summary>
    public class IntParser : IParser<IntParam>
    {
        ///<inheritdoc/>

        public bool CanParse(string part)
        {
            return true;
        }

        ///<inheritdoc/>

        public IntParam Parse(string part, string id = null)
        {
            return JsonConvert.DeserializeObject<IntParam>(part, new DtoConverter());

        }
    }
}