using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ProjectTracker
{
    /// <summary>
    /// Central JSON file helper shared across all forms.
    /// Handles reading and writing JSON files to/from the Desktop.
    /// </summary>
    public static class JsonFileHelper
    {
        public static readonly JsonSerializerOptions JsonOptions = new()
        {
            WriteIndented = true,
            PropertyNameCaseInsensitive = true
        };

        /// <summary>Returns the full path for a given filename on the Desktop.</summary>
        public static string GetDesktopFilePath(string fileName) =>
            Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory),
                fileName);

        /// <summary>
        /// Reads a JSON file from the Desktop and deserializes it as a List&lt;T&gt;.
        /// Returns an empty list if the file does not exist.
        /// </summary>
        public static async Task<List<T>> LoadListAsync<T>(string fileName)
        {
            string path = GetDesktopFilePath(fileName);
            if (!File.Exists(path))
                return new List<T>();

            string json = await File.ReadAllTextAsync(path, Encoding.UTF8);
            return JsonSerializer.Deserialize<List<T>>(json, JsonOptions)
                   ?? new List<T>();
        }

        /// <summary>
        /// Serializes <paramref name="data"/> and writes it to a JSON file on the Desktop.
        /// </summary>
        public static async Task SaveListAsync<T>(string fileName, List<T> data)
        {
            string path = GetDesktopFilePath(fileName);
            string json = JsonSerializer.Serialize(data, JsonOptions);
            await File.WriteAllTextAsync(path, json, Encoding.UTF8);
        }

        /// <summary>
        /// Reads a JSON file from the Desktop and deserializes it as a single object.
        /// Returns null/default if the file does not exist or cannot be parsed.
        /// </summary>
        public static T? LoadObject<T>(string fileName)
        {
            string path = GetDesktopFilePath(fileName);
            if (!File.Exists(path))
                return default;

            try
            {
                string json = File.ReadAllText(path, Encoding.UTF8);
                return JsonSerializer.Deserialize<T>(json, JsonOptions);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"[JsonFileHelper] Could not read {fileName}: {ex}");
                return default;
            }
        }

        /// <summary>
        /// Serializes <paramref name="obj"/> and writes it to a JSON file on the Desktop.
        /// </summary>
        public static void SaveObject<T>(string fileName, T obj)
        {
            string path = GetDesktopFilePath(fileName);
            string json = JsonSerializer.Serialize(obj, JsonOptions);
            File.WriteAllText(path, json, Encoding.UTF8);
        }
    }
}