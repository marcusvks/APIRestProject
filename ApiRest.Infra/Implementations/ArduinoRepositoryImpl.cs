using ApiRest.Domain;
using ApiRest.Infra.Interfaces;

namespace ApiRest.Infra.Implementations
{
    public class ArduinoRepositoryImpl : IArduinoRepository
    {
        private readonly MainContext _db;

        public ArduinoRepositoryImpl(MainContext db)
        {
            _db = db;
        }

        public async Task Add(Arduino entity)
        {
            await _db.AddAsync(entity);
            await _db.SaveChangesAsync();
        }

        public IQueryable<Arduino> GetAll()
        {
            return _db.Arduino;
        }

        public IQueryable<Arduino> GetById(int id)
        {
            return from arduino in _db.Arduino
                   where arduino.ArduinoId == id
                   select arduino;

        }
    }
}
