using System.Runtime.Serialization;

namespace Thalus.Forma
{
    /// <summary>
    /// Implements the <see cref="CharParamMeta"/> functionality such like <see cref="Regex"/>
    /// or <see cref="Default"/>
    /// </summary>
    public class CharParamMeta : Part
    {
        /// <summary>
        /// Gets or sets the defualt value of <see cref="CharParamMeta"/> as <see cref="char"/>
        /// </summary>
        [DataMember(Name = "default", IsRequired = false)]
        public char Default { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="Regex"/> of <see cref="CharParamMeta"/> to validate values against
        /// </summary>
        [DataMember(Name = "regex", IsRequired = false)]
        public string Regex{ get; set; }

        /// <summary>
        /// Gets or sets the <see cref="Enum"/> collection of <see cref="CharParamMeta"/> as <see cref="CharParamMeta"/>[]
        /// </summary>
        [DataMember(Name = "enum", IsRequired = false)]
        public CharEnumMeta[] Enum { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="DisplayText"/> if <see cref="CharParamMeta"/> as <see cref="string"/>.
        /// A user readable string
        /// </summary>
        [DataMember(Name = "display-text", IsRequired = false)]
        public string DisplayText { get; set; }

    }
}