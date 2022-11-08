using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericMathDemo
{
    public interface ITableEntity
    {
        int Id { get; }

        static abstract IEnumerable<string> DefaultVisibleProperties { get; }
        static abstract IDictionary<string, string> PropertyTranslationKeys { get; }
    }

    /// <summary>
    /// API Model for Person
    /// </summary>
    public class Person : ITableEntity
    {
        public int Id { get; set; }

        public string FullName { get; set; }

        public static IEnumerable<string> DefaultVisibleProperties
        {
            get
            {
                yield return nameof(FullName);
            }
        }

        public static IDictionary<string, string> PropertyTranslationKeys =>
            new Dictionary<string, string>
            {
                { nameof(FullName), "TableHeaders_PersonFullName" }
            };
    }
}
