"""
Design NXT 2019 Workshop
Sample 3: Get bounding box of remote objects
"""

from rhino3dm import *
import requests  # pip install requests

url = 'https://files.mcneel.com/TEST/Rhino Logo.3dm'
req = requests.get(url)
model = File3dm.FromByteArray(req.content)
for i in range(len(model.Objects)):
    geometry = model.Objects[i].Geometry
    bbox = geometry.GetBoundingBox()
    print("{}, {}".format(bbox.Min, bbox.Max))