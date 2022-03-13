using ApiRest.Domain;

namespace ApiRest.Infra.Interfaces
{
    public interface IArduinoActionRepository
    {
        IQueryable<ArduinoAction> GetAll();
        Task Add(ArduinoAction entity);
        ArduinoAction GetActiveAction(int arduinoId);
        Task UpdateStatus(int actionId, int status);
    }
}
