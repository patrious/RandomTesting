using System;
using System.Data;

namespace tests.ETL
{
    internal class Extraction : IExtraction
    {
        public Extraction(object vbucmConfig)
        {
            throw new NotImplementedException();
        }

        public event EventHandler<DataTable> DataExtractionComplete;

        protected virtual void OnExtractedData(DataTable e)
        {
            var handler = DataExtractionComplete;
            if (handler != null) handler(this, e);
        }

        public void ExtractData()
        {
            throw new NotImplementedException();
        }
    }

    public interface IExtraction
    {
        void ExtractData();
        event EventHandler<DataTable> DataExtractionComplete;
    }
}
