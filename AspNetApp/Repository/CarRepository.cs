using AspNetApp.interfaces;
using AspNetApp.Models;
using Microsoft.EntityFrameworkCore;

namespace AspNetApp.Repository
{
    public class CarRepository : IAllCars
    {
        private readonly AppDBContent _appDbContent;
        public CarRepository(AppDBContent appDbContent)
        {
            this._appDbContent = appDbContent;
        }
        public IEnumerable<Car> Cars => _appDbContent.Car.Include(c => c.Category);

        public IEnumerable<Car> getFavCars => _appDbContent.Car.Where(p => p.isFavourite).Include(c => c.Category);

        public Car getObjectCar(int carId) => _appDbContent.Car.FirstOrDefault(p => p.id == carId);
    }
}
