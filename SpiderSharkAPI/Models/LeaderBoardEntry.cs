using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Driver;

namespace SpiderSharkAPI.Models
{
    public class LeaderboardEntry
    {
        public ObjectId Id { get; set; } 
        [Required]
        [MaxLength(128)]
        public string AccountID { get; set; }
        [Required]
        [MaxLength(140)]
        public string UserName { get; set; }
        [Required]
        public int Score { get; set; }
    }
}