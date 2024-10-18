namespace Wizardworks.Demo.Core.Infrastructure.Exceptions;
public class ColorDuplicatedException(string colorName)
    : Exception($"'{colorName}' is duplicated color! Please choose another one.")
{
}
