using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace U.Universal
{
    public class FetchOptions
    {

        public HttpVerb method = HttpVerb.GET;
        public Dictionary<string, string> headers = new Dictionary<string, string>();
        public byte[] body = null;
        public int redirectLimit = 20;
        public int timeout = 60;


        public FetchOptions() { }
        public FetchOptions(HttpVerb httpVerb)
        {
            this.method = httpVerb;
        }
        public FetchOptions(string body)
        {
            this.body = Encoding.UTF8.GetBytes(body);
        }
        public FetchOptions(HttpVerb httpVerb, string body)
        {
            this.method = httpVerb;
            this.body = Encoding.UTF8.GetBytes(body);
        }




        public static FetchOptions GetJSON()
        {
            var options = new FetchOptions();

            // Add the headers
            options.headers.Add("Accept", "application/json");

            return options;
        }



        public static FetchOptions PostJSON<TRequest>(TRequest body, Func<TRequest, bool> Validate = null)
        {

            // Validate the request
            if (Validate != null && body != null)
            {
                if (!Validate(body))
                    throw new Exception("Validation Exception");
            }

            // Create the new Options
            var options = new FetchOptions();

            // Set the verb
            options.method = HttpVerb.POST;

            // Add the headers
            options.headers.Add("Content-Type", "application/json");

            // Parse the body
            try
            {
                // Lo agrega el body
                options.body = Encoding.UTF8.GetBytes(JsonUtility.ToJson(body));
            }
            catch (Exception e)
            {
                throw new Exception("Error while Parsing: " + e);
            }


            return options;
        }

        public static FetchOptions PostText(string body, Func<string, bool> Validate = null)
        {
            // Validate
            if (Validate != null && body != null)
            {
                if (!Validate(body))
                    throw new Exception("Validation Exception");
            }

            var options = new FetchOptions();

            // Add the headers
            options.headers.Add("Content-Type", "text/plain");

            options.body = Encoding.UTF8.GetBytes(body);

            return options;

        }

        public static FetchOptions PostForm(WWWForm form, Func<WWWForm, bool> Validate = null)
        {

            // Validate
            if (Validate != null && form != null)
            {
                if (!Validate(form))
                    throw new Exception("Validation Exception");
            }

            var options = new FetchOptions();

            // Add the headers
            options.headers.Add("Content-Type", "application/x-www-form-urlencoded");

            options.body = form.data;

            return options;

        }

    }


}
