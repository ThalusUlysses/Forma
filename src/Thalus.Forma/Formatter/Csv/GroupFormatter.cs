using System.Text;
using Thalus.Forma.Formatter.Contracts;

namespace Thalus.Forma.Formatter.Csv
{
    /// <summary>
    /// Implements the <see cref="GroupFormatter"/> functionality
    /// </summary>
    public class GroupFormatter : IFormatter<GroupParam>
    {
        private Formatter _formatter;
        /// <summary>
        /// Creates an instance of <see cref="GroupFormatter"/> initialized with defaults
        /// </summary>
        public GroupFormatter() : this(new Formatter())
        {

        }
        /// <summary>
        /// Creates an instance of <see cref="GroupFormatter"/> initialized with passed parameters
        /// </summary>
        public GroupFormatter(Formatter formatter)
        {
            _formatter = formatter;
        }

        /// <inheritdoc>
        ///     <cref>IFormatter</cref>
        /// </inheritdoc>
        public void Format(GroupParam group, StringBuilder b)
        {
            b.Append(group.Id);
            b.Append(" ");

            _formatter.Format(group.Parts, b);
        }

        /// <inheritdoc>
        ///     <cref>IFormatter</cref>
        /// </inheritdoc>
        public string Format(GroupParam t)
        {
            StringBuilder b = new StringBuilder();

            Format(t, b);
            return b.ToString();
        }
    }
}