# ILView 

Interactive REPL and lightweight 3D Viewer for Scientists and Programmers. 
Watch an introductory video here: [http://www.youtube.com/watch?v=RTfLAdVWReI#at=32](http://www.youtube.com/watch?v=RTfLAdVWReI#at=32)

## Overview

This is the official repository for ILView - an interactive viewer for 3D scenes and plottings created with [ILNumerics](http://ilnumerics.net). This repository targets 
potential developers for ILView. If you want to try out ILView directly, fetch it from here: <http://ilnumerics.net/ILView_i18fb66.zip>. On Windows, you may start the 
exe directly out of the zip package. On Linux, you may have to install monodevelop, extract the package and start ILView via: `mono ILView_i18fb66.exe`.  


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

Installing ILNumerics via NuGet will also install ILNumerics.Native. This package contains the Intel MKL binaries for 32 and 64 bit and is 
needed, in order to make the **full** ILNumerics feature set available on the REPL. Especially, functions like fft(), svd() and pinv() depend 
on ILNumerics.Native. 

However, in order to run interactive 3D graphics only, ILNumerics.Native is not needed. So, in case you are after a minimal deployment size, 
you may remove the ILNumerics.Native package. Keep in mind, all attempts to call any of the functions which depend on LAPACK or FFT will cause 
ILView to crash at runtime then! In a future version, ILView should try to load needed binaries automatically from the official nuget repositories. 

## License

ILView is provided under the MIT/X11 license.  

# Getting Started 

ILView is a simple application which consists out of several windows. At application startup, a console is started (src/Program.cs)
 which starts the main application window (src/FormSimple/ILMainFormSimple.cs). The main window contains a single ILPanel and some toolbar 
buttons. It is used to display the current scene. The scene reacts on mouse input as common for interactive ILNumerics scene drivers. 
A dropdown allows to fetch further preconfigured examples from the ILNumerics website and replace the current scene. Buttons are provided 
to allow to export the current state of the scene (including current camera settings) as SVG or PNG. Another toolbar button allows to toogle 
the visibility of the C# Interactive Console REPL. 
 
## C# REPL Overview

The C# Interactive Console (REPL) allows for the evaluation of arbitrary C# expressions on the fly. This means, in difference to writing 
regular C# programs - the REPL accepts individual valid expressions without the need to wrap them in a full class context. The 
expressions are entered by the user at the command line, wrapped automatically by the compiler and executed. The result is immediately 
returned and displayed on the command line as text output. 

    > 1 + 3  [Enter]
    4
	> ILArray<double> A = ILMath.rand(5,4);  [Enter] 
	> A      [Enter]
    <Double> [5,4]
    0,62847    0,51569    0,32339    0,40215 
    0,48536    0,40263    0,51768    0,38973 
    0,79303    0,80743    0,93868    0,93390 
    0,57042    0,73974    0,13721    0,82855 
    0,47411    0,12583    0,40773    0,61560 
	    
## REPL Handling 

The evaluation is triggered when the `Enter` key is pressed. Multiple lines are spanned by pressing `Space` + `Enter` together. The `Up` key 
iteratively steps through the entries in the list of earlier expressions history. A (by now yet limited) set of code completions is 
provided automatically while entering expressions. Marking of text areas, copy and paste of text is working the regular way. The use of a 
trailing semicolon ';' is optional.  

The C# Interactive Console allows arbitrary modifications to the scene being displayed in the main window. It exposes the panel of the 
main window via the `Panel` property and may be used to alter any property of the panel, including the `Panel.Scene`: 

    > Panel.BackColor = Color.DarkGray
    > Panel.Scene = new ILScene { Camera = { new ILSphere() } }

Of course, all regular C# expressions are allowed, which reference any .NET type or namespace. By default, the following namespaces are 
included: 

    using System;
    using System.Drawing;
    using System.Collections.Generic;
    using System.Linq; 
    using ILNumerics;
    using ILNumerics.Drawing;
    using ILNumerics.Drawing.Plotting;
	
More namespaces can be included at any point (and not necessarily at the beginning of the session) on the command line. Furthermore, 
all members of the `ILNumerics.ILMath` class are directly accessible, without the need to specify the `ILMath` class. All common rules 
for [writing functions and handling arrays in ILNumerics](http://ilnumerics.net/GeneralRules.html) apply: 

    > ILArray<double> A = rand(100,200) * 2 - 1; 
    > // set diagonal to 1
	> A[r(0,101,end)] = 1; 
    > // Some more fun with subarrays
    > A[A == 1] = A[A == 1] * 2; 
    > // create a new surface scene
    > var scene = new ILScene { new ILPlotCube { new ILSurface(tosingle(A)) } }
    > // apply the scene to our panel
    > Panel.Scene = scene
    > // make the plot cube rotatable
    > Panel.Scene.First<ILPlotCube>().TwoDMode = false

![ILView In Action](http://ilnumerics.net/media/png/ILViewScrSht.png "ILView and C# REPL in Action")

## Default Scene Loading 

The console starter loads a default scene into the main window. Which scene is displayed, depends 
on the **name** of the executable: if an ILNumerics web code was found as part of the executable name, the corresponding scene is loaded 
from http://ilnumerics.net and displayed. 