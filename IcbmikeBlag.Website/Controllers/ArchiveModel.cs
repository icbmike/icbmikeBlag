using System.Collections.Generic;
using IcbmikeBlag.Models;

namespace IcbmikeBlag.Controllers
{
    public class ArchiveModel : BlagModelBase
    {
        public IEnumerable<ArchiveItemModel> Items { get; set; }
    }
}