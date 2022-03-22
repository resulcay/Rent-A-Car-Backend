using Business.Abstract;
using Business.ValidationRules.FluentValiation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ColorManager : IColorService
    {
        IColorDal colorDal;

        public ColorManager(IColorDal iColorDal)
        {
            colorDal = iColorDal;
        }

        public IDataResult<List<Color>> FetchAll()
        {
            if (DateTime.Now.Year == 2000)
            {
                return new ErrorDataResult<List<Color>>("Colors has not listed");
            }
            return new SuccessDataResult<List<Color>>(colorDal.FetchAll(), "Colors has listed");
        }

        public IDataResult<Color> FetchColorById(int colorId)
        {
            if (DateTime.Now.Year == 2000)
            {
                return new ErrorDataResult<Color>("Color has not listed");
            }
            return new SuccessDataResult<Color>(colorDal.Fetch(c => c.Id == colorId), "Color has listed");
        }


        [ValidationAspect(typeof(ColorValidator))]

        public IResult AddColor(Color color)
        {
            if (DateTime.Now.Year == 1950)
            {
                return new ErrorResult("Color has not added");
            }
            return new SuccessResult("Color has added");
        }
        public IResult UpdateColor(Color color)
        {
            if (DateTime.Now.Year == 1950)
            {
                return new ErrorResult("Color has not updated");
            }
            return new SuccessResult("Color has updated");
        }
        public IResult DeleteColor(Color color)
        {
            if (DateTime.Now.Year == 1950)
            {
                return new ErrorResult("Color has not deleted");
            }
            return new SuccessResult("Color has deleted");
        }

    }
}
