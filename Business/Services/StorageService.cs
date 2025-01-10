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

    public bool SaveContactsToStorage(List<ContactEntity> contactEntity)
    {
        try
        {
            if (!Directory.Exists(_directoryPath))
            {
                Directory.CreateDirectory(_directoryPath);
            }

            var json = JsonSerializer.Serialize(contactEntity, _jsonSerializerOption);


            File.WriteAllText(_filePath, json);
            return true;
        }

        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
        }
        return false;
    }

    public List<ContactEntity> LoadContactsFromStorage()
    {
        try
        {
            if (!File.Exists(_filePath))
            {
                Debug.WriteLine("Storage file did not exist");
                return [];
            }

            var json = File.ReadAllText(_filePath);
            Debug.WriteLine($"Loaded from storage: {json}");
            var upload = JsonSerializer.Deserialize<List<ContactEntity>>(json, _jsonSerializerOption);


            return upload ?? [];

        }

        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return [];
        }
    }

    public bool DeleteContactsFromStorage()
    {
        try
        {
            if (File.Exists(_filePath)) 
            { 
                File.Delete(_filePath);
                return true;
            }
            else
            {
                Debug.WriteLine("File does not exist");
                return false;
            }
        }

        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
        }
        return false;
    }
}
