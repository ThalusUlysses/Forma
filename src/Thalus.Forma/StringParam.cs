using System.Runtime.Serialization;

namespace Thalus.Forma
{
    /// <summary>
    /// Implements the <see cref="StringParam"/> functionality such
    /// like <see cref="Value"/>
    /// </summary>
    public class StringParam : Part
    {
        /// <summary>
        /// Gets or sets the <see cref="Value"/> of a <see cref="StringParam"/> as <see cref="string"/>
        /// </summary>
        [DataMember(Name = "value",IsRequired = false)]
        public string Value { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="Meta"/> of a <see cref="StringParam"/> as <see cref="StringParamMeta"/>
        /// </summary>
        [DataMember(Name = "meta", IsRequired = false)]
        public StringParamMeta Meta { get; set; }
        /// <summary>
        /// Gets or sets the <see cref="Unit"/> of a <see cref="StringParam"/> as <see cref="UnitParam"/>
        /// </summary>
        [DataMember(Name = "unit", IsRequired = false)]
        public UnitParam Unit { get; set; }
    }
}