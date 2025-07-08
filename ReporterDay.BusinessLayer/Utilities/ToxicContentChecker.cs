using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace ReporterDay.BusinessLayer.Utilities
{
    public class ToxicPrediction
    {
        [JsonPropertyName("label")]
        public string Label { get; set; }

        [JsonPropertyName("score")]
        public double Score { get; set; }
    }

    public class ToxicContentChecker
    {
        private readonly string _apiKey = "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"; // 🔑 Buraya Hugging Face API Key gelecek

        public async Task<bool> IsToxicAsync(string comment)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _apiKey);

            var data = new { inputs = comment };
            var content = new StringContent(JsonSerializer.Serialize(data), Encoding.UTF8, "application/json");

            var response = await client.PostAsync("https://api-inference.huggingface.co/models/unitary/toxic-bert", content);
            var jsonString = await response.Content.ReadAsStringAsync();
            System.Diagnostics.Debug.WriteLine("JSON string: " + jsonString);

            var result = JsonSerializer.Deserialize<List<List<ToxicPrediction>>>(jsonString);

            var predictions = result?.FirstOrDefault();

            if (predictions != null)
            {
                var toxicLabel = predictions.FirstOrDefault(p => p.Label == "toxic");
                if (toxicLabel != null && toxicLabel.Score > 0.1)
                {
                    return true;
                }
            }

            return false;
        }


    }
}
