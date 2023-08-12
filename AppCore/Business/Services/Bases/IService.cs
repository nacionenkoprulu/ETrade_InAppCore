using AppCore.Records.Bases;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCore.Business.Services.Bases
{

    //Servisler model --> Entity tip dönüşümlerini yapar. 

    public interface IService<TModel> : IDisposable where TModel : RecordBase, new()
    {

        IQueryable<TModel> Query(); // Read işlemi

        void Add(TModel model); //Create, insert

        void Update(TModel model); // Update

        void Delete(int id); //Delete


        //Aşağıdakiler de isteğe bağlı olarak eklenebilir. Query sorgusunu list veya item'a dönüştürmeye yarayan metodlar.
       
        //List<TModel> List();

        //TModel GetItem(int id);


    }
}
