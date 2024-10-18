using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wizardworks.Demo.Core.Feature.Squares.Model;
public record SquareItemModel
{
    public required string Color { get; set; }
    public required PositionModel Position { get; set; }
    public record PositionModel
    {
        public required int X { get; set; }
        public required int Y { get; set; }
    }
}
