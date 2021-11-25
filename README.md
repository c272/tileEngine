# tileEngine-Develop
Welcome to the official development repository for tileEngine.
If you're here, then that means you have access to the source code, and probably want to build it.

Here are some helpful tips for getting your environment up and running.

# Cloning the Project
Use the following:
```
git clone [url]
git submodule init
git submodule update
nuget restore
```

# Editing Forms with Designer
Because this project is x64 exclusively due to compilation restraints, editing with Visual Studio 2019 or lower with the designer can cause issues.
When loading and editing any forms that inherit from a form within the project, you must switch the project in which you are editing temporarily to "Any CPU" in the project properties.
This will then allow Visual Studio <=2019 (a 32 bit process) to load and use this form in designer mode.

# Resources at Runtime
All resources that are a static file (not an image) that need to be loaded at runtime can be placed in Resources\Static. These will then be copied into the
"resources" folder in the program directory at runtime.

# Error Codes
Error codes start from TE-1001, and go upwards.
The current highest used error code is TE-1006.

Internal error codes start from TE-21000.
The current highest used error code is TE-21002.