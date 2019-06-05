#define AppName "PCL Convert Utility"
#define AppDir "PCLConvertUtility"
#define AppVersion "0.2.1"
#define AppPublisher "ATPATH Technologies Ltd."
#define AppURL "http://www.atpath.com/"

[Setup]
AppId={{bb39e0cd-1686-4b45-b572-e84f706b41e5}
AppName={#AppName}
; Ingore version
AppVersion=
AppVerName={#AppName}
AppPublisher={#AppPublisher}
AppPublisherURL={#AppURL}
AppSupportURL={#AppURL}
AppUpdatesURL={#AppURL}

LicenseFile=resource\License.rtf
DefaultDirName={pf}\{#AppDir}
DefaultGroupName={#AppName}
OutputDir=Output
OutputBaseFilename=PCLConvertUtility-Setup
Compression=lzma
SolidCompression=yes
PrivilegesRequired=admin
ArchitecturesAllowed=x86 x64
ArchitecturesInstallIn64BitMode=x64
UninstallFilesDir={app}\uninst

; Language and message
#include "script\message.iss"

[Files]
; Installed files
Source: "publish\*"; \
    Excludes: ".gitkeep,*.pdb,Mapping.txt"; \
    DestDir: "{app}"; \
    Flags: ignoreversion recursesubdirs

Source: "Resource\Prerequirements.*.rtf"; \
    Flags: dontcopy noencryption

[Icons]
Name: "{group}\{cm:MsgGroupApp}"; Filename: "{app}\PCLConverter.exe"
Name: "{group}\{cm:UninstallProgram, {#AppName}}"; Filename: "{uninstallexe}"

[Code]
#include "script\common.iss"

var
    WelcomePage: TOutputMsgMemoWizardPage;

procedure InitializeWizard();
begin
    WelcomePage := CreateOutputMsgMemoPage(wpWelcome,
        ExpandConstant('{cm:MsgWelcomeCaption}'),
        ExpandConstant('{cm:MsgWeclomeDescription}'),
        ExpandConstant('{cm:MsgWelcomeSubCaption}'),
        '');
    WelcomePage.RichEditViewer.UseRichEdit := True;
    WelcomePage.RichEditViewer.RTFText := GetFileString(ExpandConstant('{cm:MsgPrerequirementFileName}'));
end;

function InitializeSetup(): Boolean;
var
    // uninstallKey: string;
    Version: TWindowsVersion;
begin
    result := true;
    GetWindowsVersionEx(Version);

    if IsSoftwareInstalled() then
    begin
        MsgBox(ExpandConstant('{cm:MsgAlreadyInstalled}'), mbInformation, MB_OK);
        result := false;
    end;

    if not IsDotNetDetected('v4.6', 0) then
    begin
        MsgBox(ExpandConstant('{cm:MsgNeedDotNet4}'), mbInformation, MB_OK);
        result := false;
    end;
end;
