#nullable disable

using AppCore.DataAccess.Bases;
using AppCore.Records.Bases;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace AppCore.DataAccess.EntityFramework.Bases
{
    public abstract class RepoBase<TEntity> : IRepoBase<TEntity> where TEntity : RecordBase, new()
    {

        //Dışarıdan alınan db context ne olursa olsun bu class'a enjekte ederek o db context'in kullanılmasını sağlıyoruz.
        //Örneğin personel sistemi yapacaksan bu class aşağıdaki new'leme üzerinden gönderiyorsun.
        //PersonelDbContext _db = new PersonelDbContext()
        //Repo<Product> repo = new Repo(db);
        

        protected readonly DbContext _db; 

        protected RepoBase(DbContext db)
        {
            _db = db;
                
        }

        //Böylece aşağıdaki metodu örnekteki gibi uygulayabilirsin.
        //var query = repo.Query(product => product.Categories, product => product.ProductStores); yapabilirsin.
        // Gönderilen parametre "Include" edileceklerin parametresidir.

        //Aşağıda bunu Select sorgusuyla nasıl birleştireceğine dair bir örnek vardır.
        
        public virtual IQueryable<TEntity> Query(params Expression<Func<TEntity, object>>[] entitiesToInclude)
        {
            var query = _db.Set<TEntity>().AsQueryable();

            foreach (var entityToInclude in entitiesToInclude)
            {
                query = query.Include(entityToInclude);
            }

            return query;
        }

        /*
            var products = productRepo.Query().Select(product => new ProductModel()
            {
                Id = product.Id,
                Guid = product.Guid,
                
                Name = product.Name,
                UnitPrice = product.UnitPrice,

                UnitPriceDisplay = product.UnitPrice.ToString("C2", new CultureInfo("en-US"))
            }).ToList();
        */


        // Yada Bu metodun bir diğer overload'ı olan halini kullanabilirsin.
        // Böylece aşağıdaki örnekte olduğu gibi "where" sorgusuna da parametre göndererek tek bir kayıt da dönebilirsin.
        // List<Products> products = Repo.Query(product => product.Id == 13).ToList();
        public virtual IQueryable<TEntity> Query(Expression<Func<TEntity,bool>> predicate, params Expression<Func<TEntity, object>>[] entitiesToInclude)
        {

            var query = Query(entitiesToInclude);

            return query.Where(predicate);

        }


        public virtual void Add(TEntity entity, bool save = true)
        {
            //RecordBase implamente ettiğimiz için Id ve Guid'e ulaşabiliyoruz. Böyle hiç bir işlem yapmadan her add işleminde yeni Guid belirlemiş oluyoruz. Örneğin OlusturmaTarihi diye bir prop olsaydı onuda burada DateTime.Now diyerek oluşturma zamanını otomatik gönderebilirdik.
            entity.Guid = Guid.NewGuid().ToString();

            // _db.Kisi.Add(yeniKisi) gibi olacak.
            // Gönderilen db set enjekte olacak.
            // _db.Set<Kisi>() --> _db.Kisi(yeniKisi)

            _db.Set<TEntity>().Add(entity);

            //Add'e save true gelirse eklenenleri veritabanına savechanges ediyor. Her add işleminde veritabanında sorgu çalıştırmaması için bunu yapıyoruz.
            if (save) 
                Save();
            
        }


        public virtual void Update(TEntity entity, bool save = true)
        {
            _db.Set<TEntity>().Update(entity);

            if (save)
            {
                Save();    
            }
        }


        public virtual void Delete (TEntity entity, bool save = true)
        {
            _db.Set<TEntity>().Remove(entity);

            if (save)
                Save();
        }

        //Delete işlemleri genelde id üzerinden yapıldığı için Delete() metodunun overload'ını da yazdık.
        public virtual void Delete(int id, bool save= true)
        {

            //var entity = _db.Set<TEntity>().SingleOrDefault(e => e.Id == id);
            var entity = _db.Set<TEntity>().Find(id);

            Delete(entity, save);

        }


        public virtual void Delete(Expression <Func<TEntity, bool>> predicate, bool save = true)
        {

            //Toplu silmeler için de  Expression Func'lı overload yazdık. Bu şekilde belirli bir koşula göre toplu silme yapabiliyoruz.

            var entites = _db.Set<TEntity>().Where(predicate).ToList();

            foreach (var entity in entites)
            {
                Delete(entity, false);
            }

            if (save)
                Save();

        }

        public virtual int Save()
        {
            //Veritabanı işlemi olduğu için Try Catch yaptık
            try
            {
                return _db.SaveChanges();
            }
            catch (Exception exc)
            {
                // başka bir veritabanına, dosyaya, Windows Event Log'una loglama kodları yazılabilir
                throw exc;
            }
        }

        public void Dispose()
        {

            //_db ile yapılan işlemlerin ardından hafızayı yormamak için garbage collectore gönderen metod.
            _db?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
