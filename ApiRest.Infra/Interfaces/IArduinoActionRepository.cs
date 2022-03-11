using ApiRest.Domain;

namespace ApiRest.Infra.Interfaces
{
    public interface IArduinoActionRepository
    {
        IQueryable<ArduinoAction> GetAll();
        Task Add(ArduinoAction entity);
        IQueryable<int> GetActiveAction(int arduinoId);
    }
}
