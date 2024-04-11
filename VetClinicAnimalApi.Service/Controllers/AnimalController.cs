using Microsoft.AspNetCore.Mvc;
using VetClinicAnimalApi.Service.Interfaces;
using VetClinicAnimalApi.Service.Models;
using VetClinicAnimalApi.Service.Repositories;

namespace VetClinicAnimalApi.Service.Controllers;

[ApiController]
[Route("animal")]
public class AnimalController : ControllerBase
{
    private readonly IAnimalRepository _animalRepository;

    public AnimalController()
    {
        _animalRepository = new AnimalRepository();
    }

    [HttpGet]
    public ActionResult<List<Animal>> GetAll(string? category, double? weight, string? furColor)
    {
        var animals = _animalRepository.GetAll();

        if (!string.IsNullOrEmpty(category))
        {
            animals = animals.Where(a => a.Category?.Equals(category, StringComparison.OrdinalIgnoreCase) ?? false)
                .ToList();
        }

        if (weight.HasValue)
        {
            animals = animals.Where(a => a.Weight == weight.Value).ToList();
        }

        if (!string.IsNullOrEmpty(furColor))
        {
            animals = animals.Where(a => a.FurColor?.Equals(furColor, StringComparison.OrdinalIgnoreCase) ?? false)
                .ToList();
        }

        return animals;
    }

    [HttpGet("{id}")]
    public ActionResult<Animal> GetById(int id)
    {
        try
        {
            return _animalRepository.GetById(id);
        }
        catch (InvalidOperationException)
        {
            return NotFound();
        }
    }

    [HttpPost]
    public IActionResult Add(Animal animal)
    {
        _animalRepository.Add(animal);
        return CreatedAtAction(nameof(GetById), new { id = animal.Id }, animal);
    }

    [HttpPut("{id}")]
    public IActionResult Edit(int id, Animal animal)
    {
        if (id != animal.Id)
        {
            return BadRequest();
        }

        var existingAnimal = _animalRepository.GetById(id);
        if (existingAnimal == null)
        {
            return NotFound();
        }
        
        _animalRepository.Edit(animal);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        if (_animalRepository.GetById(id) == null)
        {
            return NotFound();
        }
        
        _animalRepository.Delete(id);
        return NoContent();
    }
}