using System;
using System.Collections.Generic;
using UnityEngine;

public static class DataManager {
    static string DATA_PATH = Application.persistentDataPath;
    static string KEY_ENCRYPT = "FMORÑKÑBV&R/WVXRWNHYOERUII";

    static CreatureData data;

    public static bool DataLoaded { private set; get; }
    public static bool IsNewData { private set; get; }
    public static void Init() {
#if !UNITY_EDITOR
        IsNewData = !SaveDataManager.Exist(typeof(CreatureData), DATA_PATH);
        data = !IsNewData ?
            SaveDataManager.Load<CreatureData>(DATA_PATH, KEY_ENCRYPT, loadPrivates: true) : new CreatureData();
        DataLoaded = data != null;
#else
        IsNewData = DataLoaded = true;
        data = new CreatureData();
#endif
    }

    public static int Health {
        get => data.health;
        set {
            data.health = value;
            Save();
        }
    }

    public static int IndexInputSelected {
        get => data.inputSelect;
        set {
            data.inputSelect = value;
            Save();
        }
    }

    public static int Level {
        get => data.level;
        /* get => 1; */
        set {
            data.level = value;
            Save();
        }
    }

    public static TypeAlimentation TypeAlimentation {
        get => data.typeAlimentation;
        set {
            data.typeAlimentation = value;
            Save();
        }
    }

    public static int ADN {
        get => data.adn;
        set {
            data.adn = value;
            Save();
        }
    }
    public static int MaxADN {
        get => data.maxADN;
        set {
            data.maxADN = value;
            Save();
        }
    }

    public static int CurrentNutrition {
        get => data.currentNutrition;
        set {
            data.currentNutrition = value;
            Save();
        }
    }

    public static int MaxNutrition {
        get => data.maxNutrition;
        set {
            data.maxNutrition = value;
            Save();
        }
    }

    public static CreaturePart GetCreaturePart(int key) => data.parts[key];
    
    public static void AddCreaturePart(CreaturePart c) {
        data.parts.Add(c);
        Save();
    }

    public static bool ExistsCreaturePart(string key) => data.partsNames.Contains(key);
    
    public static void AddCreaturePart(string c) {
        data.partsNames.Add(c);
        Save();
    }

    static void Save() {
#if !UNITY_EDITOR
        data.Save<CreatureData>(DATA_PATH, KEY_ENCRYPT, savePrivates: true);
#endif
    }
}
