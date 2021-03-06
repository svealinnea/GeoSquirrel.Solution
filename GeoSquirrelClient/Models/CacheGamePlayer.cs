using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace GeoSquirrelClient.Models
{
    public class CacheGamePlayer
    {
        public int CacheGamePlayerId { get; set; }
        public int CacheGameId { get; set; }
        public int GamePlayerId { get; set; }
        public bool FoundCache { get; set; }
        public Cache Cache { get; set; }

        public Game Game { get; set; }
        public GamePlayer GamePlayer { get; set; }
        public CacheGame CacheGame { get; set; }
    }
}