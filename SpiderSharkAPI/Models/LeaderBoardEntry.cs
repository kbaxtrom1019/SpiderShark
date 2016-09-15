using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SpiderSharkAPI.Models
{
    public class LeaderboardEntry
    {
        [Required]
        [MaxLength(140)]
        public string UserName { get; set; }
        [Required]
        public int Score { get; set; }
    }
}