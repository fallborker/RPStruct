using System;
using System.Numerics;
using System.Security.Cryptography;
using NativeFileDialogSharp;

namespace RPStruct.Windows;

// Singleton
internal class WindowManager
{
    private static WindowManager _instance;
    public static WindowManager Get
    {
        get
        {
            if (_instance == null)
            {
                _instance = new WindowManager();
            }

            return _instance;
        }
    }

    public Vector2 MenuBarSize { get; private set; }
    private ProjectManager _pm = ProjectManager.Get;

    private void FileMenu()
    {
        if (ImGui.BeginMenu("File"))
        {
            if (ImGui.MenuItem("Load project"))
            {
                DialogResult result = Dialog.FileOpen("rps");
                if (result != null)
                {
                    // Prompt if user wants to save
                    if (ImGui.BeginPopup("Test"))
                    {

                    }
                }
            }

            if (ImGui.MenuItem("Save project", _pm.HasProject))
            {

            }

            if (ImGui.MenuItem("Export current room", _pm.HasProject))
            {

            }

            if (ImGui.MenuItem("Export project", _pm.HasProject))
            {

            }


            ImGui.EndMenu();
        }
    }

    private void EditMenu()
    {
        if (ImGui.BeginMenu("File"))
        {
            ImGui.EndMenu();
        }
    }

    private void WindowMenu()
    {
        if (ImGui.BeginMenu("File"))
        {
            ImGui.EndMenu();
        }
    }

    private void MenuBar()
    {
        ImGui.PushStyleVar(ImGuiStyleVar.FramePadding, new Vector2(4));
        if (ImGui.BeginMainMenuBar())
        {
            FileMenu();
            EditMenu();
            WindowMenu();

            MenuBarSize = ImGui.GetWindowSize();
            ImGui.EndMainMenuBar();
        }

        ImGui.PopStyleVar();
    }

    private WindowManager() { }

    public void Draw()
    {
        MenuBar();
    }
}
