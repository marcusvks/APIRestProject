using ApiRest.Domain;
using ApiRest.Infra.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ApiRest.Infra.Implementations
{
    public class ArduinoActionRepositoryImpl : IArduinoActionRepository
    {
        private readonly MainContext _db;

        public ArduinoActionRepositoryImpl(MainContext db)
        {
            _db = db;
        }

        public async Task Add(ArduinoAction entity)
        {
            await _db.AddAsync(entity);
            await _db.SaveChangesAsync();
        }

        public async Task UpdateStatus(int actionId, int status)
        {
            _db.Database.ExecuteSqlRaw($"UPDATE [dbo].[ArduinoAction] SET Status = {status} where IdAction = {actionId}");
        }

        public ArduinoAction GetActiveAction(int arduinoId)
        {
            int statusCreated = 0;

            return (from arduinoAction in _db.ArduinoAction
                   where arduinoAction.ArduinoId == arduinoId && arduinoAction.ExecutionDate == default(DateTime) && arduinoAction.Status == statusCreated
                   orderby arduinoAction.IdAction descending
                   select arduinoAction).FirstOrDefault();
        }

        public IQueryable<ArduinoAction> GetAll()
        {
            return _db.ArduinoAction;
        }
    }
}
