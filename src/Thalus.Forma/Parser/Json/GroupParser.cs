using Newtonsoft.Json;
using Thalus.Forma.Parser.Contracts;

namespace Thalus.Forma.Parser.Json
{
    /// <summary>
    /// Implements the <see cref="GroupParser"/> functionality
    /// </summary>
    public class GroupParser : IParser<GroupParam>
    {
        ///<inheritdoc/>

        public GroupParam Parse(string st, string id = null)
        {
            return JsonConvert.DeserializeObject<GroupParam>(st, new DtoConverter());
        }


        ///<inheritdoc/>
        public bool CanParse(string part)
        {
            return true;
        }
    }
}