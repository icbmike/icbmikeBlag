using System.Collections.Generic;
using IcbmikeBlag.Models;

namespace IcbmikeBlag.Controllers
{
    public class ArchiveModel : BlagModelBase
    {

        public Dictionary<int, Dictionary<int, Dictionary<int, List<ArchiveItemModel>>>> Items { get; set; } 

    }
}