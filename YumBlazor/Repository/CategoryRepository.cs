using YumBlazor.Data;
using YumBlazor.Repository.IRepository;

namespace YumBlazor.Repository;

public class CategoryRepository(ApplicationDbContext db) : ICategoryRepository
{
    public Category? Create(Category? obj)
    {
        if (obj == null)
        {
            Console.WriteLine("카테고리 정보가 없습니다.");
            return null;

            // 굳이 개발자를 위한 코드중단까지는 필요가 없다고 함
            // throw new ArgumentNullException(nameof(obj), "카테고리 정보가 없습니다.");
        }

        db.Category.Add(obj);
        db.SaveChanges();
        return obj;
    }

    public Category Update(Category obj)
    {
        var objFromDb = db.Category.FirstOrDefault(c => c.Id == obj.Id);
        if (objFromDb == null)
        {
            return obj;
        }
        objFromDb.Name = obj.Name;
        db.SaveChanges();
        return objFromDb;
    }

    public bool Delete(int id)
    {
        var obj = db.Category.Find(id); // Find는 ID로 직접 찾는 데 효율적
        if (obj == null)
        {
            return false; // 해당 ID의 데이터가 없으면 삭제 실패
        }

        db.Category.Remove(obj); // 삭제
        db.SaveChanges(); // 저장
        return true; // 삭제 성공
    }


    public Category Get(int id)
    {
        var obj = db.Category.FirstOrDefault(u => u.Id == id);
        if (obj == null)
        {
            return new Category();
        }
        return obj;
    }

    public IEnumerable<Category> GetAll()
    {
        return db.Category.ToList();
    }
}