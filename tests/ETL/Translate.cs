using System;
using System.Collections.Generic;
using System.Data;

namespace tests.ETL
{
    internal class Translation : ITranslation
    {
        public event EventHandler<List<string>> DataTranslationComplete;

        protected virtual void OnDataTranslationComplete(List<string> e)
        {
            var handler = DataTranslationComplete;
            if (handler != null) handler(this, e);
        }

        public void TranslateData(object sender, DataTable e)
        {
            throw new NotImplementedException();
        }
    }

    public interface ITranslation
    {
        void TranslateData(object sender, DataTable e);
        event EventHandler<List<string>> DataTranslationComplete;
    }

}
