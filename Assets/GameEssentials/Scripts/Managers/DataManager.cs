using UnityEngine;
using EasyDataSave;

public static class DataManager {
    static string DATA_PATH = Application.persistentDataPath;
    static string KEY_ENCRYPT = "FMORÑKÑBV&R/WVXRWNHYOERUII";

    static CreatureData data;

    public static bool DataLoaded { private set; get; }
    public static void Init() {
        data = SaveDataManager.Exist(typeof(CreatureData), DATA_PATH) ?
            SaveDataManager.Load<CreatureData>(DATA_PATH, KEY_ENCRYPT, loadPrivates: true) : new CreatureData();
        DataLoaded = data != null;
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

    public static int Level {
        get => data.level;
        set {
            data.level = value;
            Save();
        }
    }

    public static CreaturePart GetCreaturePart(int key) => data.parts[key];
    
    public static void AddCreaturePart(CreaturePart c) {
        data.parts.Add(c);
        Save();
    }

    static void Save() => data.Save<CreatureData>(DATA_PATH, KEY_ENCRYPT, savePrivates: true);
}
