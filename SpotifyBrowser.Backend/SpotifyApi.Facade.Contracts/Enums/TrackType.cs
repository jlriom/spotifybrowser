﻿using System;

namespace SpotifyApi.Facade.Contracts.Enums
{
    [Flags]
    public enum TrackType
    {
        [String("track")]
        Track = 1,

        [String("episode")]
        Episode = 2,

        [String("ad")]
        Ad = 4,

        [String("unknown")]
        Unknown = 8
    }
}