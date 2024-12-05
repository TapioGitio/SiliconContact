using Business.Interfaces;
using Business.Models;
using System.Diagnostics;
using System.Text.Json;

namespace Business.Services;

public class StorageService : IStorageService
{
    private readonly string _directoryPath;
    private readonly string _filePath;
    private readonly JsonSerializerOptions _jsonSerializerOption;

    public StorageService(string directoryPath = "DataStorage", string fileName = "contacts.json")
    {
        _directoryPath = directoryPath;
        _filePath = Path.Combine(_directoryPath, fileName);
        _jsonSerializerOption = new JsonSerializerOptions { WriteIndented = true };
    }

    public void SaveContactsToStorage(List<ContactEntity> contactEntity)
    {
        try
        {
            if (!Directory.Exists(_directoryPath))
            {
                Directory.CreateDirectory(_directoryPath);
            }

            var json = JsonSerializer.Serialize(contactEntity, _jsonSerializerOption);


            File.WriteAllText(_filePath, json);
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
        }
    }

    public List<ContactEntity> LoadContactsFromStorage()
    {
        try
        {
            if (!File.Exists(_filePath))
            {
                return [];
            }

            var json = File.ReadAllText(_filePath);
            var list = JsonSerializer.Deserialize<List<ContactEntity>>(json, _jsonSerializerOption);


            return list ?? [];

        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return [];
        }
    }

    public void DeleteContactsFromStorage()
    {
        try
        {
            if (File.Exists(_filePath)) 
            { 
                File.Delete(_filePath);
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
        }
    }
}
