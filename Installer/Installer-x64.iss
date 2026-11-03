#define LauncherBuildDir "..\EverythingToolbar.Launcher\bin\x64\Release\net10.0-windows10.0.17763.0"
#define DeskbandBuildDir "..\EverythingToolbar.Deskband\bin\x64\Release\net10.0-windows10.0.17763.0"
#define MyAppVersion GetVersionNumbersString(LauncherBuildDir + "\EverythingTB.exe")
#define ArchitecturesAllowed "x64os"
#define ArchitecturesInstallIn64BitMode "x64os"
#define OutputBaseName "EverythingTB-" + MyAppVersion + "-x64"

#include "SharedInstaller.iss"