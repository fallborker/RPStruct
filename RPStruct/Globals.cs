global using Raylib_cs;
global using rlImGui_cs;
global using ImGuiNET;
global using static Raylib_cs.Raylib;
global using static RPStruct.Globals;

namespace RPStruct;

internal static class Globals
{

    // Versioning: v<VERSION_NUMBER>-<VERSION_BRANCH>
    public const string RPSTRUCT_VERSION_NUMBER = "1";
    public const string RPSTRUCT_VERSION_BRANCH = "dev";
    public const string RPSTRUCT_VERSION = $"{RPSTRUCT_VERSION_NUMBER}-{RPSTRUCT_VERSION_BRANCH}";
}
