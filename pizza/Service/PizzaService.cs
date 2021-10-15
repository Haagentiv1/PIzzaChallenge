using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using pizza.Domain;

namespace pizza.Service
{
    public class PizzaService
    {
        public async Task<List<PizzaDto>> GetPizzas()
        {
            
              return PizzaRepository.GetPizzas()
                .Select(p => new PizzaDto(
                        p.Id,
                        p.Name,
                        p.Description,
                        PriceService.Get(p.Price)
                        ))
                    .ToList();
              
        }

        public async Task<PizzaDto> GetPizzas(int id)
        {
            return PizzaRepository.GetPizzas()
                .Where(p => p.Id == id)
                .Select(p => new PizzaDto(p.Id, p.Name, p.Description, PriceService.Get(p.Price)))
                .FirstOrDefault();
        }

        public async Task<PizzaDto> GetPizzas(String name)
        {
            return await convertToDto(
                PizzaRepository.GetPizzas()
                    .Where(p => p.Name == name)
                    .Select(p => p)
                    .FirstOrDefault()
            );
        }



        private async Task<PizzaDto> convertToDto(Pizza pizza)
        {
            if (pizza == null) return null;

            return new PizzaDto(
                pizza.Id,
                pizza.Name,
                pizza.Description,
                PriceService.Get(pizza.Price));
        }
    }
}
