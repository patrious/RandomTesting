using System;
using System.IO;
using Extensions;

namespace tests.Random_Code
{
    class JsonTest
    {
        public void Run()
        {
            const string json =
                "{\"responseHeader\":{\"status\":0,\"QTime\":15,\"params\":{\"shard.shuffling.strategy\":\"SEED\",\"start\":\"0\",\"q\":\"*:*\",\"shard.shuffling.seed\":\"2015640232\",\"query_id\":\"67a8e4a6-da24-49cf-b6b0-b35464aba7e7\",\"wt\":\"json\",\"fq\":\"NumberOfInvolvements:[2 TO *]\",\"rows\":\"0\"}},\"response\":{\"numFound\":83,\"start\":0,\"maxScore\":1.0,\"docs\":[]}}";


            var serializer = new JsonSerializer();

            var stream = new MemoryStream(json.GetBytes());
            var textReader = new StreamReader(stream);
            object foo;
            
            
            Console.ReadLine();
        }
    }
}
