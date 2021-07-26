using System.Collections.Generic;

public struct TypeHability {
    public TypeAlimentation typeAlimentation;
    public int quantity;
}

public struct Hability {
    public int ID;
    public string name;
    public List<int> prevHabilitiesRequire;
    public List<TypeHability> types;
}

public struct NotificationData {
    public string title;
    public string msg;
}
