using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace U.Universal
{


    public class WebResponse
    {

        public Dictionary<string, string> headers;
        public HttpStatusCode status;
        public byte[] body;
        public bool ok;


        public Task<string> Text(Func<string, bool> Validate = null) => Task.Run(() => 
        {
            string data = body.ToStringUFT8();

            if (Validate != null)
            {
                if (!Validate(data))
                    throw new Exception("Validation Exception");
            }

            return data;

        });


        public Task<TResult> Json<TResult>(Func<TResult, bool> Validate = null) => Task.Run(() =>
        {
            TResult data = body.ToJsonUTF8<TResult>();

            if (Validate != null)
            {
                if (!Validate(data))
                    throw new Exception("Validation Exception");
            }

            return data;

        });



    }



}
