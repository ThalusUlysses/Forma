using System.Runtime.Serialization;

namespace Thalus.Forma
{
    /// <summary>
    /// Implements the <see cref="IntParamMeta"/> functionality such like
    /// <see cref="Default"/> or <see cref="Ranges"/>
    /// </summary>
    public class IntParamMeta : Part
    {
        /// <summary>
        /// Gets or sets the <see cref="Default"/> value of <see cref="IntParam"/> as <see cref="int"/>
        /// </summary>
        [DataMember(Name = "default", IsRequired = false)]
        public int Default { get; set; }

        /// <summary>
        /// Gets or sets a collection of <see cref="IntRange"/> for <see cref="IntParam"/>
        /// </summary>
        [DataMember(Name = "ranges", IsRequired = false)]
        public IntRange[] Ranges { get; set; }

        /// <summary>
        /// Gets or sets a collection of <see cref="IntEnumMeta"/> for <see cref="IntParam"/>
        /// </summary>
        [DataMember(Name = "enum", IsRequired = false)]
        public IntEnumMeta[] Enum { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="DisplayText"/> of the <see cref="IntParam"/> as <see cref="string"/>.
        /// A User readable string
        /// </summary>
        [DataMember(Name = "display-text", IsRequired = false)]
        public string DisplayText { get; set; }
    }
}