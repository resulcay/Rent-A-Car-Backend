using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IColorService
    {
        IDataResult<List<Color>> FetchAll();

        IDataResult<Color> FetchColorById(int colorId);

        IResult AddColor(Color color);
        IResult UpdateColor(Color color);
        IResult DeleteColor(Color color);
    }
}
