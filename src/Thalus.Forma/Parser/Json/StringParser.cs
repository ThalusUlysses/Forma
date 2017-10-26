using Newtonsoft.Json;
using Thalus.Forma.Parser.Contracts;

namespace Thalus.Forma.Parser.Json
{    /// <summary>
     /// Implements the <see cref="StringParser"/> functionality
     /// </summary>

    public class StringParser : IParser<StringParam>
    {
        ///<inheritdoc/>

        public bool CanParse(string part)
        {
            throw new System.NotImplementedException();
        }
        ///<inheritdoc/>

        public StringParam Parse(string part, string id = null)
        {
            return JsonConvert.DeserializeObject<StringParam>(part, new DtoConverter());
        }
    }
}