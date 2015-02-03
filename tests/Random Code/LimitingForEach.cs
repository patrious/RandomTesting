using System.Collections.Generic;
using System.Linq;

namespace tests
{
    public class LimitingForEach<T,T1>
    {
        private readonly IDictionary<T,T1> _globalcollection;
        public LimitingForEach(IDictionary<T,T1> collection)
        {
            _globalcollection = collection;
        }

        public KeyValuePair<T, T1>? GetNext()
        {
            return GetNext(_globalcollection);
        }

        private KeyValuePair<T, T1>? GetNext(IDictionary<T, T1> dictionary)
        {
            if (dictionary.Count <= 0)
                return null;
            var result = dictionary.ElementAt(0);
            dictionary.Remove(result);
            return result;
        }
    }
}
