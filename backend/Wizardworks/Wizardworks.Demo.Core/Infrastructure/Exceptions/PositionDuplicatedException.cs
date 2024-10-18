using static Wizardworks.Demo.Core.Feature.Squares.Model.SquareItemModel;

namespace Wizardworks.Demo.Core.Infrastructure.Exceptions;
public class PositionDuplicatedException(PositionModel position)
    : Exception($"Position '{position}' is duplicated! Please choose another one.")
{
}
