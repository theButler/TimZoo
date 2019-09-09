using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static TimZoo.Models.Animal;

namespace TimZoo.Models
{
    interface IAnimal
    {
        int Id { get; set; }
        string Name { get; set; }
        float Health { get; set; }
        HealthStatus Status { get; set; }
        AnimalType Type { get; set; }
        string DisplayStatus { get; set; }
    }
}
