using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Sockets;
using System.Text.Json;
using System.Threading.Tasks;


namespace LETTER_FIGHT.Service
{
    /// <summary>
    /// Class used to verify the words entered by the players and to fetch their definitions.
    /// </summary>
    public class WordValidationService
    {
        private static readonly HttpClient client = new HttpClient();
        /// <summary>
        /// Method used to validate the word entered by the player with the letters available.
        /// </summary>
        /// <param name="input"></param>
        /// <param name="word"></param>
        /// <returns></returns>
        private static bool WordInputValidation(string input, string word)
        {
            var wordList = new List<char>(word.ToLower());

            foreach (char c in input.ToLower())
            {
                if (!wordList.Remove(c))
                    return false;
            }

            return true;
        }

        /// <summary>
        /// Method used to check if the device is connected to the internet.
        /// </summary>
        /// <returns></returns>
        private static bool IsInternetAvailable()
        {
            try
            {
                using (var client = new TcpClient("8.8.8.8", 53)) 
                {
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Method used to fetch the definition of a word from an online dictionary.
        /// </summary>
        /// <param name="word"></param>
        /// <returns></returns>
        public static async Task<string> FetchDefinitionAsync(string word)
        {
            string language = SettingService.ActiveSettings.Language;
            try
            {
                if (language == "EN")
                {
                    // Use FreeDictionaryAPI for English words
                    string apiUrl = $"https://api.dictionaryapi.dev/api/v2/entries/en/{word.ToLower()}";

                    HttpResponseMessage response = await client.GetAsync(apiUrl);
                    if (response.IsSuccessStatusCode)
                    {

                        string jsonResponse = await response.Content.ReadAsStringAsync();
                        var jsonDoc = JsonDocument.Parse(jsonResponse);

                        var firstDefinition = jsonDoc.RootElement[0]
                            .GetProperty("meanings")[0]
                            .GetProperty("definitions")[0]
                            .GetProperty("definition")
                            .GetString();

                        return $"📖 Definition :\n{firstDefinition}";
                    }
                    else
                    {
                        return await FetchFromTheFreeDictionary(word.ToLower());
                    }
                }
                else
                {
                    // Use Larousse for French words
                    string url = $"https://www.larousse.fr/dictionnaires/francais/{word.ToLower()}";

                    HttpResponseMessage response = await client.GetAsync(url);
                    if (!response.IsSuccessStatusCode)
                        return $"❌ {word} non trouvé dans le dictionnaire de l'application";

                    string htmlContent = await response.Content.ReadAsStringAsync();
                    var doc = new HtmlDocument();
                    doc.LoadHtml(htmlContent);

                    var definitionsList = doc.DocumentNode.SelectSingleNode("//ul[contains(@class, 'Definitions')]");

                    if (definitionsList == null)
                        return $"❌ {word} non trouvé dans le dictionnaire de l'application";

                    // Get the first <li> inside the <ul> (the first definition)
                    var firstDefinitionNode = definitionsList.SelectSingleNode(".//li");

                    if (firstDefinitionNode == null)
                        return $"❌ {word} non trouvé dans le dictionnaire de l'application";

                    string definition = firstDefinitionNode.InnerText.Trim();
                    return $"📖 Définition :\n{definition}";
                }
            }
            catch (Exception ex)
            {
                return $"⚠️ Error: {ex.Message}";
            }
        }

        /// <summary>
        /// Method used to fetch the definition of a word from The Free Dictionary website.
        /// </summary>
        /// <param name="word"></param>
        /// <returns></returns>
        private static async Task<string> FetchFromTheFreeDictionary(string word)
        {
            try
            {
                string url = $"https://www.thefreedictionary.com/{word.ToLower()}";

                HttpResponseMessage response = await client.GetAsync(url);
                if (!response.IsSuccessStatusCode)
                    return $"❌ {word} not found in app Dictionary.";

                string htmlContent = await response.Content.ReadAsStringAsync();
                var doc = new HtmlDocument();
                doc.LoadHtml(htmlContent);

                // Find first definition from The Free Dictionary
                var firstDefinitionNode = doc.DocumentNode.SelectSingleNode("//table[@id='wn']//td[3]");

                if (firstDefinitionNode == null)
                    return $"2❌ {word} not found in app Dictionary.";

                string definition = firstDefinitionNode.InnerText.Trim();
                return $"📖 Definition :\n{definition}";
            }
            catch
            {
                return $"3❌ {word} not found in app Dictionary.";
            }
        }
        /// <summary>
        /// Method used to validate the word entered by the player and fetch its definition.
        /// </summary>
        /// <param name="input"></param>
        /// <param name="word"></param>
        /// <returns></returns>
        public static async Task<(bool, string)> ValidateWordAsync(string input, string word)
        {
            string resultString = "";

            if (WordInputValidation(input, word))
            {
                resultString = $"✅ {input}\n\n";
                if (IsInternetAvailable())
                {
                    
                    string definition = await FetchDefinitionAsync(word);
                    resultString += $"✅🌐(online)\n\n{definition}";
                }
                else
                {
                    resultString += "❌🌐(offline)";
                }
            }
            else
            {
                resultString = $"❌ {input}";
            }

            return (true, resultString);
        }
    }
}
