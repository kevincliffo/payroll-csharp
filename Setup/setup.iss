; Script generated by the Inno Setup Script Wizard.
; SEE THE DOCUMENTATION FOR DETAILS ON CREATING INNO SETUP SCRIPT FILES!

#define MyAppName "Payroll"
#define MyAppVersion "1.55"
#define MyAppPublisher "PrimeTime Technologies"
#define MyAppURL "http://www.ptimetechnologies.com/"
#define MyAppExeName "PayRollSystem.exe"

[Setup]
; NOTE: The value of AppId uniquely identifies this application.
; Do not use the same AppId value in installers for other applications.
; (To generate a new GUID, click Tools | Generate GUID inside the IDE.)
AppId={{B01EBBEA-66A5-4E93-AD4C-B5D85E192D2A}
AppName={#MyAppName}
AppVersion={#MyAppVersion}
;AppVerName={#MyAppName} {#MyAppVersion}
AppPublisher={#MyAppPublisher}
AppPublisherURL={#MyAppURL}
AppSupportURL={#MyAppURL}
AppUpdatesURL={#MyAppURL}
DefaultDirName={pf}\{#MyAppName}
DefaultGroupName={#MyAppName}
OutputDir=C:\Users\Kevin\Documents\Visual Studio 2010\Projects\_Setups
OutputBaseFilename=payroll
SetupIconFile=C:\Users\Kevin\Documents\Visual Studio 2010\Projects\PayrollSystem\Step_55\PayrollSystem\bin\Debug\Icons\people.ico
Compression=lzma
SolidCompression=yes

[Languages]
Name: "english"; MessagesFile: "compiler:Default.isl"

[Tasks]
Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked

[Files]
Source: "C:\Users\Kevin\Documents\Visual Studio 2010\Projects\PayrollSystem\Step_55\PayrollSystem\bin\Debug\PayRollSystem.exe"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\Kevin\Documents\Visual Studio 2010\Projects\PayrollSystem\Step_55\PayrollSystem\bin\Debug\*"; DestDir: "{app}"; Flags: ignoreversion recursesubdirs createallsubdirs
; NOTE: Don't use "Flags: ignoreversion" on any shared system files

[Icons]
Name: "{group}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"
Name: "{commondesktop}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"; Tasks: desktopicon

[Run]
Filename: "{app}\{#MyAppExeName}"; Description: "{cm:LaunchProgram,{#StringChange(MyAppName, '&', '&&')}}"; Flags: nowait postinstall skipifsilent

