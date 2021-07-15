using UnityEngine;

public class SimpleMouth : ICreaturePart {
    CreaturePart _creatureParts;

    public CreaturePart CreaturePart { get => _creatureParts; set => _creatureParts = value; }

    public TypePart GetTypePart => TypePart.Mouth;

    public void Action(CreatureBase me, CreatureBase other) { }

    public void Action(CreatureBase me) { }

    public void Action(CreatureBase me, GameObject go) {
        // TODO: Animate
        GameObject.Destroy(go);
    }

    public void Init() { }
}
