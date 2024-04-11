using VetClinicAnimalApi.Service.Models;

namespace VetClinicAnimalApi.Service.Interfaces;

public interface IAnimalRepository
{
    List<Animal> GetAll();
    Animal GetById(int id);
    void Add(Animal animal);
    void Edit(Animal animal);
    void Delete(int id);
}