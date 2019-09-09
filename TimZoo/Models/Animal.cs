using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TimZoo.Models
{
    public class Animal:IAnimal
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float Health { get; set; }
        public HealthStatus Status { get; set; }
        public AnimalType Type { get; set; }
        public string DisplayStatus { get; set; }



        public enum AnimalType { Elephant, Monkey, Giraffe };

        public enum HealthStatus { Alive, Lame, Dead };
    }
}
