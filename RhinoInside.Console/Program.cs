using System;
using System.IO;
using System.Reflection;
using Rhino.Geometry;
using Rhino.Runtime.InProcess;

namespace RhinoInside.Console
{
  class Program
  {
    #region Program static constructor
    static Program()
    {
      ResolveEventHandler OnRhinoCommonResolve = null;
      AppDomain.CurrentDomain.AssemblyResolve += OnRhinoCommonResolve = (sender, args) =>
      {
        const string rhino_common_assembly_name = "RhinoCommon";
        var assembly_name = new AssemblyName(args.Name).Name;

        if (assembly_name != rhino_common_assembly_name)
          return null;

        AppDomain.CurrentDomain.AssemblyResolve -= OnRhinoCommonResolve;

        var rhino_system_dir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles), "Rhino WIP", "System");
        return Assembly.LoadFrom(Path.Combine(rhino_system_dir, rhino_common_assembly_name + ".dll"));
      };
    }
    #endregion

    [System.STAThread]
    static void Main(string[] args)
    {
      try
      {
        using (new RhinoCore(new[] { "/NOSPLASH" }, WindowStyle.Hidden))
        {
          CreateMeshFromBrep();
          System.Console.WriteLine("Press any key to exit");
          System.Console.ReadKey();
        }
      }
      catch (Exception ex)
      {
        System.Console.Error.WriteLine(ex.Message);
      }
    }

    private static void CreateMeshFromBrep()
    {
      var sphere = new Sphere(Point3d.Origin, 12);
      var brep = sphere.ToBrep();
      var mp = new MeshingParameters(0.5);
      var mesh = Mesh.CreateFromBrep(brep, mp);
      System.Console.WriteLine($"Mesh with {mesh[0].Vertices.Count} vertices created");
    }
  }
}