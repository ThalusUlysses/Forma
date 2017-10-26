namespace Thalus.Forma.Parser.Contracts
{
    /// <summary>
    /// Publishes the public memebers of <see cref="IParser{T}"/> such like <see cref="CanParse"/>
    /// </summary>
    /// <typeparam name="TType"></typeparam>
    public interface IParser<out TType>
    {
        /// <summary>
        /// Predicates if parser can handle the sparsing
        /// </summary>
        /// <param name="part"></param>
        /// <returns></returns>
        bool CanParse(string part);

        /// <summary>
        /// Parses a passed <see cref="string"/>
        /// </summary>
        /// <param name="part"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        TType Parse(string part, string id = null);
    }
}
