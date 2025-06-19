using Xunit;
using Moq;
using System.Data.SqlClient;

public class AuthServiceTests
{
    [Fact]
    public void ValidateLogin_ShouldNotAuthenticate_WithSqlInjectionAttempt()
    {
        // Arrange
        var maliciousUsername = "' OR 1=1;--";
        var maliciousPassword = "anything";
        var authService = new AuthService("your-test-connection-string");

        // Act
        bool isValid = authService.ValidateLogin(maliciousUsername, maliciousPassword);

        // Assert
        Assert.False(isValid, "SQL injection should not bypass authentication.");
    }
}