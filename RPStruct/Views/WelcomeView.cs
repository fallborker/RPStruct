using System.Numerics;
using RPStruct.Windows;

namespace RPStruct.Views;

internal class WelcomeView : IView
{
    public void Draw()
    {
        ClearBackground(Color.White);

        Vector2 mainMenuBarSize = WindowManager.Get.MenuBarSize;

        Vector2 pos = new Vector2(0, mainMenuBarSize.Y);
        Vector2 size = new Vector2(mainMenuBarSize.X, GetScreenHeight()) - pos;

        ImGui.SetNextWindowPos(pos);
        ImGui.SetNextWindowSize(size);
        ImGui.SetNextWindowBgAlpha(0.75f);
        ImGui.PushStyleVar(ImGuiStyleVar.WindowRounding, 0.0f);
        ImGui.PushStyleVar(ImGuiStyleVar.WindowPadding, new Vector2(16));

        if (ImGui.Begin("Welcome screen", ImGuiWindowFlags.NoDecoration | ImGuiWindowFlags.NoTitleBar | ImGuiWindowFlags.NoResize | ImGuiWindowFlags.NoMove))
        {

            ImGui.Text($"RPStruct version {RPSTRUCT_VERSION}");
            ImGui.Text($"Running ImGui version {ImGui.GetVersion()}");

            ImGui.Dummy(new Vector2(0, 32));

            if (ImGui.Button("New project"))
            {

            }

            ImGui.SameLine();

            if (ImGui.Button("Load project"))
            {

            }


            string footerTextInfo = "This editor is being developed with a focus on ease-of-use and utility, not necessarily style.";
            string footerTextInvite = "Contributions are welcome!";
            Vector2 spaceSize = ImGui.CalcTextSize(" ");
            Vector2 textSize = ImGui.CalcTextSize($"{footerTextInfo} {footerTextInvite}");

            ImGui.SetCursorPosX((size.X - textSize.X) / 2);
            ImGui.SetCursorPosY(size.Y - textSize.Y - 16);

            ImGui.Text(footerTextInfo);
            ImGui.SameLine(0, spaceSize.X);
            ImGui.TextLink(footerTextInvite);

            ImGui.End();
        }


        ImGui.PopStyleVar();
        ImGui.PopStyleVar();
    }

    public void Update()
    {
    }
}
