using VetClinicAnimalApi.Service.Models;

namespace VetClinicAnimalApi.Service.Interfaces;

public interface IVisitRepository
{
    List<Visit> GetVisitsByAnimalId(int animalId);
    void AddVisit(Visit visit);
}