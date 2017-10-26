using System.Runtime.Serialization;

namespace Thalus.Forma
{
    /// <summary>
    /// Implements the <see cref="StringParamMeta"/> such like <see cref="Default"/>
    /// </summary>
    public class StringParamMeta :Part
    {
        /// <summary>
        /// Gets or sets the <see cref="Default"/> value of <see cref="StringParam"/> as <see cref="string"/>
        /// </summary>
        [DataMember(Name = "default", IsRequired = false)]
        public string Default { get; set; }
        /// <summary>
        /// Gets or sets the <see cref="Regex"/> value of <see cref="StringParam"/> as <see cref="string"/>
        /// </summary>
        [DataMember(Name = "regex", IsRequired = false)]
        public string Regex { get; set; }

        /// <summary>
        /// Gets or sets a collection of <see cref="StringEnumMeta"/> valuse of <see cref="StringParam"/> as <see cref="StringEnumMeta"/>
        /// </summary>
        [DataMember(Name = "enum", IsRequired = false)]
        public StringEnumMeta[] Enum { get; set; }

        /// <summary>
        /// gets or sets the <see cref="DisplayText"/> of a <see cref="StringParam"/> as <see cref="string"/>.
        /// User readable string
        /// </summary>
        [DataMember(Name = "display-text", IsRequired = false)]
        public string DisplayText { get; set; }
    }
}