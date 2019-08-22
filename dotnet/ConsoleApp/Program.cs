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
      ComputeServer.AuthToken = "ADD_TOKEN_HERE"
      
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
