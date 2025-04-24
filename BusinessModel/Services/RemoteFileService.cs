using BusinessModel.Contracts;
using Microsoft.Extensions.Options;

namespace BusinessModel.Services
{
    public record FileServiceOptions
    {
        public string BaseUrl { get; init; }

        public string ApiKey { get; init; }
    }

    public class RemoteFileService : IFileService
    {
        private readonly HttpClient _httpClient;

        public RemoteFileService(IOptions<FileServiceOptions> options, HttpClient httpClient)
        {
            if (string.IsNullOrWhiteSpace(options.Value.BaseUrl))
            {
                throw new ArgumentException("No valid base url configured");
            }

            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri(options.Value.BaseUrl);
            _httpClient.DefaultRequestHeaders.Add("X-API-Key", options.Value.ApiKey);
        }

        public async Task<string> UploadFile(string fileName, Stream stream)
        {
            var content = new StreamContent(stream);
            content.Headers.Add("Content-Type", "application/octet-stream");

            using var formContent = new MultipartFormDataContent
            {
                { content, "file", fileName }
            };

            var response = await _httpClient.PostAsync("upload", formContent);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsStringAsync();
        }
    }
}
