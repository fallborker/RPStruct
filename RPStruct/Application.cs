using RPStruct.Views;
using RPStruct.Windows;

namespace RPStruct;

// Singleton
internal class Application : IDisposable
{
    private bool _disposed;
    private bool _run;
    private static IView? _currentView;

    public Application Init()
    {
        Logger.Info($"RPStruct v{RPSTRUCT_VERSION}");
        var log = Logger.SetProcedure("INIT");

        log.Info("Setting up raylib's ConfigFlags");
        SetConfigFlags(ConfigFlags.Msaa4xHint | ConfigFlags.VSyncHint | ConfigFlags.ResizableWindow);

        log.Info("Initializing raylib window");
        InitWindow(640, 480, $"RPStruct - v{RPSTRUCT_VERSION}");

        log.Info("Setting up rlImGui");
        rlImGui.Setup(true, true);

        log.Info("Setting up rlImGUI's configs");
        ImGuiIOPtr io = ImGui.GetIO();
        io.ConfigWindowsMoveFromTitleBarOnly = true;
        io.ConfigFlags |= ImGuiConfigFlags.DockingEnable;

        SetExitKey(KeyboardKey.Null);
        SetTargetFPS(60);

        log.Info("Setting WelcomeView as the current view");
        SetCurrentView<WelcomeView>();

        return this;
    }

    public void Run()
    {
        var log = Logger.SetProcedure("MAIN");
        log.Info("Starting main loop");

        _run = true;
        while (_run)
        {
            if (WindowShouldClose())
            {
                _run = false;
            }

            _currentView?.Update();

            BeginDrawing();
            rlImGui.Begin();

            WindowManager.Get.Draw();

            _currentView?.Draw();

            rlImGui.End();
            EndDrawing();
        }
    }

    public void Dispose()
    {
        if (_disposed)
        {
            return;
        }

        var log = Logger.SetProcedure("DISPOSE");
        log.Info("rlImgui_cs");
        rlImGui.Shutdown();

        log.Info("raylib");
        CloseWindow();
    }

    public static void SetCurrentView<T>() where T : IView, new() => _currentView = new T();
}
