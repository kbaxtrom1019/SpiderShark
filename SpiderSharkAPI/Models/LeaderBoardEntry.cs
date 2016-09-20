using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace SpiderSharkAPI.Models
{
    public class LeaderboardEntry
    {
        public string AccountID { get; set; }
        public string UserName { get; set; }
        public int Score { get; set; }
    }
}