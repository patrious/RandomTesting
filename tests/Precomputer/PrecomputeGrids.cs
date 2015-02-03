using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace tests.Precomputer
{
    class PrecomputeGrids
    {
        static readonly Random Rand = new Random(DateTime.Now.Millisecond);
        private DataGrid mainGrid;
        private DataGrid precomputeGrid;

        /// <summary>
        /// Run the test with the wide and height of the array
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void Run(int x, int y, int max)
        {
            mainGrid = new DataGrid(x, y);
            precomputeGrid = new DataGrid(x, y);
            mainGrid.FillGrid(x, y, max);
            //Need to compute the data!
            Precompute();
            mainGrid.Display();
            precomputeGrid.Display();
            RandomTests(max, x, y);
            Console.ReadLine();
        }

        private void Precompute()
        {
            precomputeGrid.SetDataPoint(new Point(0, 0), mainGrid.GetDataPoint(0, 0));
            for (var i = 0; i < mainGrid.XLength; i++)
            {
                for (var j = 0; j < mainGrid.YLength; j++)
                {
                    var pcValue = precomputeGrid.GetDataPoint(i - 1, j) + precomputeGrid.GetDataPoint(i, j - 1)
                    - precomputeGrid.GetDataPoint(i - 1, j - 1) + mainGrid.GetDataPoint(i, j);
                    precomputeGrid.SetDataPoint(new Point(i, j), pcValue);
                }
            }
        }

        private void RandomTests(int numOfTests, int maxX, int maxY)
        {
            var rand = new Random((int)DateTime.Now.Ticks);
            for (var i = 0; i < numOfTests; i++)
            {
                var p1 = new Point(rand.Next(maxX), rand.Next(maxY));
                var p2 = new Point(rand.Next(maxX), rand.Next(maxY));

                Console.WriteLine("{0} = {1} and {2} = {3} == {4}", p1,precomputeGrid.GetDataPoint(p1), p2,precomputeGrid.GetDataPoint(p2), ComputeRectangle(p1, p2));
            }
        }

        private int ComputeRectangle(Point p1, Point p2)
        {
            if (p1 > p2)
            {
                return precomputeGrid.GetDataPoint(p1.X, p1.Y) - precomputeGrid.GetDataPoint(p2.X, p2.Y);
            }
            if (p1 < p2)
            {
                return precomputeGrid.GetDataPoint(p2.X, p2.Y) - precomputeGrid.GetDataPoint(p1.X, p1.Y);
            }
            return 0;
        }
    }
}
