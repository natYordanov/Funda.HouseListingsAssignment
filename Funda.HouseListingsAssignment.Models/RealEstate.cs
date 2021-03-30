using System;

namespace Funda.HouseListingsAssignment.Models
{
    public class RealEstate
    {
        public Guid Id { get; set; }
        public int MakelaarId { get; set; }

        public string MakelaarNaam { get; set; }
    }
}
