using Pluralize.NET;
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
        public int? UnitId { get; set; }
        [ForeignKey("UnitId")]
        public Unit? Unit { get; set; }
        [ForeignKey("ConditionId")]
        public Condition? Condition { get; set; }
        public int ConditionId { get; set; }
        public int Amount { get; set; }
        public AssetType AssetType { get; set; }
        public int EventParticipantId { get; set; }
        [NotMapped]
        public string DisplayName
        {
            get
            {
                IPluralize pluralizer = new Pluralizer();
                pluralizer.AddUncountableRule("personnel");
                string formatString = Amount ==  0 ? "{1}" : "{0} {1}";
                var displayName = string.Format(formatString, Amount.ToString(), Amount > 1 ? pluralizer.Pluralize(Unit.Name) : Unit.Name);
                if (AssetType == AssetType.Loss) displayName = string.Format("{0} {1}", displayName, Condition.Name.ToLower());
                return displayName;
            }
            set
            {

            }
        }
    }
    
    public enum AssetType
    {
        Strength,
        Loss
    }
}
