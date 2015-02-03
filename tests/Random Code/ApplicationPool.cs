using System;
using System.Linq;
using Extensions;
using Microsoft.Web.Administration;

namespace tests
{
    static class ApplicationPoolHandler
    {

        public static void RestartAllAppPools()
        {
            var appPools = GetAppPools();
            foreach (var action in from ap in appPools let applicationPool = ap select (Action)(ap.StopAppPool))
            {
                action.CallWithTimeout(10000);
            }
            foreach (var action in from ap in appPools let applicationPool = ap select (Action)(ap.StartAppPool))
            {
                action.CallWithTimeout(10000);
            }

        }

        public static ApplicationPoolCollection GetAppPools()
        {
            return new ServerManager().ApplicationPools;
        }


        public static void StopAppPool(this ApplicationPool ap)
        {
            while (ap.State != ObjectState.Stopped)
            {
                switch (ap.State)
                {
                    case ObjectState.Stopping:
                    case ObjectState.Starting:
                    case ObjectState.Stopped:
                        break;
                    case ObjectState.Unknown:
                        Console.WriteLine("{0} is in unknown state. Leaving it alone.", ap.Name);
                        return;
                    case ObjectState.Started:
                        ap.Stop();
                        break;
                }
            }
            Console.WriteLine("{0} stopped.",ap.Name);
        }

        public static void StartAppPool( this ApplicationPool ap)
        {
            while (ap.State != ObjectState.Started)
            {
                switch (ap.State)
                {
                    case ObjectState.Stopping:
                    case ObjectState.Starting:
                    case ObjectState.Started:
                        break;
                    case ObjectState.Unknown:
                        Console.WriteLine("{0} is in unknown state. Leaving it alone.", ap.Name);
                        return;
                    case ObjectState.Stopped:
                        ap.Start();
                        break;
                }
            }
            Console.WriteLine("{0} started.", ap.Name);
        }
    }
}
