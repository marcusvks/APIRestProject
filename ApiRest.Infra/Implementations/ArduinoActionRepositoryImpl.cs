using ApiRest.Domain;
using ApiRest.Infra.Interfaces;

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

        public IQueryable<int> GetActiveAction(int arduinoId)
        {
            return from arduinoAction in _db.ArduinoAction
                   where arduinoAction.ArduinoId == arduinoId && arduinoAction.ExecutionDate == default(DateTime) orderby arduinoAction.IdAction descending
                   select arduinoAction.TypeAction;
        }

        public IQueryable<ArduinoAction> GetAll()
        {
            return _db.ArduinoAction;
        }
    }
}
