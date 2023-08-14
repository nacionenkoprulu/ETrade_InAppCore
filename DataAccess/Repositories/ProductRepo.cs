using AppCore.DataAccess.EntityFramework.Bases;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
    public abstract class ProductRepoBase : RepoBase<Product> //Bağımlılıkları yönetmek için araya bir base class daha koyuyoruz.
    {
        protected ProductRepoBase(DbContext db) : base(db)
        {
        }
    }




    public class ProductRepo : ProductRepoBase //new'leyeceğimiz asıl class
    {
        public ProductRepo(DbContext db) : base(db)
        {
        }
    }
}
