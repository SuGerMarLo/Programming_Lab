using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class FileHandler
{
    private string dataDirPath = "";
    private string dataFileName = "";

    // Encryption (Prewritten)
    private bool useEncryption = false;
    private readonly string encryptionCode = "word";

    public FileHandler(string dataDirPath, string dataFileName, bool useEncryption)
    {
        //assign all the variables for easier use
        this.dataDirPath = dataDirPath;
        this.dataFileName = dataFileName;

        // Encryption (Prewritten)
        this.useEncryption = useEncryption;
    }

    public GameData Load()
    {
        //Combine data to load the game and set loadedData to null so that no extra data gets stored in unneeded places
        string fullPath = Path.Combine(dataDirPath, dataFileName);
        GameData loadedData = null;

        if(File.Exists(fullPath))
        {
            try
            {
                string dataToLoad = "";
                using(FileStream stream = new FileStream(fullPath, FileMode.Open))
                {
                    using(StreamReader reader = new StreamReader(stream))
                    {
                        //If a save file exists and is to be encrypted, read the save file from start to end
                        dataToLoad = reader.ReadToEnd();
                    }
                }

                // Optionally decrypt the data (Prewritten)
                if (useEncryption)
                {
                    dataToLoad = EncryptDecrypt(dataToLoad);
                }

                loadedData = JsonUtility.FromJson<GameData>(dataToLoad);
            }
            catch(Exception e)
            {
                Debug.LogError("Error occured when trying to load data from file: " + fullPath + "\n" + e);
            }
        }

        return loadedData;
    }

    public void Save(GameData data)
    {
        // string fullPath = dataDirPath + "/" + dataFileName; (Prewritten)

        string fullPath = Path.Combine(dataDirPath, dataFileName);

        try
        {
            // Create a directory the file will be written to if It doesn't exist (Prewritten)
            Directory.CreateDirectory(Path.GetDirectoryName(fullPath));

            // Serialize the C# game data object into JSON (Prewritten)
            string dataToStore = JsonUtility.ToJson(data, true);

            // Optionally encrypt the data (Prewritten)
            if (useEncryption)
            {
                dataToStore = EncryptDecrypt(dataToStore);
            }

            using(FileStream stream = new FileStream(fullPath, FileMode.Create))
            {
                using(StreamWriter writer = new StreamWriter(stream))
                {
                    //Write the encrypted data to the save file
                    writer.Write(dataToStore);
                }
            }
        }
        catch(Exception e)
        {
            Debug.LogError("Error occured when trying to save data to file: " + fullPath + "\n" + e);
        }
    }

    // Encryption (Prewritten)
    private string EncryptDecrypt(string data)
    {
        string modifiedData = "";
        for(int i=0; i < data.Length; i++)
        {
            //This looks like a complicated math equation, but essentially for each character read in the save file, encrypt it with the formula below
            modifiedData += (char) (data[i] ^ encryptionCode[i % encryptionCode.Length]);
        }
        return modifiedData;
    }
}
