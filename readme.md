# Aurelia Typescript project sample on Service Fabric

A sample showing how to host an Aurelia Application (typescript) on Service Fabric using an OWIN Self host using Visual Studio 2015

## Steps
	1. Make sure you have the latest Service Fabric SDK for Visual Studio 2015 installed
	2. Download the code and build. It should restore all the nuget packages.
	3. Run ``au build`` from the public folder from your command line
    4. Press F5
    5. Open a browser and navigate to http://localhost:8285

## Changes to be aware of to get the sample to work

1. index.html in the public folder is set to "Content" and "Copy if Newer"
2. The *.sfproj file has been edited to copy the build output in the scripts folder to the pkg/../code folder after all files are collected. You can see this at the end of the *.sfproj file
3. ServiceManifest.XML file has the endpoint set for http and port 8285