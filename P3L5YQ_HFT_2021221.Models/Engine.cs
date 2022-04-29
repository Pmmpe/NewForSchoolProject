public enum FuelType
{
    Petrol, Gasoline, LPG, Electric
}
public enum EmissionRate
{
    N0ne, E1, E2, E3, E4, E5
}
namespace P3L5YQ_HFT_2021221.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Text;
    using System.Text.Json.Serialization;
    using System.Threading.Tasks;
    public class Engine
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EngineId { get; set; }
        [Required]
        public string Enginename { get; set; }
        public string EngineType { get; set; }
        public FuelType Fuelage { get; set; }
        public EmissionRate EruroRating { get; set; }
        public double Displacement { get; set; }
        public double Torque { get; set; }
        public int PowerOutput { get; set; }
        [NotMapped]
        [JsonIgnore]
        public virtual ICollection<Car> Cars { get; set; }
    }
}
