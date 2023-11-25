using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Shared;

public class BaseEntity<TId>
{
    public TId Id { get; set; }
    [JsonIgnore] public DateTime CreatedDate { get; set; }
    [JsonIgnore] public DateTime? UpdatedDate { get; set; }
    [JsonIgnore] public DateTime? DeletedDate { get; set; }
}
