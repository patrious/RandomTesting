using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Threading;
using Extensions;
using Microsoft.SqlServer.Server;

namespace tests
{
    class StringTesting
    {

        public void Run()
        {
            const string name = @"::::::::::::::::::::::::::::::::::::::/\/\/\/|?|?#$%|?#|?%|?%|?#|?|!@?|?&|?|*?|?*|?|@#```\/`\`/`\`\`\`\`\`\`\\\a\a\a\a\`\`\`/\`/\`/\`\\\\\\\\\\a";


            //Cleanout and invalid characters
            var invalid = Path.GetInvalidFileNameChars().ToList();

            var contentName = name;

            var tempName = contentName;
            Func<string> code = () => invalid.Aggregate(tempName, (current, badChar) => current.Replace(badChar, '_'));
            contentName = (string)TestHarness.TimeStatistic("Replacing Characters Aggregate:", 50, code);

            Thread.Sleep(100);

            contentName = name;
            var code2 = new Action(() => invalid.ForEach(invalidChar => contentName = contentName.Replace(invalidChar, '_')));
            TestHarness.TimeStatistic("Replacing Characters ForEach:", 50, code2);


            var info = new FileInfo(contentName);
            Console.ReadLine();
        }
    }
}
