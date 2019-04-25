using System;

namespace SpotifyApi.Facade.Contracts.Enums
{
    /// <summary>
    ///     Only one value allowed
    /// </summary>
    [Flags]
    public enum TimeRangeType
    {
        [String("long_term")]
        LongTerm = 1,

        [String("medium_term")]
        MediumTerm = 2,

        [String("short_term")]
        ShortTerm = 4
    }
}