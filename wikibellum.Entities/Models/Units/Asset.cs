using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using wikibellum.Entities.Enums;

namespace wikibellum.Entities.Models.Units
{
    public class Asset
    {
        [Key]
        public int AssetId { get; set; }
        public Classification Classification { get; set; }
        public string ClassificationId { get; set; }
        public Condition? Condition { get; set; }
        public string ConditionId { get; set; } = "0";
        public int Amount { get; set; }
        public AssetType AssetType { get; set; }
        public string EventParticipantId { get; set; }
    }

    public enum AssetType
    {
        Strength,
        Loss
    }
}
