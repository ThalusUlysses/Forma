using System.Runtime.Serialization;

namespace Thalus.Forma
{
    /// <summary>
    /// Implements the <see cref="IntParam"/> functionality such
    /// like <see cref="Value"/> or <see cref="Meta"/>
    /// </summary>
    public class IntParam : Part
    {
        /// <summary>
        /// Gets or sets the <see cref="Value"/> of the <see cref="IntParam"/> as <see cref="int"/>
        /// </summary>
        [DataMember(Name = "value", IsRequired =false)]
        public int Value { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="Meta"/> data of<see cref="IntParam"/> as <see cref="IntEnumMeta"/>.
        /// Used to add some sugar on the <see cref="int"/>
        /// </summary>
        [DataMember(Name = "meta", IsRequired = false)]
        public IntParamMeta Meta { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="Unit"/> infomration of <see cref="IntEnumMeta"/> as <see cref="UnitParam"/>
        /// </summary>
        [DataMember(Name = "unit", IsRequired = false)]
        public UnitParam Unit { get; set; }
    }
}