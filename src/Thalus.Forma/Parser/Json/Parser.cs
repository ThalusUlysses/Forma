using Newtonsoft.Json;
using Thalus.Forma.Parser.Contracts;

namespace Thalus.Forma.Parser.Json
{
    /// <summary>
    /// Implements the <see cref="Parser"/> functionality
    /// </summary>
    public class Parser : IParser<Part[]>
    {
        ///<inheritdoc/>

        public bool CanParse(string part)
        {
            throw new System.NotImplementedException();
        }
        ///<inheritdoc/>

        public Part[] Parse(string part, string id = null)
        {
            return JsonConvert.DeserializeObject<Part[]>(part, new DtoConverter());

        }
    }
}