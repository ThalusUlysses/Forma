using System.Text;

namespace Thalus.Forma.Formatter.Contracts
{
    /// <summary>
    /// Publishes the public members of <see cref="IFormatter{T}"/> suhc like
    /// <see cref="Format(TType)"/>
    /// </summary>
    /// <typeparam name="TType">Typoe of format</typeparam>
    public interface IFormatter<in TType>
    {
        /// <summary>
        /// Foramats a <see>
        ///         <cref>TType</cref>
        ///     </see>
        ///     to <see cref="StringBuilder"/>
        /// </summary>
        /// <param name="t"></param>
        /// <param name="b"></param>
        void Format(TType t, StringBuilder b);
        /// <summary>
        /// Foramats a <see>
        ///         <cref>TType</cref>
        ///     </see>
        ///     to <see cref="string"/>
        /// </summary>
        /// <param name="t"></param>
        string Format(TType t);
    }
}
