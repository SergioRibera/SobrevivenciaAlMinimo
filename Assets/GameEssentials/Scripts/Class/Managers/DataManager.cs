using System;

public static class DataManager {

    static CreatureData data;

    public static bool DataLoaded { private set; get; }
    public static void Init() {
        data = new CreatureData();
        DataLoaded = true;
        throw new NotImplementedException();
    }

    public static int Health {
        get => data.health;
        set {
            data.health = value;
            Save();
        }
    }

    static void Save() => throw new NotImplementedException();
}
