# tileEngine-Develop
Welcome to the official development repository for tileEngine.
If you're here, then that means you have access to the source code, and will want to build the project.
Below are some helpful tips for getting your environment up and running.

# Cloning the Project
To clone the tileEngine repository and all it's submodules, you can use the following commands:
```
git clone [url]
git submodule init
git submodule update
nuget restore
```
Alternatively to NuGet restore, you can also restore NuGet packages in Visual Studio by right clicking the solution in the solution browser, and
then clicking "Restore NuGet Packages". For information on how to properly build the project, refer to the documentation at 
`Documentation/tileEngine.Docs/articles`.

# Editing Forms with Designer
Because this project is x64 exclusively due to compilation restraints, editing with Visual Studio 2019 or lower with the designer can cause issues.
When loading and editing any forms that inherit from a form within the project, you must switch the project in which you are editing temporarily to "Any CPU" in the project properties.
This will then allow Visual Studio <=2019 (a 32 bit process) to load and use this form in designer mode.

# Error Codes
Error codes start from TE-1001, and go upwards.
The current highest used error code is TE-1012.

Internal error codes start from TE-21000.
The current highest used error code is TE-21017.