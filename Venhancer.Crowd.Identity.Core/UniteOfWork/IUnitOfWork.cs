namespace Venhancer.Crowd.Identity.Core.UniteOfWork
{
    public interface IUnitOfWork
    {
        Task CommitAsync();
        void Commit();
    }
}
