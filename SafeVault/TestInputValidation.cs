using NUnit.Framework;
using System;
using System.Text.RegularExpressions;

[TestFixture]
public class TestInputValidation
{
  [Test]
  public void TestForSQLInjection()
  {
    // Placeholder for SQL Injection test
  }
  [Test]
  public void TestForXSS()
  {
    // Placeholder for XSS test
  }
}

public static class InputValidator
{
    public static string SanitizeInput(string userInput)
    {
        if (string.IsNullOrWhiteSpace(userInput))
            return string.Empty;

        // Remove script tags
        string sanitized = Regex.Replace(userInput, @"<script[^>]*>[\s\S]*?</script>", "", RegexOptions.IgnoreCase);

        // Remove HTML tags
        sanitized = Regex.Replace(sanitized, @"<.*?>", "", RegexOptions.IgnoreCase);

        // Encode special characters to prevent script execution
        sanitized = System.Net.WebUtility.HtmlEncode(sanitized);

        // Filter out potentially dangerous characters
        sanitized = Regex.Replace(sanitized, @"[<>""'/\\;&]", "");

        return sanitized.Trim();
    }
}