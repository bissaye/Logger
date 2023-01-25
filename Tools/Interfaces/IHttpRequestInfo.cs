using Microsoft.AspNetCore.Http;
using Microsoft.CSharp.RuntimeBinder;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger.Tools.Interfaces
{
    public interface IHttpRequestInfo
    {
        public static string requestBody;

        public static  List<dynamic> getOutGoingErrorCode(string requestBodyMemStream)
        {
            var body = requestBodyMemStream;
            string httpCode = IDisplay._response.StatusCode.GetHashCode().ToString();
            int errorCode;
            dynamic jsonObject;
            
            try
            {
                jsonObject = JsonConvert.DeserializeObject<dynamic>(body);
            }
            catch(Exception)
            {
                jsonObject = null;
                Console.WriteLine("Format json invalid");
            }            
            
            try
            {
                errorCode = jsonObject.errorNumber;
            }
            catch (RuntimeBinderException)
            {
                try
                {
                    errorCode = jsonObject.ErrorNumber;
                }
                catch (RuntimeBinderException)
                {
                    try
                    {
                        errorCode = jsonObject.errorCode;
                    }
                    catch (RuntimeBinderException)
                    {
                        return new List<dynamic>() { httpCode, "-" };
                    }
                }
            }
            return new List<dynamic>() { httpCode, errorCode };
        }
        public List<dynamic> getInComingErrorCode();
        public string getCorrelationId();
        public string getRequestBody();
        
    }
}
