using System.Collections.Generic;
using Microsoft.AspNetCore.Routing;

namespace SpotifyBrowser.Cqrs.Implementation
{
    public class Paging<T>
    {
        public string Href { get; set; }
        public IEnumerable<T> Items { get; set; }
        public int Limit { get; set; }
        public int Offset { get; set; }
        public string Next { get; set; }
        public string Previous { get; set; }
        public int Total { get; set; }

        public Paging(IEnumerable<T> items, int limit, int offset, int total, string href = "", string next = "" , string previous = "" )
        {
            Items = items;
            Limit = limit;
            Offset = offset;
            Total = total;
            Href = href;
            Next = next;
            Previous = previous;
        }
    }
}
