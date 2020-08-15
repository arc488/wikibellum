using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using wikibellum.Entities.Models.Units;

namespace wikibellum.App.Components
{
    public partial class UnitList : ComponentBase
    {
        [Parameter]
        public List<IBelligerentUnit> Units { get; set; }
    }
}
