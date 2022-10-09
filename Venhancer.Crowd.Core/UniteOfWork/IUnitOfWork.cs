namespace Venhancer.Crowd.Core.UniteOfWork
{
    public interface IUnitOfWork
    {
        Task CommitAsync();
        void Commit();
    }
}
