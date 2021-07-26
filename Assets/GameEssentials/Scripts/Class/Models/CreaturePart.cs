using UnityEngine;

public class CreaturePart {
    public Vector3 pos, scale;
    public float collisionSize;
    public Sprite img;

    public string name;
    public int value;
    public float valueF;
    public int minLevel;
    public int adnValue;
    public TypeAlimentation typeAlimentation;

    // TODO: Add Size Vector3 Circle Coliider
    // TODO: Create Class To Detect Collision on Part procedural Generate
    public CreaturePart(Vector3 pos, Sprite img) {
        this.pos = pos;
        this.img = img;
    }

    public CreaturePart(Vector3 pos, Vector3 scale, float collisionSize, Sprite img, string name, int minLevel, int adnValue, TypeAlimentation typeAlimentation, int value = 0, float valueF = 0f) {
        this.pos = pos;
        this.scale = scale;
        this.collisionSize = collisionSize;
        this.img = img;
        this.name = name;
        this.minLevel = minLevel;
        this.adnValue = adnValue;
        this.typeAlimentation = typeAlimentation;
        this.value = value;
        this.valueF = valueF;
    }
}
