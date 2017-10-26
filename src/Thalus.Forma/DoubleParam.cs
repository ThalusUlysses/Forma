using System.Runtime.Serialization;

namespace Thalus.Forma
{
    /// <summary>
    /// Implements the <see cref="DoubleParam"/> functionality such like <see cref="Value"/>
    /// or <see cref="Meta"/>
    /// </summary>
    public class DoubleParam : Part
    {
        /// <summary>
        /// Gets or sets the <see cref="Value"/> of <see cref="DoubleParam"/> as <see cref="double"/>
        /// </summary>
        [DataMember(Name = "value", IsRequired = false)]
        public double Value { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="Meta"/> data of <see cref="DoubleParam"/> as <see cref="DoubleParamMeta"/>
        /// </summary>
        [DataMember(Name = "meta", IsRequired = false)]
        public DoubleParamMeta Meta { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="Unit"/> of <see cref="DoubleParam"/> as <see cref="UnitParam"/>
        /// </summary>
        [DataMember(Name = "unit" , IsRequired = false)]
        public UnitParam Unit { get; set; }
    }
}