using Core.Interceptors.Utilities.Results;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public interface ICategoryService
    {
        IResult Add(Category category);
    }
}
