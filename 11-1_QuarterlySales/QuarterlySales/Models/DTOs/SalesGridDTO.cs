using Newtonsoft.Json;

namespace QuarterlySales.Models
{
    public class SalesGridDTO : GridDTO
    {
        [JsonIgnore]
        public const string DefaultFilter = "all";
        public string Year { get; set; } = DefaultFilter;
        public string Quarter { get; set; } = DefaultFilter;
        public string Employee { get; set; } = DefaultFilter;
        public string Amount { get; set; } = DefaultFilter;
    }
}
