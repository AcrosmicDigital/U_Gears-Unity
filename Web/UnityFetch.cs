using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.Networking;
using UnityEngine;

namespace U.Universal
{
    public static class UnityFetch
    {

        private static async Task<WebResponse> DoFetch(string url, FetchOptions options)
        {
            
            // Creates the request
            UnityWebRequest request = new UnityWebRequest();
            request.uri = new Uri(url);
            request.method = options.method.ToString();
            request.downloadHandler = new DownloadHandlerBuffer();


            // If there are a body creates a UpLoad handler raw and set the content type
            if (options.body != null)
            {
                request.uploadHandler = new UploadHandlerRaw(options.body);
            }


            // Add the custom headers if therea are
            if (options.headers != null)
            {
                foreach (var header in options.headers)
                {
                    request.SetRequestHeader(header.Key, header.Value);
                }
            }


            // Send the request and await for the response, No gameobject needed
            await request.SendWebRequest().WaitAsTask();

            // Check if there are a System or network error and throw it
            if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.DataProcessingError)
            {
                throw new Exception(request.error);
            }

            // Generate the responde with the data recived
            var response = new WebResponse
            {
                status = (HttpStatusCode)request.responseCode,
                headers = request.GetResponseHeaders(),
                body = request.downloadHandler.data,
                ok = request.result == UnityWebRequest.Result.Success,
            };

            // Dispose the request
            request.Dispose();

            // Return the WebResponse object
            return response;

        }

        public static Task<WebResponse> Fetch(string url, FetchOptions options = null)
        {
            // If No Options specified, default options will be used
            if (options == null)
                options = new FetchOptions();

            // Send the fetch
            return DoFetch(url, options);

        }



    }

}
