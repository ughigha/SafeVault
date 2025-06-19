using Xunit;

public class InputValidatorTests
{
    [Fact]
    public void SanitizeInput_ShouldRemoveScriptTagsAndDangerousChars()
    {
        // Arrange
        string input = "<script>alert('XSS')</script><b>bold</b>";
        string expected = "alert(&#39;XSS&#39;)bold"; // Depending on your encoding

        // Act
        string sanitized = InputValidator.SanitizeInput(input);

        // Assert
        Assert.Equal(expected, sanitized);
    }
}