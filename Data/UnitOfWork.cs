using UnitOfShop.Data;

namespace UnitOfShop.Data{
    public interface IUnitOfWork{

        void Commit();
        void Rollback();
    }
}
public class UnitOfWork : IUnitOfWork
{
    public readonly DataContext _context;
    public UnitOfWork(DataContext context)
    {
        _context = context;
    }
    public void Commit()
    {
        _context.SaveChanges();
        Console.WriteLine("Success Save Change");
    }

    public void Rollback()
    {
        Console.WriteLine("Success Rollback");
    }
}
