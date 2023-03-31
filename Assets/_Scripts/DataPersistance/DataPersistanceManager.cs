using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class DataPersistanceManager : MonoBehaviour
{
    public static DataPersistanceManager manager;

    // Input file name to be referenced
    [Header("File Storage Config")]
    [SerializeField] private string fileName;

    // Encryption (Prewritten)
    [SerializeField] private bool useEncryption;

    private FileHandler dataHandler;
    private GameData gameData;
    private List<IDataPersistance> dataPersistanceObjects;

    private void Awake() {
        if(manager == null)
        {
            //If there is no manager, make this script the save manager
            manager = this;
        }
        else
        {
            //If there already is a manager and the game is trying to access another one, print the following
            Debug.Log("Found more than one Data Persistance Manager in the scene");
        }

        //Save the files in "fileName" and encrypt it using "useEncryption"
        this.dataHandler = new FileHandler(Application.persistentDataPath, fileName, useEncryption);
        this.dataPersistanceObjects = FindAllDataPersistanceObjects();
        LoadGame();
    }

    public void NewGame()
    {
        //If the player chooses a new game, create a new save file
        this.gameData = new GameData();
    }

    public void LoadGame()
    {
        //if the player chooses load game, load the game from a selected file
        this.gameData = dataHandler.Load();

        if(this.gameData == null)
        {
            //if there was no previous save file but the player tries to load game, start a new game instead
            Debug.Log("No data was found! Initializing data to defaults.");
            NewGame();
        }

        // Push the loaded data to all other scripts which implememnts IDataPersistance interface (Prewritten)
        foreach (IDataPersistance dataPersistanceObj in dataPersistanceObjects)
        {
            dataPersistanceObj.LoadData(gameData);
        }

        // Debug.Log("Loaded score = " + gameData.score); (Prewritten)
    }

    public void SaveGame()
    {
        foreach(IDataPersistance dataPersistanceObj in dataPersistanceObjects)
        {
            //for every saveable parameter/object/setting, save its data into a save file
            dataPersistanceObj.SaveData(ref gameData);
        }

        dataHandler.Save(gameData);

        // Debug.Log("Saved score = " + gameData.score); (Prewritten)
    }

    private void OnApplicationQuit() {
        //when the player quits, automaticly save the game
        SaveGame();
    }

    private List<IDataPersistance> FindAllDataPersistanceObjects()
    {
        //Find all objects that are marked with the enumerator named below which are the ones that have savable data
        IEnumerable<IDataPersistance> dataPersistanceObjects = FindObjectsOfType<MonoBehaviour>().OfType<IDataPersistance>();

        //Create a list of those savable objects
        return new List<IDataPersistance>(dataPersistanceObjects);
    }
}
