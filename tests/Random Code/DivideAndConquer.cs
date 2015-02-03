namespace tests
{
//#define compile
#if compile
    class DivideAndConquer
    {
        public T1 TakeAction<T1, T2>(IEnumerable<T2> data, Action methodAction)
        {
            if (data.Count() > 100)
            {
                var splitData = SplitData(data);
                return null;
            }
        }

        private List<List<T2>> SplitData<T2>(IEnumerable<T2> data)
        {
            return data.Select((x, i) => new { Index = i, Value = x }).GroupBy(x => x.Index / 3).Select(x => x.Select(v => v.Value).ToList()).ToList();
        }

    }
#endif
}
