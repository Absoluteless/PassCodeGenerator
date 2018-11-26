using System.Collections.Generic;

namespace MisteryCore
{
    public static class IDictionaryExtension
    {
        public static void AddOrAppend<TKey, TValue>(this IDictionary<TKey, IList<TValue>> dictionary, TKey key, TValue value)
        {
            if (dictionary.TryGetValue(key, out var toList))
                toList.Add(value);
            else
                dictionary[key] = new List<TValue> { value };
        }
    }
}
