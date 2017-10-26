using System.Runtime.Serialization;

namespace Thalus.Forma
{
    /// <summary>
    /// Implements the <see cref="CharParam"/> functionality such like <see cref="Meta"/>
    /// or <see cref="Value"/>
    /// </summary>
    public class CharParam : Part
    {
        /// <summary>
        /// Gets or sets the <see cref="Value"/> of <see cref="CharParam"/> as <see cref="char"/>
        /// </summary>
        [DataMember(Name = "value", IsRequired = false)]
        public char Value { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="Meta"/> data of <see cref="CharParam"/> as <see cref="CharParamMeta"/>
        /// </summary>
        [DataMember(Name = "meta",IsRequired = false)]
        public CharParamMeta Meta { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="Unit"/> of <see cref="CharParam"/> as <see cref="UnitParam"/>
        /// </summary>
        [DataMember(Name = "unit", IsRequired =  false)]
        public UnitParam Unit { get; set; }
        
    }
}