using VetClinicAnimalApi.Service.Interfaces;
using VetClinicAnimalApi.Service.Models;

namespace VetClinicAnimalApi.Service.Repositories;

public class AnimalRepository : IAnimalRepository
{
    private static List<Animal> _animals = new List<Animal>();

    public List<Animal> GetAll() => _animals;

    public Animal GetById(int id) => _animals.FirstOrDefault(a => a.Id == id) ?? throw new InvalidOperationException();

    public void Add(Animal animal) => _animals.Add(animal);

    public void Edit(Animal animal)
    {
        var index = _animals.FindIndex(a => a.Id == animal.Id);

        if (index != -1)
        {
            _animals[index] = animal;
        }
    }

    public void Delete(int id)
    {
        var animal = GetById(id);
        if (animal != null)
        {
            _animals.Remove(animal);
        }
    }

}