namespace MaximOS;
using MaximOS.Enums;

public static class SysCalls {
    public static void Write(string message) {
        Console.Out.Write(message);
    }
    public static void Write(string message, OutType outStream = OutType.STDOUT) {
        if (outStream == OutType.STDOUT) {
            Write(message);
        } else if (outStream == OutType.STDIN) {
            throw new ArgumentException("STDIN can't be used for printing message!");
        } else if (outStream == OutType.STDERR) {
            Console.Error.Write(message);
        }
    }
    public static void WriteLine() {
        Console.Out.WriteLine();
    }
    public static void WriteLine(string message) {
        Console.Out.WriteLine(message);
    }
    public static void WriteLine(string message, OutType outStream = OutType.STDOUT) {
        if (outStream == OutType.STDOUT) {
            WriteLine(message);
        } else if (outStream == OutType.STDIN) {
            throw new ArgumentException("STDIN can't be used for printing message!");
        } else if (outStream == OutType.STDERR) {
            Console.Error.WriteLine(message);
        }
    }
    public static void WriteLine(OutType outStream = OutType.STDOUT) {
        if (outStream == OutType.STDOUT) {
            WriteLine();
        } else if (outStream == OutType.STDIN) {
            throw new ArgumentException("STDIN can't be used for printing message!");
        } else if (outStream == OutType.STDERR) {
            Console.Error.WriteLine();
        }
    }
}