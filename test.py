# Creat object '{"energi-danmark": "docker-image-1", "next": "docker-image-2"}'

import json

data = {
    "energi-danmark": "docker-image-1",
    "next": "docker-image-2d"
}

# split files string into list. Divide by spaces
files = ["src/base/energi-danmark/hej.txt", "src/base/next/hej.txt", "src/base/next/hej2.txt", "./github/workflows/main.yml"]

images = []


for file in files:
    # Remove hej.txt from file
    path = file.split("/")[0:3]
    path = "/".join(path) + "/Dockerfile"
    if(path not in images and path.startswith("src")):
        images.append(path)

print(images)
    


