using System.Runtime.Serialization;

namespace Thalus.Forma
{
    /// <summary>
    /// Implements the <see cref="DoubleEnumMeta"/> functinality such like <see cref="Enum"/>
    /// or <see cref="DisplayText"/>
    /// </summary>
    [DataContract(Name = "double-enum-meta")]
    public class DoubleEnumMeta : Part
    {
        /// <summary>
        /// Creates an instance of <see cref="DoubleEnumMeta"/> initialized with
        /// defaults
        /// </summary>
        public DoubleEnumMeta():this("double-enum-meta")
        {
        }

        /// <summary>
        /// Creates an instance of <see cref="DoubleEnumMeta"/> initialized with
        /// the passed parameters
        /// </summary>
        public DoubleEnumMeta(string type)
        {
            Type = type;;
        }

        /// <summary>
        /// Gets or sets the <see cref="Enum"/> value of <see cref="DoubleEnumMeta"/> as <see cref="double"/>
        /// </summary>
        [DataMember(Name = "enum", IsRequired = true)]
        public double Enum { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="DisplayText"/> value of the <see cref="DoubleEnumMeta"/> as <see cref="string"/>
        /// </summary>
        [DataMember(Name = "display-text", IsRequired = true)]
        public string DisplayText { get; set; }
    }
}