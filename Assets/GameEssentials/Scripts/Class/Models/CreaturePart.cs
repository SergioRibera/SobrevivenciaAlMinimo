using UnityEngine;

public class CreaturePart {
    public Vector3 pos;
    public Sprite img;

    // TODO: Add Size Vector3 Circle Coliider
    // TODO: Create Class To Detect Collision on Part procedural Generate
    public CreaturePart(Vector3 pos, Sprite img) {
        this.pos = pos;
        this.img = img;
    }
}
