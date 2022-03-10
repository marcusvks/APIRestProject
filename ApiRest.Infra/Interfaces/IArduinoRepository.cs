using ApiRest.Domain;

namespace ApiRest.Infra.Interfaces
{
    public interface IArduinoRepository
    {
        IQueryable<Arduino> GetAll();
        Task Add(Arduino entity);
        IQueryable<Arduino> GetById(int id);
    }
}
