using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLayerApp.Core.Entities.Base;

namespace NLayerApp.Core.Entities
{
    public class Category : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
    }
}
