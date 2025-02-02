using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BaseLibrary.Entities
{
    public class OvertimeType : BaseEntity
    {
        //Many to one relationship with Overtime
        [JsonIgnore]
        public List<Overtime>? Overtimes { get; set; }
    }
}
