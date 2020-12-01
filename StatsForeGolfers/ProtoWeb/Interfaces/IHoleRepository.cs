using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProtoWeb.Models;

namespace ProtoWeb.Interfaces
{
    public interface IHoleRepository
    {
        Dictionary<int, Hole> AllHoles();
        Dictionary<int, Hole> FilterHole(string crtieria);
        void DeleteHole(Hole hole);
        void AddHole(Hole hole);
        void UpdateHole(Hole hole);
        Hole GetHole(int holeNr);
    }
}
