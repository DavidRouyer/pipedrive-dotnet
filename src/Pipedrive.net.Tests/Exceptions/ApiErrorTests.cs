using Newtonsoft.Json;
using Xunit;

namespace Pipedrive.Tests.Exceptions
{
    public class ApiErrorTests
    {
        const string json = @"{
   ""message"": ""Validation Failed"",
   ""errors"": [
     {
       ""resource"": ""Issue"",
       ""field"": ""title"",
       ""code"": ""missing_field""
     }
   ]
 }";
        [Fact]
        public void CanBeDeserialized()
        {
            var apiError = JsonConvert.DeserializeObject<ApiError>(json);

            Assert.Equal("Validation Failed", apiError.Message);
            Assert.Equal(1, apiError.Errors.Count);
            Assert.Equal("Issue", apiError.Errors[0].Resource);
            Assert.Equal("title", apiError.Errors[0].Field);
            Assert.Equal("missing_field", apiError.Errors[0].Code);
        }
    }
}
