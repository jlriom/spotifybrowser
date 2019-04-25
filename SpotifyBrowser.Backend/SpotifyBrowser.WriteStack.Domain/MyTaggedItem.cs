using System;
using System.Collections.Generic;
using System.Linq;
using SpotifyBrowser.Domain;

namespace SpotifyBrowser.WriteStack.Domain
{
    public class MyTaggedItem: IAggregate
    {
        public string Id { get; }
        public string UserId { get; }
        private readonly Dictionary<string, string> _tags; 

        public List<string> Tags => _tags.Keys.ToList();

        public string Type { get; }

        public MyTaggedItem(string type, string id, string userId, IEnumerable<string> tags)
        {
            Type = type;
            Id = id;
            UserId = userId;
            _tags = tags.ToDictionary(tag => tag);
        }

        public void AddTag(string tag)
        {
            if (ContainsTag(tag)) throw new ApplicationException($"'{Type}' is tagged with tag '{tag}' yet!");
            _tags.Add(tag, tag);
        }

        public void Untag(string tag)
        {
            if (!ContainsTag(tag)) throw new ApplicationException($"'{Type}' is not tagged with tag '{tag}'");
            _tags.Remove(tag);
        }

        public bool ContainsTag(string tag)
        {
            return _tags.ContainsKey(tag);
        }
    }
}
