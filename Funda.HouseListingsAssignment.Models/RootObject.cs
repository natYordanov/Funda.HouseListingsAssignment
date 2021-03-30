using System.Collections.Generic;

namespace Funda.HouseListingsAssignment.Models
{
    public class RootObject
    {
        public int TotaalAantalObjecten { get; set; }
        public List<RealEstate> Objects { get; set; }
    }
}
