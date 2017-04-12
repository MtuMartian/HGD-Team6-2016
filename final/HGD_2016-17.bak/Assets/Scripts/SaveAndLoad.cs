using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public static class SaveAndLoad {
    public static string mostRecentSave;

    //if saveGame is called, the string mostRecentSave will be saved in the SaveData.save file
    public static void saveGame() {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/SaveData.save");
        bf.Serialize(file, mostRecentSave);
        file.Close();
    }

    //if loadGame is called, the string mostRecentSave will become what was last saved by saveGame
    public static void loadGame() {
        if (File.Exists(Application.persistentDataPath + "/SaveData.save")) {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/SaveData.save", FileMode.Open);
            SaveAndLoad.mostRecentSave = (string)bf.Deserialize(file);
            file.Close();
        }
    }
}
