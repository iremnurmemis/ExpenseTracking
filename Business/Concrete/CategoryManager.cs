using Core.Interceptors.Utilities.Results;
using DataAccess;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class CategoryManager : ICategoryService
    {
        private readonly ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public IResult Add(Category category)
        {
            _categoryDal.Add(category);
            return new SuccessResult("kategori eklendi");
        }

        public IResult Delete(Category category)
        {
            _categoryDal.Delete(category);
            return new SuccessResult("kategori güncellendi");
        }

        public IDataResult<List<Category>> GetAll()
        {
           return new SuccessDataResult<List<Category>>(_categoryDal.GetAll(),"kategoriler listelendi");
        }

        public IDataResult<Category> GetCategoryByCategoryId(int id)
        {
            return new SuccessDataResult<Category>(_categoryDal.Get(c=>c.CategoryId==id), "kategori bilgisi getirildi");
        }

        public IResult Update(Category category)
        {
            _categoryDal.Update(category);
            return new SuccessResult("kategori bilgisi güncellendi");
        }
    }
}
