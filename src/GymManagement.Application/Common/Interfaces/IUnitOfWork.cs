namespace GymManagement.Application.Common.Interfaces;

public interface IUnitOfWork
{
  /// <summary>
  /// The Infrastructure layer will implement this method using the
  /// Entity Framework's SaveChangesAsync method which is using
  /// the Unit of Work pattern.
  /// </summary>
  /// <returns></returns>
  Task CommitChangesAsync();
}
