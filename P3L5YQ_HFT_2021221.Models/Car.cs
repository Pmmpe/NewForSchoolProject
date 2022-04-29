namespace P3L5YQ_HFT_2021221.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Text.Json.Serialization;

    public enum Color
    {
        GlossBlack, Red, White, Green, Blue, Yellow, Orange, Shempgane, PearlBlack, PearlWhite, DeepRed
    }
    public class Car
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CarId { get; set; }
        [Required]
        [ForeignKey(nameof(Engine))]
        public int EngineId { get; set; }
        [Required]
        [ForeignKey(nameof(Equipment))]
        public int? TrimPackageId { get; set; }
        [Required]
        public string Type { get; set; }
        public int Mileage { get; set; }
        public bool Condition { get; set; }
        public int Price { get; set; }
        [JsonIgnore]
        public virtual Engine Engine { get; set; }
        [JsonIgnore]
        public virtual TrimLevel Equipment { get; set; }
        public Color ChasisColor { get; set; }
        public int ManufDate { get; set; }
    }
}
