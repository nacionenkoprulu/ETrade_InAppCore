using AppCore.Business.Services.Bases;
using Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public interface IProductService : IService<ProductModel>
    {

    }


    public class ProductService : IProductService
    {
        public void Add(ProductModel model)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IQueryable<ProductModel> Query()
        {
            throw new NotImplementedException();
        }

        public void Update(ProductModel model)
        {
            throw new NotImplementedException();
        }
    }
}
