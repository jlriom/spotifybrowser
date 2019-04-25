using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Newtonsoft.Json;

namespace SpotifyBrowser.Host.ErrorHandling
{
    public class ErrorDetails
    {
        public int StatusCode { get; }
        public Guid ErrorId { get; }
        public string Message { get; }
        public List<string> Details { get; }

        public Exception Ex { get; }

        public ErrorDetails(Exception ex, int statusCode )
        {
            ErrorId = Guid.NewGuid();
            Ex = ex;
            var isApplicationException = Ex is ApplicationException;
            StatusCode = isApplicationException ? (int)HttpStatusCode.BadRequest : statusCode;
            Message = Ex.Message;

            Details = new List<string>();
            if (Ex.InnerException is AggregateException errorDetails)
                Details.AddRange(errorDetails.InnerExceptions.Select( err => err.Message));

            if (Ex.InnerException is Exception error)
                Details.Add(error.Message);

        }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }

        public string ToStringForClient()
        {
            return JsonConvert.SerializeObject(new {
                ErrorId,
                Message,
                Details
            });
        }
    }
}
