## ILView 

Lightweight 3D Viewer and Interactive REPL for ILNumerics

## Overview

This is the official repository for ILView - an interactive viewer for 3D scenes and plottings created with ILNumerics. This repository targets 
potential developers for ILView. If you want to try and use official builds of ILView only, go to <http://ilnumerics.net>.  

ILView allows the visualization of arbitrary 3D scenes in a small and lightweight .NET application. Scenes can be fetched 
from arbitrary URIs, provided as ILC# (permalinks from the official ILNumerics project site) or interactively defined. 

ILView comes with a C# interactive console (C# REPL). It can be used to modify 3D scenes interactively. Furthermore, it is handy as a general 
computing REPL for the evaluation of arbitrary computational expressions. 

ILView is the default viewer for all interactive [web code components](http://ilnumerics.net/ilnumerics-interactive-web-component.html)
 on the official ILNumerics website.   

This project is intended as community project. We (the maintainer of ILNumerics) will keep pushing updates to it. 
But we do explicitly encourage you to collaborate and to support the project. We are open for pull requests and general ideas for 
enhancements and new features.  

## Supported Platforms 

ILView is a .NET application. It runs on all supporting platforms for .NET CLR 4.0 or mono. We have tried to keep the GUI as simple as 
possible, in order to minimize platform specific issues. The initial state of the GUI does not use any fancy docking windows or the like. 
It runs unmmodified on all major Windows and Linux distributions without further dependencies. 

## Dependencies

- **ILNumerics** provides the computational base and the scene graph implementation. It is provided as Open Source project (GPL3) on <http://ilnumerics.net>. 
- **OpenTK** provides OpenGL bindings. [OpenTK](http://opentk.com) is part of the ILNumerics distribution.
- **Mono.CSharp** is a C# compiler and interactive evaluator made available by the [mono](http://www.mono-project.com/Main_Page) team. It 
is used to realize the C# REPL in ILView. The official repository is found on github here <https://github.com/mono>. Mono CSharp is found under mcs\class\Mono.CSharp. 
A modified prebuilt assembly is provided in the bin directory of ILView for convenience and easier reference.
- On Linux we recommend to install **monodevelop**. It brings all needed .NET libraries (mostly winforms and GDI). 

## Binaries

We do currently not provide precompiled binaries of ILView. In order to create an executable, clone the repository and build ILView. Another way to 
get a prebuilt executable is to visit a web code component at the ILNumerics website. The output type EXE provides a single prebuilt 
executable file, having all dependencies merged into. 

## Building ILView

Build is straightforward: 

- Clone the repository
- Open ILView.csproj in Visual Studio (or your favorite IDE)
- Add a reference to Mono.CSharp (build Mono.CSharp on your own or take the DLL from the bin/ folder in the repos root)
- Add a reference to ILNumerics by using NuGet: 
    
	Install-Package ILNumerics

- Build
 
## Notes

Installing ILNumerics via NuGet will also install ILNumerics.Native. This is needed, in order to make the **full** ILNumerics feature set 
available on the REPL. Especially, functions like fft(), svd() and pinv() depend on ILNumerics.Native. However, in order to run interactive 
3D graphics only, ILNumerics.Native is not needed. So, in case you are after a minimal deployment size, you may remove the bin32/ and bin64/ 
folders, incorporated by ILNumerics.Native. Keep in mind, all attempts to call any of the functions which depend on LAPACK or FFT will cause 
ILView to crash at runtime then!

## License

ILView is provided under the MIT/X11 license.  