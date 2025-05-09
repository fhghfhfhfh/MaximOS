using MaximOS.dbLibs;

namespace MaximOS;

public static class Core {
    private static string[]? _cmd_argv;
    private static int _cmd_argc;

    public static string[] Cmd_argv {
        get {return _cmd_argv ?? Array.Empty<string>();}
    }

    public static int Cmd_argc {
        get {return _cmd_argc;}
    }

    public static void Main(string[] argv) {
        _cmd_argv = argv; // Задаем системные переменные
        _cmd_argc = argv.Length;
        //Читаем датабазу с пользователями
        
    }
}