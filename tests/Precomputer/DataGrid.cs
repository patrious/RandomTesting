using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tests.Precomputer
{
    class DataGrid
    {
        private readonly int[,] _grid;

        public int XLength
        {
            get { return _grid.GetLength(0); }
        }

        public int YLength
        {
            get { return _grid.GetLength(1); }
        }

        public DataGrid(int x, int y)
        {
            _grid = new int[x, y];
        }

        public void FillGrid(int x, int y, int max)
        {
            var rand = new Random(DateTime.Now.Millisecond);
            for (var i = 0; i < _grid.GetLength(0); i++)
            {
                for (var j = 0; j < _grid.GetLength(1); j++)
                {
                    _grid[i, j] = rand.Next(max);
                }
            }
        }

        public void SetDataPoint(Point point,int data)
        {
            if (point.X < 0 || point.Y < 0 || point.X > _grid.GetLength(0) || point.Y > _grid.GetLength(1))
                throw  new ArgumentException();
            _grid[point.X, point.Y] = data;
        
        
        }

        public int GetDataPoint(Point p)
        {
            return GetDataPoint(p.X, p.Y);
        }

        public int GetDataPoint(int x, int y)
        {
            //make sure there are not out of bounds and return the value;
            if (x < 0 || y < 0)
                return 0;
            if (x > _grid.GetLength(0) || y > _grid.GetLength(1))
                return 0;
            return _grid[x, y];
        }

        public void Display()
        {
            for (int i = 0; i < _grid.GetLength(0); i++)
            {
                for (int j = 0; j < _grid.GetLength(1); j++)
                {
                    Console.Write("{0},",_grid[i,j]);
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        
    }
}
