using System;
using UnityEngine;

public static class DataManager {
    static string DATA_PATH = Application.persistentDataPath;
    static string KEY_ENCRYPT = "";

    static CreatureData data;

    public static bool DataLoaded { private set; get; }
    public static void Init() {
        data = SaveDataManager.Exist(typeof(CreatureData), DATA_PATH) ?
            SaveDataManager.Load<CreatureData>(DATA_PATH, KEY_ENCRYPT, loadPrivates: true) : new CreatureData();
        DataLoaded = data != null;
        throw new NotImplementedException();
    }

    public static int Health {
        get => data.health;
        set {
            data.health = value;
            Save();
        }
    }

    public static int IndexInputSelected {
        /* get => data.inputSelect; */
        get => 0;
        set {
            data.inputSelect = value;
            Save();
        }
    }

    static void Save() => data.Save<CreatureData>(DATA_PATH, KEY_ENCRYPT, savePrivates: true);
}
