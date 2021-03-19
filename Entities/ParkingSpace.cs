using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Entities
{
    public class ParkingSpace
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ParkingSpaceId { get; set; }
        public int TotalSlots { get; set; }
        public int ActiveSlots { get; set; }
        public List<Slot> Slots { get; set; }
        public int AllocationManagerId { get; set; }
        public int ParkingManagerId { get; set; }

        public bool hasCleaningService { get; set; }
        public bool isFull { get; set; }

        public int ParkingRate { get; set; }
        public int CleaningRate { get; set; }
        public virtual AllocationManager AllocationManager { get; set; }
        public virtual ParkingManager ParkingManager { get; set; }
    }
}
