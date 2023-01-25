using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Rewardcaller
{
    public class RewardObj
    {
        public string type { get; set; }
        public DateTime timestamp { get; set; }
        public string hash { get; set; }
        public string gateway { get; set; }
        public int block { get; set; }
        public int amount { get; set; }
        public string account { get; set; }

    }

}