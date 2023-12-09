using Assignment.API.Controllers;
using Assignment.API.Models;
using System.Text.Json.Serialization;

namespace AssignmentHafta2.API.QueryParameters
{
    public class SortParameters
    {
        public string Name = nameof(Product.Id);
        public Ordering Order = Ordering.Asc;
        public SortParameters(string name, Ordering order)
        {
            Name = name;
            Order = order;
        }


        public SortParameters()
        {
            
        }
    }
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum Ordering
    {
        Asc,
        Desc
    }
}
