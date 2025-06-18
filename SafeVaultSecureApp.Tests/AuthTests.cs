using Xunit;
using SafeVaultSecureApp.Services;

namespace SafeVaultSecureApp.Tests
{
    public class AuthTests
    {
        [Fact]
        public void GenerateJwtToken_ReturnsToken()
        {
            var authService = new AuthService();
            var token = authService.GenerateJwtToken("testuser", "Admin");
            Assert.False(string.IsNullOrEmpty(token));
        }
    }
}
