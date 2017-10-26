using System.Runtime.Serialization;

namespace Thalus.Forma
{
    /// <summary>
    /// implements the <see cref="StringEnumMeta"/> functionality such like 
    /// <see cref="Enum"/>
    /// </summary>
    public class StringEnumMeta : Part
    {
        /// <summary>
        /// Creates an instance of <see cref="StringEnumMeta"/> initialized with defaults
        /// </summary>
        public StringEnumMeta() : this("string-enum-meta")
        {

        }

        ///<summary>
        /// Creates an instance of <see cref="StringEnumMeta"/> initialized with passed parameters
        /// </summary>
        public StringEnumMeta(string type)
        {
            Type = type;
        }

        /// <summary>
        /// Gets or sets the <see cref="Enum"/> value of a <see cref="StringParam"/> as <see cref="string"/>
        /// </summary>
        [DataMember(Name = "enum", IsRequired = true)]
        public string Enum { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="DisplayText"/> value of a <see cref="StringParam"/> as <see cref="string"/>
        /// </summary>
        [DataMember(Name = "display-text", IsRequired = true)]
        public string DisplayText { get; set; }


    }
}