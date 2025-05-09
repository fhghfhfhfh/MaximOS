namespace MaximOS.Libs;
using BCrypt.Net;

public static class Encryption {
    public static string Encrypt(string password) {
        return BCrypt.HashPassword(password);
    }
    public static bool Check(string input, string passwordHash) {
        return BCrypt.Verify(input, passwordHash);
    }
    public static bool Verify(string input, string passwordHash) {
        return BCrypt.Verify(input, passwordHash);
    }
}