using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using static TimZoo.Models.Animal;

namespace TimZoo.Models
{
    public class Zoo
    {
        private readonly ZooContext _context;
        public Zoo(ZooContext context)
        {
            _context = context;

            if (context.Animals.Count() == 0)
            {
                // load up the zoo animals
                _context.Animals.Add(new Animal { Health = 100, Name = "Monkey1", Status = HealthStatus.Alive, Type = AnimalType.Monkey, DisplayStatus = Enum.GetName(typeof(HealthStatus), HealthStatus.Alive)});
                _context.Animals.Add(new Animal { Health = 100, Name = "Monkey2", Status = HealthStatus.Alive, Type = AnimalType.Monkey, DisplayStatus = Enum.GetName(typeof(HealthStatus), HealthStatus.Alive) });
                _context.Animals.Add(new Animal { Health = 100, Name = "Monkey3", Status = HealthStatus.Alive, Type = AnimalType.Monkey, DisplayStatus = Enum.GetName(typeof(HealthStatus), HealthStatus.Alive) });
                _context.Animals.Add(new Animal { Health = 100, Name = "Monkey4", Status = HealthStatus.Alive, Type = AnimalType.Monkey, DisplayStatus = Enum.GetName(typeof(HealthStatus), HealthStatus.Alive) });
                _context.Animals.Add(new Animal { Health = 100, Name = "Monkey5", Status = HealthStatus.Alive, Type = AnimalType.Monkey, DisplayStatus = Enum.GetName(typeof(HealthStatus), HealthStatus.Alive) });
                _context.Animals.Add(new Animal { Health = 100, Name = "Elephant1", Status = HealthStatus.Alive, Type = AnimalType.Elephant, DisplayStatus = Enum.GetName(typeof(HealthStatus), HealthStatus.Alive) });
                _context.Animals.Add(new Animal { Health = 100, Name = "Elephant2", Status = HealthStatus.Alive, Type = AnimalType.Elephant, DisplayStatus = Enum.GetName(typeof(HealthStatus), HealthStatus.Alive) });
                _context.Animals.Add(new Animal { Health = 100, Name = "Elephant3", Status = HealthStatus.Alive, Type = AnimalType.Elephant, DisplayStatus = Enum.GetName(typeof(HealthStatus), HealthStatus.Alive) });
                _context.Animals.Add(new Animal { Health = 100, Name = "Elephant4", Status = HealthStatus.Alive, Type = AnimalType.Elephant, DisplayStatus = Enum.GetName(typeof(HealthStatus), HealthStatus.Alive) });
                _context.Animals.Add(new Animal { Health = 100, Name = "Elephant5", Status = HealthStatus.Alive, Type = AnimalType.Elephant, DisplayStatus = Enum.GetName(typeof(HealthStatus), HealthStatus.Alive) });
                _context.Animals.Add(new Animal { Health = 100, Name = "Giraffe1", Status = HealthStatus.Alive, Type = AnimalType.Giraffe, DisplayStatus = Enum.GetName(typeof(HealthStatus), HealthStatus.Alive) });
                _context.Animals.Add(new Animal { Health = 100, Name = "Giraffe2", Status = HealthStatus.Alive, Type = AnimalType.Giraffe, DisplayStatus = Enum.GetName(typeof(HealthStatus), HealthStatus.Alive) });
                _context.Animals.Add(new Animal { Health = 100, Name = "Giraffe3", Status = HealthStatus.Alive, Type = AnimalType.Giraffe, DisplayStatus = Enum.GetName(typeof(HealthStatus), HealthStatus.Alive) });
                _context.Animals.Add(new Animal { Health = 100, Name = "Giraffe4", Status = HealthStatus.Alive, Type = AnimalType.Giraffe, DisplayStatus = Enum.GetName(typeof(HealthStatus), HealthStatus.Alive) });
                _context.Animals.Add(new Animal { Health = 100, Name = "Giraffe5", Status = HealthStatus.Alive, Type = AnimalType.Giraffe, DisplayStatus = Enum.GetName(typeof(HealthStatus), HealthStatus.Alive) });
                _context.SaveChanges();
            }
        }
        public List<Animal> Animals { get; set; }

