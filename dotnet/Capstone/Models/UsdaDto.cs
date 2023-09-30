using System.Collections.Generic;

namespace Capstone.Models
{
    public class UsdaDto
    {
        public List<UsdaFood> Foods { get; set; }
    }
    public class UsdaFood
    {
        public int FcdId { get; set; }
        public string Description { get; set; }
    }
}
