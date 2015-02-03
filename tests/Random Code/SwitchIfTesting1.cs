

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tests.Random_Code
{
    class SwitchIfTesting1
    {
        enum MyEnum
        {
            a, b, c, d, e, f, g, h, i, j, k, l, m, n, o, p, q, r, s, t, u, v, w, x, y, z
        }

        public void Run()
        {
            var rand = new Random((int) DateTime.Now.Ticks);
        }


        private void ifStatement(MyEnum enu, Action work)
        {
            if (enu == MyEnum.a)
                work();
            if (enu == MyEnum.b)
                work();
            if (enu == MyEnum.c)
                work();
            if (enu == MyEnum.d)
                work();
            if (enu == MyEnum.e)
                work();
            if (enu == MyEnum.f)
                work();
            if (enu == MyEnum.g)
                work();
            if (enu == MyEnum.h)
                work();
            if (enu == MyEnum.i)
                work();
            if (enu == MyEnum.j)
                work();
            if (enu == MyEnum.k)
                work();
            if (enu == MyEnum.l)
                work();
            if (enu == MyEnum.m)
                work();
            if (enu == MyEnum.n)
                work();
            if (enu == MyEnum.o)
                work();
            if (enu == MyEnum.p)
                work();
            if (enu == MyEnum.q)
                work();
            if (enu == MyEnum.r)
                work();
            if (enu == MyEnum.s)
                work();
            if (enu == MyEnum.t)
                work();
            if (enu == MyEnum.u)
                work();
            if (enu == MyEnum.v)
                work();
            if (enu == MyEnum.w)
                work();
            if (enu == MyEnum.x)
                work();
            if (enu == MyEnum.y)
                work();
            if (enu == MyEnum.z)
                work();

        }

        private void caseStatement(MyEnum enu, Action work)
        {
            switch (enu)
            {
                case MyEnum.a:
                    work();
                    break;
                case MyEnum.b:
                    work();
                    break;
                case MyEnum.c:
                    work();
                    break;
                case MyEnum.d:
                    work();
                    break;
                case MyEnum.e:
                    work();
                    break;
                case MyEnum.f:
                    work();
                    break;
                case MyEnum.g:
                    work();
                    break;
                case MyEnum.h:
                    work();
                    break;
                case MyEnum.i:
                    work();
                    break;
                case MyEnum.j:
                    work();
                    break;
                case MyEnum.k:
                    work();
                    break;
                case MyEnum.l:
                    work();
                    break;
                case MyEnum.m:
                    work();
                    break;
                case MyEnum.n:
                    work();
                    break;
                case MyEnum.o:
                    work();
                    break;
                case MyEnum.p:
                    work();
                    break;
                case MyEnum.q:
                    work();
                    break;
                case MyEnum.r:
                    work();
                    break;
                case MyEnum.s:
                    work();
                    break;
                case MyEnum.t:
                    work();
                    break;
                case MyEnum.u:
                    work();
                    break;
                case MyEnum.v:
                    work();
                    break;
                case MyEnum.w:
                    work();
                    break;
                case MyEnum.x:
                    work();
                    break;
                case MyEnum.y:
                    work();
                    break;

                case MyEnum.z:
                    work();
                    break;
                default:
                    throw new ArgumentOutOfRangeException("enu");
            }
        }
    }
}
