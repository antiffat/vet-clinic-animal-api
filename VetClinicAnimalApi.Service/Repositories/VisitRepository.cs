using VetClinicAnimalApi.Service.Interfaces;
using VetClinicAnimalApi.Service.Models;

namespace VetClinicAnimalApi.Service.Repositories;

public class VisitRepository : IVisitRepository
{
    private static List<Visit> _visits = new List<Visit>();

    public List<Visit> GetVisitsByAnimalId(int animalId)
    {
        return _visits.Where(v => v.AnimalId == animalId).ToList();
    }

    public void AddVisit(Visit visit)
    {
        _visits.Add(visit);
    }
}