using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DePoolseNationaleVlag
{
    public class Stone
    {
        public CustomEnums.Colors Color { get; private set; }

        public Stone(CustomEnums.Colors color)
        {
            Color = color;
        }
    }
}
