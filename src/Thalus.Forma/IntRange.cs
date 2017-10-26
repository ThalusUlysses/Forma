using System.Runtime.Serialization;

namespace Thalus.Forma
{
    /// <summary>
    /// Implements th e<see cref="IntRange"/> functionality such
    /// like <see cref="Min"/>
    /// </summary>
    public class IntRange : Part
    {
        /// <summary>
        /// Creates an instance of <see cref="IntRange"/> initialized with defaults
        /// </summary>
        public IntRange()
        {
            Type ="int-range";
        }

        /// <summary>
        /// Gets or sets the min value of <see cref="IntRange"/> for a <see cref="IntParam"/>
        /// as <see cref="int"/> 
        /// </summary>
        [DataMember(Name = "min", IsRequired = true)]
        public int Min { get; set; }

        /// <summary>
        /// Gets or sets the max value of <see cref="IntRange"/> for a <see cref="IntParam"/>
        /// as <see cref="int"/> 
        /// </summary>
        [DataMember(Name = "max", IsRequired = true)]
        public int Max { get; set; }
    }
}