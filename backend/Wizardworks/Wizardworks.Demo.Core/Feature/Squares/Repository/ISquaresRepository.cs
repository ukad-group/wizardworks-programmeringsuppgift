using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wizardworks.Demo.Core.Feature.Squares.Model;

namespace Wizardworks.Demo.Core.Feature.Squares.Repository;
public interface ISquaresRepository
{
    Task<SquaresModel> GetByIdAsync(string clientId);
    Task<SquaresModel> AddAsync(string clientId, SquareItemModel square);
}
