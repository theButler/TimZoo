using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TimZoo.Models
{
    interface IZoo
    {
        List<Animal> Animals { get; set; }

        List<Animal> ProgressOneHour();

        List<Animal> FeedZoo();

        List<Animal> GetAnimals();
    }
}