        public List<Animal> ProgressOneHour()
        {
            //For each animal in the zoo generate a value between 1 and 20 
            //and reduce its health percentage by that amount
            var Animals = _context.Animals.ToList();

            foreach (Animal animal in Animals)
            {
                if (animal.Status != HealthStatus.Dead)
                {
                    if (animal.Type == AnimalType.Elephant && animal.Status == HealthStatus.Lame) //if an elephant' health is less than 70% at the end of the hour it dies 
                    {
                        animal.Status = HealthStatus.Dead;
                        animal.DisplayStatus = Enum.GetName(typeof(HealthStatus), animal.Status);
                    }
                    else
                    {
                        var random = new Random();
                        int randomReduction = random.Next(0, 20);
                        animal.Health = (animal.Health - randomReduction);
                        if (animal.Type == AnimalType.Monkey && animal.Health < 30)
                        {
                            animal.Status = HealthStatus.Dead;
                            animal.DisplayStatus = Enum.GetName(typeof(HealthStatus), animal.Status);
                        }
                        else if (animal.Type == AnimalType.Giraffe && animal.Health < 50)
                        {
                            animal.Status = HealthStatus.Dead;
                            animal.DisplayStatus = Enum.GetName(typeof(HealthStatus), animal.Status);
                        }
                        else if (animal.Type == AnimalType.Elephant && animal.Health < 70)
                        {
                            animal.Status = HealthStatus.Lame;
                            animal.DisplayStatus = Enum.GetName(typeof(HealthStatus), animal.Status);
                        }
                    }
                }
            }

            _context.SaveChanges();

            return GetAnimals();
        }

        public List<Animal> FeedZoo()
        {
            //For each type animal in the zoo generate a value between 10 and 25 
            //and increase the health percentage for each animal of that type 
            //by that amount to a maximum of 100%
            var Animals = _context.Animals.ToList();
            var random = new Random();
            var elephantFood = random.Next(10,25);
            var monkeyFood = random.Next(10,25);
            var giraffeFood = random.Next(10,25);

            foreach (Animal animal in Animals)
            {
                if (animal.Status != HealthStatus.Dead) //no amount of food will revive a dead elephant
                {
                    switch (animal.Type)
                    {
                        case AnimalType.Elephant:

                            animal.Health = Math.Clamp((animal.Health + elephantFood), 0, 100);
                            switch (animal.Health)
                            {
                                case var expression when animal.Health < 70:
                                    animal.Status = HealthStatus.Lame;
                                    animal.DisplayStatus = Enum.GetName(typeof(HealthStatus), animal.Status);
                                    break;
                                case var expression when animal.Health >= 70:
                                    animal.Status = HealthStatus.Alive;
                                    animal.DisplayStatus = Enum.GetName(typeof(HealthStatus), animal.Status);
                                    break;
                            }

                            break;
                        case AnimalType.Giraffe:
                            animal.Health = Math.Clamp((animal.Health + giraffeFood), 0, 100);
                            switch (animal.Health)
                            {
                                case var expression when animal.Health < 50:
                                    animal.Status = HealthStatus.Dead;
                                    animal.DisplayStatus = Enum.GetName(typeof(HealthStatus), animal.Status);
                                    break;
              
                            }
                            break;
                        case AnimalType.Monkey:
                            animal.Health = Math.Clamp((animal.Health + monkeyFood), 0, 100);
                            switch (animal.Health)
                            {
                                case var expression when animal.Health < 30:
                                    animal.Status = HealthStatus.Dead;
                                    animal.DisplayStatus = Enum.GetName(typeof(HealthStatus), animal.Status);
                                    break;
                            }
                            break;
                    }
                }
            }

            _context.SaveChanges();

            return GetAnimals();
        }

        public List<Animal> GetAnimals()
        {
            return _context.Animals.ToList();
        }
    }
}
