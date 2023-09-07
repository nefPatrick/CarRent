using Zbw.CarRent.CustomerManagement.Domain;

namespace Zbw.CarRent.General.Infrastructure.Persistence {
  public interface IRepository<T> {

    IEnumerable<T> GetAll();

    T? Get(Guid id);

    void Add(T value);

    void Remove(Guid id);

    void Update(T value);

  }
}
