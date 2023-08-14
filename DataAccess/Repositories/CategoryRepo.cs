using AppCore.DataAccess.EntityFramework.Bases;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public abstract class CategoryRepoBase : RepoBase<Category> //Bağımlılıkları yönetmek için araya bir base class daha koyuyoruz.
    {
        protected CategoryRepoBase(DbContext db) : base(db)
        {
        }
    }


    //CategryRepo repo = new CategoryRepo(new ETradeContext());
    public class CategoryRepo : CategoryRepoBase //new'leyeceğimiz asıl class
    {
        public CategoryRepo(DbContext db) : base(db)
        {
        }
    }
}
