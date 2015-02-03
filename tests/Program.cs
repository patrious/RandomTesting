using System;
using LeaderSorter;
using LeaderSorter.DataSource;

namespace tests
{
    static class Program
    {


        public static void Main()
        {
            var datasource = new LeaderSorterTestDataGenerator();
            var gc = new GeneticAlgorithmConfig(40);
            var ls = new LeaderSorting(datasource);
            var gal = new GeneticAlgorithmLogic(ls, gc);
            gal.RunAlgorithm();
            Console.ReadLine();

        }
    }
}
