using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using wikibellum.Entities.Enums;

namespace wikibellum.Entities.Models.Units
{
    public class Asset
    {
        [Key]
        public int AssetId { get; set; }
        public int ClassificationId { get; set; }
        [ForeignKey("ClassificationId")]
        public Classification Classification { get; set; }
        [NotMapped]
        public string ClassificationIdString { get; set; }
        [ForeignKey("ConditionId")]
        public Condition? Condition { get; set; }
        public int ConditionId { get; set; }
        [NotMapped]
        public string ConditionIdString { get; set; }
        public int Amount { get; set; }
        public AssetType AssetType { get; set; }
        public int EventParticipantId { get; set; }
    }

    public enum AssetType
    {
        Strength,
        Loss
    }
}
