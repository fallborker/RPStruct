namespace RPStruct;

internal enum LogLevel
{
    Info,
    Warning,
    Error
}

internal static class Logger
{
    private struct MessageBlock
    {
        public bool Tab;
        public ConsoleColor? Color;
        public required string Message;
    }

    public struct LoggerProcedure
    {
        public string ProcedureName;

        private string Format(string message) => $"{ProcedureName}: {message}";

        public LoggerProcedure(string procedureName)
        {
            ProcedureName = procedureName;

            Logger.Info($"Procedure {ProcedureName}");
        }

        public void Info(string message) => Logger.Info(Format(message));
        public void Warn(string message) => Logger.Warn(Format(message));
        public void Error(string message) => Logger.Error(Format(message));
    }

    private static ConsoleColor _infoColor = ConsoleColor.Green;
    private static ConsoleColor _warningColor = ConsoleColor.Yellow;
    private static ConsoleColor _errorColor = ConsoleColor.Red;

    private static MessageBlock[] Format(LogLevel level, string msg)
    {
        MessageBlock levelBlock = new MessageBlock()
        {
            Color = level switch
            {
                LogLevel.Info => _infoColor,
                LogLevel.Warning => _warningColor,
                LogLevel.Error => _errorColor,
                _ => null
            },
            Message = $"[{level switch
            {
                LogLevel.Info => "info",
                LogLevel.Warning => "warn",
                LogLevel.Error => "error",
                _ => ""
            }}]"
        };

        MessageBlock timestampBlock = new MessageBlock()
        {
            Message = $"[{DateTime.Now:yy/MM/dd HH:mm:ss}]",
        };

        MessageBlock messageBlock = new MessageBlock()
        {
            Message = msg + "\n"
        };

        return [levelBlock, timestampBlock, messageBlock];
    }

    public static void Log(LogLevel level, string msg)
    {
        MessageBlock[] blocks = Format(level, msg);
        for (int i = 0; i < blocks.Length; i++)
        {
            MessageBlock b = blocks[i];
            if (b.Color == null)
            {
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = b.Color.Value;
            }

            Console.Write((i != 0 && b.Tab ? '\t' : "") + b.Message + (i == blocks.Length - 1 ? "" : ": "));
        }
    }

    public static LoggerProcedure SetProcedure(string procedureName) => new LoggerProcedure(procedureName);

    public static void Info(string msg) => Log(LogLevel.Info, msg);

    public static void Warn(string msg) => Log(LogLevel.Warning, msg);

    public static void Error(string msg) => Log(LogLevel.Error, msg);
}