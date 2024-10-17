using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wizardworks.Demo.Core.Infrastructure.Exceptions;
public class ColorDuplicatedException(string colorName)
    : Exception($"'{colorName}' is duplicated color! Please choose another one.")
{
}
