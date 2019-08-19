"""
Design NXT 2019 Workshop
Sample 2: Read render meshes from a Brep in a 3dm file
"""

import rhino3dm

model = rhino3dm.File3dm.Read('/Users/Dale/Downloads/test.3dm')
brep = model.Objects[0].Geometry
for i in range (0, len(brep.Faces)):
    face = brep.Faces[i]
    mesh = face.GetMesh(rhino3dm.MeshType.Any)
    print(len(mesh.Faces))
