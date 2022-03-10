using ApiRest.Domain;

namespace ApiRest.Infra.Interfaces
{
    public interface IArduinoActionRepository
    {
        IQueryable<ArduinoAction> GetAll();
        Task Add(ArduinoAction entity);
        IQueryable<ArduinoAction> GetById(int id);
    }
}
