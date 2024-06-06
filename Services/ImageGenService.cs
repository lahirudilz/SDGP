using Azure.AI.OpenAI;

namespace susFaceGen.Services
{
    public class ImageGenService
    {
        private readonly OpenAIClient _client;
        public ImageGenService(OpenAiServices openAi)
        {
            string api_key = openAi.OpenAiApiKey;
            _client = new OpenAIClient(api_key);
        }

        public async Task<string?> GenerateImageAsync(string features)
        {
            // Creating a chat request
            ChatCompletionsOptions options = new ChatCompletionsOptions();
            ChatRequestUserMessage chat = new ChatRequestUserMessage(features);
            ChatRequestSystemMessage system = new ChatRequestSystemMessage(
            "You will convert the received text into a prompt for DALL-E-2 image generation. " +
            "Generate the prompt according to the example given. Make appropriate adjustments based on the received text. Use appropriate keywords as given in the example." +
            "The prompt example: " +
            "{face-front portrait:1.5}, high-definition macrophotography of a woman, asymmetrical bob hairstyle, hair length at ear level, (rebecca chambers :0.4), straight nose contour, straight nose base, (nose button: 0.3), (oval jawline: 0.5), oval face shape, {soft and even lighting}, {shallow depth of field}, {photo-realistic render style:1.2}, {high resolution and detailed textures}, {close-up camera shot:1.3}." +
            "The generated face should look like an actual human face, with realistic features and proportions. The image should be detailed and high-resolution, resembling a close-up photograph of a real person.");
            chat.Role = ChatRole.User;
            system.Role = ChatRole.System;

            options.Messages.Add(system);
            options.Messages.Add(chat);

            // gpt model
            options.DeploymentName = "gpt-3.5-turbo";
            string imageUrl;
            try
            {
                var result = await _client.GetChatCompletionsAsync(options);
                string generatedPrompt = result.Value.Choices[0].Message.Content;

                ImageGenerationOptions imgOption = new ImageGenerationOptions();
                imgOption.Prompt = generatedPrompt;
                imgOption.DeploymentName = "dall-e-3";
                imgOption.Quality = ImageGenerationQuality.Standard;

                // Generating image
                var imageRes = await _client.GetImageGenerationsAsync(imgOption);
                imageUrl = imageRes.Value.Data[0].Url.AbsoluteUri;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            } 
            return imageUrl;
        }
    }
}
