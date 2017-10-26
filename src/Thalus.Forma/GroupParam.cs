using System.Runtime.Serialization;

namespace Thalus.Forma
{
    /// <summary>
    /// Implements the <see cref="GroupParam"/> functionality such like 
    /// <see cref="Parts"/> or <see cref="Meta"/>
    /// </summary>
    public class GroupParam : Part
    {
        /// <summary>
        /// Gets or sets the <see cref="Parts"/>[] for a set of parameters
        /// </summary>
        [DataMember(Name="parts", IsRequired = false)]
        public Part[] Parts { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="Meta"/> for a <see cref="GroupParam"/> as <see cref="GroupParamMeta"/>
        /// </summary>
        [DataMember(Name = "meta", IsRequired = false)]
        public GroupParamMeta Meta { get; set; }
    }
}