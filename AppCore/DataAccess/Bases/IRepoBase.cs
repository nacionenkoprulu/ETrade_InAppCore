using AppCore.Records.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AppCore.DataAccess.Bases
{

    //public interface IRepoBase<TEntity> 
    // Tip olarak TEntity üzerinden herhangi bir tip kullanacak interface.

    //public interface IRepoBase<TEntity> : where TEntity : class
    // Referans tip olarak TEntity üzerinden herhangi bir tip kullanacak interface.

    //public interface IRepoBase<TEntity> : where TEntity : class, new()
    // new'lenebilen referans tip olarak TEntity üzerinden herhangi bir tip kullanacak interface.

    //public interface IRepoBase<TEntity> : where TEntity : RecordBase, new() 
    // new'lenebilen ve RecordBase'den miras alan tip olarak TEntity üzerinden herhangi bir tip (entity ve model) kullanacak interface.

    public interface IRepoBase<TEntity> : IDisposable where TEntity : RecordBase, new()
    {
        /// <summary>
        /// Entity tipindeki kayıtları ilgili tablosundan ihtiyaca göre ilişkili(Include) entity verilerini de entitiesToInclude parametresi üzerinden dahil ederek getiren sorgu method tanımı.
        /// </summary>
        /// <param name="entitiesToInclude"></param>
        /// <returns>IQueryable</returns>
        IQueryable<TEntity> Query(params Expression<Func<TEntity, object>>[] entitiesToInclude);

        /// <summary>
        /// Entity tipindeki kayıtların ilgili tablosuna eklenmesini sağlayan method tanımı.
        /// Eğer save parametresi true gönderilirse entity parametresi ilgili entity kümesine eklenerek ekleme işlemi veritabanına yansıtılır,
        /// save parametresi false gönderilirse çoklu entity ekleme işlemlerinde önce ilgili entity kümesine entity'ler eklenebilir ve daha sonra Save methodu çağrılarak bu kümedeki tüm eklemeler tek seferde veritabanına yansıtılabilir.
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="save"></param>
        void Add(TEntity entity, bool save = true);

        /// <summary>
        /// Entity tipindeki kayıtların ilgili tablosunda güncellenmesini sağlayan method tanımı.
        /// Eğer save parametresi true gönderilirse entity parametresi ilgili entity kümesinde güncellenerek güncelleme işlemi veritabanına yansıtılır, 
        /// save parametresi false gönderilirse çoklu entity güncelleme işlemlerinde önce ilgili entity kümesinde entity'ler güncellenebilir ve daha sonra Save methodu çağrılarak bu kümedeki tüm güncellemeler tek seferde veritabanına yansıtılabilir.
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="save"></param>
        void Update(TEntity entity, bool save = true);

        /// <summary>
        /// Entity tipindeki kayıtların ilgili tablosundan id parametresi üzerinden silinmesini sağlayan method tanımı.
        /// Eğer save parametresi true gönderilirse entity ilgili entity kümesinden silinerek silme işlemi veritabanına yansıtılır,
        /// save parametresi false gönderilirse çoklu entity silme işlemlerinde önce ilgili entity kümesinden entity'ler silinebilir ve daha sonra Save methodu çağrılarak bu kümedeki tüm silmeler tek seferde veritabanına yansıtılabilir.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="save"></param>
        void Delete(int id, bool save = true);

        /// <summary>
        /// Add, Update veya Delete methodları çağrıldıktan sonra entity kümeleri üzerinden yapılan tüm işlemlerin tek seferde veritabanına yansıtılmasını sağlayan method tanımı.
        /// Yapılan işlem veya işlemler sonucunda ilgili entity tablolarında etkilenen satır sayısını geri döner. İhtiyaç halinde exception loglamaları bu method içerisinde gerçekleştirilebilir. 
        /// </summary>
        /// <returns>int</returns>
        int Save();



    }
}
