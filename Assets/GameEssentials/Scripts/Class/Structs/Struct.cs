using System.Collections.Generic;

public struct TypeHability {
    public TypeAlimentation typeAlimentation;
    public int quantity;
}

public struct Hability {
    public int ID;
    public string name;
    public bool unlocked;
    public HashSet<int> prevHabilitiesRequire;
    public HashSet<TypeHability> types;
}
