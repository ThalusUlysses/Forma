using System.Runtime.Serialization;

namespace Thalus.Forma
{

    /// <summary>
    /// Implements the <see cref="DoubleRange"/>functionality such like
    /// <see cref="Min"/> of <see cref="Max"/>
    /// </summary>
    public class DoubleRange : Part
    {
        /// <summary>
        /// Creates an instance of <see cref="DoubleRange"/>
        /// </summary>
        public DoubleRange()
        {
            Type = "double-range";
        }

        /// <summary>
        /// Gets or sets the min value of the <see cref="DoubleParam"/> as <see cref="double"/>
        /// for a <see cref="DoubleParam"/>
        /// </summary>
        [DataMember(Name = "min",IsRequired = true)]
        public double Min { get; set; }

        /// <summary>
        /// Gets or sets the max value of the <see cref="DoubleParam"/> as <see cref="double"/>
        /// for a <see cref="DoubleParam"/>
        /// </summary>
        [DataMember(Name = "max", IsRequired = true)]
        public double Max { get; set; }
    }
}