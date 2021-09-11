using Apsiyon.Entities.Abstract;
using System;

namespace Apsiyon.Entities.Concrete
{
    public class Logs : Entity
    {
        public string Detail { get; set; }
        public DateTime Date { get; set; }
        public string Audit { get; set; }
    }
}
