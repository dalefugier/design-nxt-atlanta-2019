using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rhino.Compute;
using Rhino.Geometry;

namespace ConsoleApp
{
  class Program
  {
    static void Main(string[] args)
    {
      // TODO: Add Rhino.Compute authorization code here
      ComputeServer.AuthToken = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJwIjoiUEtDUyM3IiwiYyI6IkFFU18yNTZfQ0JDIiwiYjY0aXYiOiJIdDAwclhxeFdoWWcwRUVCMTdMcVlnPT0iLCJiNjRjdCI6Ilp0OEo3NWVPVldXKzNUb3M5bEgzcmFHZURERytYcGlzZ0h2VjZwY0pJbFNMMGJCMlVuTnZUc3p1NWtrZEx6UjN4aW5uZGxIV2dyT1QxNEo5QzYvTUxxa3R1dVBsdmJiNXJwUncxWHl1Mk91aTl3R0twTUZOY0pHSloyUHlrVnUwTzFRMk5lQTNsSTdaMmRwY2lXYm1JOUJ6bDNUdm5mS0k1d1JaR1BISU1xU2tJL29GYWhkZFZKQ3pjamdBSDZOdHFWSDA3bFFFUmY1ZnBOMFRicVA5V3c9PSIsImlhdCI6MTU2NjQ4NTA2MH0.LePqxTHPVz_NL8Hm6O32xZUrJXLektHZDjcangpKQBM";

      // Use Rhino3dm methods
      var sphere = new Sphere(Plane.WorldXY, 5.0);
      var brep = sphere.ToBrep();

      // Call compute.rhino3d.com to get access to something not available in Rhino3dm
      var meshes = MeshCompute.CreateFromBrep(brep);

      // Back to Rhino3dm methods
      Console.WriteLine($"{meshes.Length} meshes returned");
      for (var i = 0; i < meshes.Length; i++)
      {
        Console.WriteLine($"  {i + 1} mesh has {meshes[i].Vertices.Count} vertices");
      }

      Console.WriteLine("Press any key to exit");
      Console.ReadKey();
    }
  }
}
