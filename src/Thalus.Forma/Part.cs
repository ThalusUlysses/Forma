using System.Runtime.Serialization;

namespace Thalus.Forma
{
    /// <summary>
    /// Implements the <see cref="Part"/> functionality such like 
    /// <see cref="Type"/>
    /// </summary>
    public class Part
    {
        /// <summary>
        /// Gets or sets the <see cref="Type"/> property of object as <see cref="string"/>
        /// </summary>
        [DataMember(Name = "type", IsRequired = true)]
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="Id"/> property of object as <see cref="string"/>
        /// </summary>
        [DataMember(Name = "id",IsRequired = true)]
        public string Id { get; set; }
    }
}
