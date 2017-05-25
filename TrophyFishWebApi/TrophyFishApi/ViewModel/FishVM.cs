using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrophyFish.Api.ViewModel
{
    [JsonObject(MemberSerialization.OptOut)]
    public class FishVM
    {
        public int? Id { get; set; }
        public string Length { get; set; }
    }
}
