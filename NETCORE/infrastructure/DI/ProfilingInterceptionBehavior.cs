using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Unity.Attributes;
using Unity.Interception.InterceptionBehaviors;
using Unity.Interception.PolicyInjection.Pipeline;

namespace Target_NETCORE.DI
{
    public class ProfilingInterceptionBehavior : IInterceptionBehavior
    {
        [Dependency]
        public ILog Log { get; set; }

        public IMethodReturn Invoke(IMethodInvocation input,
            GetNextInterceptionBehaviorDelegate getNext)
        {
            var startTime = DateTime.Now;
            var result = getNext()(input, getNext);

            //if (!input.MethodBase.Name.ToLower().Contains("debug"))

            //This behavior will record the start and stop time
            //of a method and will log the method name and elapsed time.
            //Get the current time.

            //Log the start time of the method.
            //This could be ommitted if you just want to see the response times of a method.
            //WriteLog(String.Format(
            //  "Invoking method {0} at {1}",
            //  input.MethodBase, startTime.ToLongTimeString()));

            //string Params = "";
            //        foreach (var item in input.Arguments)
            //        {
            //            if (Log.IsDebugEnabled&&   item != null)
            //            {
            //                string Itemstr = JsonConvert.SerializeObject(item,
            //Formatting.None,
            //new JsonSerializerSettings()
            //{
            //    ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            //});
            //                Params += Itemstr + " , ";

            //            }
            //            else
            //            {
            //                Params += " null " + " , ";
            //            }
            //        }



            //  WriteLog(String.Format(
            //"Method {0} Takes Arguments {1} ",
            //input.MethodBase, Params));

            // Invoke the next behavior in the chain.

            //Calculate the elapsed time.
            var endTime = DateTime.Now;
            var timeSpan = endTime - startTime;


            //The following will log the method name and elapsed time.
            if (result.Exception != null)
            {

                //Method threw an exception.
                WriteExecptionLog(String.Format(
                  "Method {0} threw exception {1} at {2}.  Elapsed Time: {3} ms",
                  input.MethodBase, result.Exception.Message,
                  endTime.ToLongTimeString(),
                  timeSpan.TotalMilliseconds));
            }
            else
            {
                //Method completed normally.
                //WriteLog(String.Format(
                //  "Method {0} returned {1} at {2}.  Elapsed Time: {3} ms",
                //  input.MethodBase, result.ReturnValue,
                //  endTime.ToLongTimeString(),
                //  timeSpan.TotalMilliseconds));
            }
            //$"{Environment.NewLine}Method {0} returned {1} at {2}.  Elapsed Time: {3} ms"

            return result;
        }

        public IEnumerable<Type> GetRequiredInterfaces()
        {
            return Type.EmptyTypes;
        }

        public bool WillExecute
        {
            get { return true; }
        }

        private void WriteLog(string message)
        {
            if (Log != null)
            {
                //if (!message.ToLower().Contains("Method debug"))
                {
                    Log.DebugFormat("Profiler: {0}", message);
                }
            }
        }
        private void WriteExecptionLog(string message)
        {
            if (Log != null)
            {
                //if (!message.ToLower().Contains("Method debug"))
                {
                    Log.ErrorFormat("Profiler: {0}", message);
                }
            }
        }
    }
    public static class TypeFiltres
    {
        public static IEnumerable<Type> WithMatchingInterface(this IEnumerable<Type> types)
        {
            return types.Where(type =>
                type.GetTypeInfo().GetInterface("I" + type.Name) != null);
        }
    }
}
