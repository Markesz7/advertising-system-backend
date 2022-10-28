using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvertisingSystem.Dal.Entities
{
    public class Ad
    {
        public int Id { get; set; }
        public int Occurence { get; set; }
        //TODO: maybe do this with enums (probably preferred) or with simple boolean
        public string PaymentMethod { get; set; }
        public string URL {  get; set; }
        public TimeOnly? StartTime { get; set; }
        public TimeOnly? EndTime { get; set; }
        public string? SerializedPlaceGroups { get; set; }

        // Entity Framework Core doesn't support Lists of primitives as values,
        // therefore we can store the possible answers in a ; seperated list.
        //TODO: Check if this is the right way to check the nullable list
        [NotMapped]
        public List<string>? PlaceGroups
        {
            get
            {
                if(SerializedPlaceGroups != null)
                    return SerializedPlaceGroups.Split(";").ToList();

                return null;
            }

            set
            {
                if (value != null)
                    SerializedPlaceGroups = string.Join(";", value);
                else SerializedPlaceGroups = null;
            }
        }

        public Ad(string paymentMethod, string url)
        {
            PaymentMethod = paymentMethod;
            URL = url;
        }

    }
}
