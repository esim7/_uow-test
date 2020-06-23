using System;
using System.Drawing;
using System.Runtime.CompilerServices;
using Domain.Model.Enums;

namespace Domain.Model
{
    public class Automobile : BaseEntity
    {
        public string Brand { get; set; }
        public ConsoleColor Color { get; set; }
        public BodyType BodyType { get; set; }
        public double Power { get; set; }
    }
}
