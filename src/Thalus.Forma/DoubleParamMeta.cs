using System.Runtime.Serialization;

namespace Thalus.Forma
{
    /// <summary>
    /// Implemenst the <see cref="DoubleParamMeta"/> functionality such like <see cref="Default"/>
    /// or <see cref="Precision"/>
    /// </summary>
    public class DoubleParamMeta : Part
    {
        /// <summary>
        /// Gets or sets the defualt of the <see cref="DoubleParam"/> as <see cref="double"/>
        /// </summary>
        [DataMember(Name = "default",IsRequired = false)]
        public double Default { get; set; }

        /// <summary>
        /// Gets or sets the precision of the <see cref="DoubleParam"/> as <see cref="int"/>
        /// in significant digits
        /// </summary>
        [DataMember(Name = "precision",IsRequired = false)]
        public int Precision { get; set; }

        /// <summary>
        /// Gets or sets a collection of <see cref="DoubleRange"/> that define a set of 
        /// valid ranges fo <see cref="DoubleParam"/>
        /// </summary>
        [DataMember(Name = "ranges", IsRequired =  false)]
        public DoubleRange[] Ranges { get; set; }

        /// <summary>
        /// Gets or sets a collection of enumerable values as <see cref="DoubleParamMeta"/>
        /// for <see cref="DoubleParam"/>
        /// </summary>
        [DataMember(Name = "emun", IsRequired =false)]
        public DoubleEnumMeta[] Enum { get; set; }

        /// <summary>
        /// Gets or sets the display text for the <see cref="DoubleParam"/> as <see cref="string"/>
        /// </summary>
        [DataMember(Name = "display-text")]
        public string DisplayText { get; set; }
    }
}