using System.Runtime.InteropServices;

namespace tests.ETL
{
    public class Etl
    {
        private IExtraction _extraction;
        private ITranslation _translation;
        private ILoad _load;
        private object _configuration;
        #region Contructor
        public Etl(object vbucmConfig, object dseConfig)
        {
            Initialize(new Extraction(vbucmConfig), new Translation(), new Load(dseConfig));
        }

        public Etl(IExtraction extraction, ITranslation translation, ILoad load, object configuration)
        {
            Initialize(extraction, translation, load);
        }

        private void Initialize(IExtraction extraction, ITranslation translation, ILoad load)
        {
            _extraction = extraction;
            _translation = translation;
            _load = load;
            _extraction.DataExtractionComplete += _translation.TranslateData;
            _translation.DataTranslationComplete += load.LoadData;
            
        }

        #endregion

        public void StartEtl()
        {
            _extraction.ExtractData();
        }



    }
}
