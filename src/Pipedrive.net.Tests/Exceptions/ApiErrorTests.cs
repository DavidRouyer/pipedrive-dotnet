using Newtonsoft.Json;
using Xunit;

namespace Pipedrive.Tests.Exceptions
{
    public class ApiErrorTests
    {
        const string json = @"{
   ""error"": ""Validation Failed"",
   ""error_info"": ""Please check developers.pipedrive.com""
 }";

        [Fact]
        public void CanBeDeserialized()
        {
            var apiError = JsonConvert.DeserializeObject<ApiError>(json);

            Assert.Equal("Validation Failed", apiError.Error);
            Assert.Equal("Please check developers.pipedrive.com", apiError.ErrorInfo);
        }
    }
}
