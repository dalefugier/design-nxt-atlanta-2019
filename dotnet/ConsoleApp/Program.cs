using System;
using Rhino.Compute;
using Rhino.Geometry;

namespace ConsoleApp
{
  class Program
  {
    static void Main(string[] args)
    {
      // TODO: Add Rhino.Compute authorization code here
      ComputeServer.AuthToken = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJwIjoiUEtDUyM3IiwiYyI6IkFFU18yNTZfQ0JDIiwiYjY0aXYiOiJLYVBqQ2VkS29xZkRQRXZNM0ZGYytBPT0iLCJiNjRjdCI6InJHYWp3blhmMnlWN1B2SElra3g1ZWJpbFI2bUdwWThtc04yL0kwY3ZJN1Z0ZHlZdU56bnFzMHljV0w4RjcxaHlZeHVoUVJreXFlVEJEeFZWVEVWN3ZudTIxQUVPYnYyeVBkUm9rZ1RNUS9lamJibWMwbTBSMU1JeGVsK1RFdjU0VjYxOHN0aWVuS3lkQzJPWmllcDFCc0tuZTlIbmxwKzNyVFQrSldlbGN2amNHNnpCakY4dDFBVm1mK2FKSHVGZVRaOGM0dzU4bDc1ZllGTGh3bStsa0E9PSIsImlhdCI6MTU2NjU2OTExN30.6OEpqQggn1N16J4bIb7cCIy1fT5Gx-mzBDzMNYDAFOw";
      
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
