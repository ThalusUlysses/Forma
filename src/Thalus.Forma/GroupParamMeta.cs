using System.Runtime.Serialization;

namespace Thalus.Forma
{
    /// <summary>
    /// Implements the <see cref="GroupParamMeta"/> functionality such like <see cref="DisplayText"/>
    /// </summary>
    public class GroupParamMeta : Part
    {
        /// <summary>
        /// Gets or sets the <see cref="DisplayText"/> for a <see cref="GroupParam"/>
        /// as <see cref="string"/>
        /// </summary>
        [DataMember(Name = "display-text")]
        public string DisplayText { get; set; }
    }
}