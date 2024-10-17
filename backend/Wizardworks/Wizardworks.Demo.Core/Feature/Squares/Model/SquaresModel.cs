using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wizardworks.Demo.Core.Feature.Squares.Model;
public record SquaresModel
{
    public List<SquareItemModel> Squares { get; set; } = [];
}
