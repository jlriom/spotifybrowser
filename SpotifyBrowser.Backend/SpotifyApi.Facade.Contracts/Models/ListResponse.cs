using System.Collections.Generic;

namespace SpotifyApi.Facade.Contracts.Models
{
    public class ListResponse<T> : BasicModel
    {
        public List<T> List { get; set; }
    }
}