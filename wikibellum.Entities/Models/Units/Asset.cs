using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using wikibellum.Entities.Enums;

namespace wikibellum.Entities.Models.Units
{
    public class Asset : IBelligerentAsset
    {
        [Key]
        public int AssetId { get; set; }
        public string Classification { get; set; }
        public Condition Condition { get; set; }
        public int Amount { get; set; }
        public AssetType AssetType { get; set; }
    }

    public enum AssetType
    {
        Strength,
        Loss
    }
}
