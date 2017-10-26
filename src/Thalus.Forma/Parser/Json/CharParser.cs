using Newtonsoft.Json;
using Thalus.Forma.Parser.Contracts;

namespace Thalus.Forma.Parser.Json
{
    /// <summary>
    /// implements the <see cref="CharParser"/> functionality
    /// </summary>
    public class CharParser : IParser<CharParam>
    {
        ///<inheritdoc/>
        public CharParam Parse(string st, string id=null)
        {
            return JsonConvert.DeserializeObject<CharParam>(st, new DtoConverter());
        }

        ///<inheritdoc/>
        public bool CanParse(string part)
        {
            return true;
        }
    }
}