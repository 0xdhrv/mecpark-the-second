using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Entities
{
    public class ParkingHistory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ParkingId { get; set; }
        public string LicensePlateNumber { get; set; }
        public string DriverNamre { get; set; }
        public bool withCleaningService { get; set; }
        public DateTime checkIn { get; set; }
        public DateTime checkOut { get; set; }
        public int Cost { get; set; }
        public TimeSpan Interval { get; set; }
    }
}
