using System.ComponentModel.DataAnnotations.Schema;

namespace AdvertisingSystem.Dal.Entities
{
    public class AdBan
    {
        public int Id { get; set; }
        public TimeOnly? StartTime { get; set; }
        public TimeOnly? EndTime { get; set; }
        public string? SubstituteAdURL { get; set; }
        public string? SerializedVehicleNames { get; set; }
        [NotMapped]
        public List<string> VehicleNames
        {
            get
            {
                if (SerializedVehicleNames != null)
                    return SerializedVehicleNames.Split(";").ToList();

                return new List<string>();
            }

            set
            {
                if (value.Count != 0)
                    SerializedVehicleNames = string.Join(";", value);
                else SerializedVehicleNames = null;
            }
        }
        //Foreign key
        public int AdId { get; set; }

        //Navigation properties
        public Ad Ad { get; set; } = null!;
        public ICollection<AdTransportline> AdTransportlines { get; } = new List<AdTransportline>();
        //public ICollection<Transportline> Transportlines { get; } = new List<Transportline>();

    }
}
