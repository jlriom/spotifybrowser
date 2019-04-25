using System;

namespace SpotifyApi.Facade.Contracts
{
    public sealed class StringAttribute : Attribute
    {
        public string Text { get; set; }

        public StringAttribute(string text)
        {
            Text = text;
        }
    }
}