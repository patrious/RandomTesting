using System;
using System.Collections.Generic;

namespace tests.ETL
{
    internal class Load : ILoad
    {
        public Load(object dseConfig)
        {
            throw new NotImplementedException();
        }

        public event EventHandler<string> DataLoadComplete;

        protected virtual void OnDataLoadComplete(string e)
        {
            var handler = DataLoadComplete;
            if (handler != null) handler(this, e);
        }

        public void LoadData(object sender, List<string> e)
        {
            throw new NotImplementedException();
        }
    }

    public interface ILoad
    {
        void LoadData(object sender, List<string> e);
        event EventHandler<string> DataLoadComplete;
    }
}
