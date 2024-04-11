using Microsoft.AspNetCore.Mvc;
using VetClinicAnimalApi.Service.Interfaces;
using VetClinicAnimalApi.Service.Models;
using VetClinicAnimalApi.Service.Repositories;

namespace VetClinicAnimalApi.Service.Controllers;

[ApiController]
[Route("[controller]")]
public class VisitController : ControllerBase
{
    private readonly IVisitRepository _visitRepository;

    public VisitController()
    {
        _visitRepository = new VisitRepository();
    }

    [HttpGet("{id}")]
    public ActionResult<List<Visit>> GetByAnimalId(int animalId)
    {
        return _visitRepository.GetVisitsByAnimalId(animalId);
    }

    [HttpPost]
    public IActionResult AddVisit(Visit visit)
    {
        _visitRepository.AddVisit(visit);
        return CreatedAtAction(nameof(GetByAnimalId), new { animalId = visit.AnimalId }, visit);
    }
}