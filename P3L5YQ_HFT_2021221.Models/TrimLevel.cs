public enum ChasisType
{
    Coupe, Sedan, Hatchback, Wagon, SUV, Crossover
}
public enum ChasisSize
{
    Three, Five, Slide 
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
    public class TrimLevel
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TrimPackageId { get; set; }
        [Required]
        public string TrimPackageName { get; set; }
        public bool AC { get; set; }
        public bool TwozoneAutomaticAC { get; set; }
        public bool AlloWheels { get; set; }
        public bool AlcantaraInterrior { get; set; }
        public bool RoofRack { get; set; }
        public bool WeightHook { get; set; }
        public ChasisType Chasis { get; set; }
        public ChasisSize NumberofDoors { get; set; }
        [NotMapped]
        [JsonIgnore]
        public virtual ICollection<Car> Cars { get; set; }
    }
}
