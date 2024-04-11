using Microsoft.AspNetCore.Mvc;
using VetClinicAnimalApi.Service.Interfaces;
using VetClinicAnimalApi.Service.Models;
using VetClinicAnimalApi.Service.Repositories;

namespace VetClinicAnimalApi.Service.Controllers;

public class AnimalController : ControllerBase
{
    private readonly IAnimalRepository _animalRepository;

    public AnimalController()
    {
        _animalRepository = new AnimalRepository();
    }

    [HttpGet]
    public ActionResult<List<Animal>> GetAll()
    {
        return _animalRepository.GetAll();
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