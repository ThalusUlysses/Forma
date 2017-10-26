using System.Runtime.Serialization;

namespace Thalus.Forma
{
    /// <summary>
    /// Implements the <see cref="CharEnumMeta"/> functionality such like <see cref="Enum"/>
    /// </summary>
    [DataContract(Name = "char-enum-meta")]
    public class CharEnumMeta : Part
    {
        /// <summary>
        /// Creates an instance of <see cref="CharEnumMeta"/> with defaults
        /// </summary>
        public CharEnumMeta() : this("char-enum-meta")
        {
        }

        /// <summary>
        /// Creates an instance of <see cref="CharEnumMeta"/> with passed parameters
        /// </summary>
        /// <param name="type"></param>
        public CharEnumMeta(string type)
        {
            Type = type; ;
        }

        /// <summary>
        /// Gets or sets the enum value of <see cref="CharEnumMeta"/> as <see cref="char"/>
        /// </summary>
        [DataMember(Name = "enum",IsRequired =  true)]
        public char Enum { get; set; }

        /// <summary>
        /// Gets or sets the display text that corresponds with <see cref="CharEnumMeta.Enum"/> as <see cref="string"/>
        /// </summary>
        [DataMember(Name = "display-text", IsRequired = true)]
        public string DisplayText { get; set; }
    }
}