using System.Runtime.Serialization;

namespace Thalus.Forma
{
    /// <summary>
    /// Implements the <see cref="UnitParam"/> functionality sich like <see cref="DisplayText"/>
    /// </summary>
    public class UnitParam : Part
    {

        /// <summary>
        /// Creats an instance of <see cref="UnitParam"/> initialized with defaults
        /// </summary>
        public UnitParam()
        {
            Type = "unit";
        }

        /// <summary>
        /// Gets or sets the <see cref="DisplayText"/> of a <see cref="UnitParam"/> as <see cref="string"/>
        /// </summary>
        [DataMember(Name = "display-text", IsRequired = true)]
        public string DisplayText { get; set; }
    }
}