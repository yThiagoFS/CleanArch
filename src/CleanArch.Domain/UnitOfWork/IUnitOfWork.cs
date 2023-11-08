namespace CleanArch.Domain.UnitOfWork
{
    public interface IUnitOfWork
    {
        Task Commit();

        Task Rollback();
    }
}
