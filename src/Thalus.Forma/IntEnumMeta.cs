using System.Runtime.Serialization;

namespace Thalus.Forma
{
    /// <summary>
    /// Implements the <see cref="IntEnumMeta"/> functionality such
    /// like <see cref="DisplayText"/>
    /// </summary>
    public class IntEnumMeta : Part
    {
        /// <summary>
        /// Creates an instance of <see cref="IntEnumMeta"/> initialized with defualts
        /// </summary>
        public IntEnumMeta() : this("int-enum-meta")
        {
        }

        /// <summary>
        /// Creates an instance of <see cref="IntEnumMeta"/> initialized with passed parameters
        /// </summary>
        public IntEnumMeta(string type)
        {
            Type = type;
        }

        /// <summary>
        /// Gets or set the <see cref="DisplayText"/> of <see cref="IntEnumMeta"/> as <see cref="string"/>
        /// and provides a corrsponding display member for <see cref="Enum"/>
        /// </summary>
        [DataMember(Name = "display-text", IsRequired = true)]
        public string DisplayText { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="Enum"/> of the <see cref="IntEnumMeta"/> as <see cref="int"/>
        /// and corresponds with <see cref="DisplayText"/>
        /// </summary>
        [DataMember(Name = "enum")]
        public int Enum { get; set; }
    }
}