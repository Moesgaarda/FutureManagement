using System.Collections.Generic;
using System.Reflection;
using API.Models;
using Microsoft.AspNetCore.Http;

namespace API.Helpers
{
    public static class Extensions
    {
        public static void AddApplicationError(this HttpResponse response, string message){
            
            // error message
            response.Headers.Add("Application-Error", message);
            // these headers allow the message to be displayed
            response.Headers.Add("Access-Control-Expose-Headers", "Application-Error");
            response.Headers.Add("Access-Control-Allow-Origin", "*");
        }


        // Used to find differences in the properties of two objects of the same type
        public static List<Variance> DetailedCompare<T>(this T val1, T val2){

            List<Variance> variances = new List<Variance>();
            FieldInfo[] fi = val1.GetType().GetFields();
            foreach (FieldInfo f in fi)
            {
                Variance v = new Variance();
                v.Prop = f.Name;
                v.valA = f.GetValue(val1);
                v.valB = f.GetValue(val2);
                if (!Equals(v.valA, v.valB))
                    variances.Add(v);

            }
            return variances;
        }
    }
}