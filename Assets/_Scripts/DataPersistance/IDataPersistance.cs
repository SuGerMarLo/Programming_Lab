using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDataPersistance
{
    //This is to prevent losing data when closing the game
    void LoadData(GameData data);
    void SaveData(ref GameData data);
}
