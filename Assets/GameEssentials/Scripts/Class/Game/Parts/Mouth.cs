using UnityEngine;

public class Mouth : ICreaturePart {
    CreaturePart _creatureParts;

    public CreaturePart CreaturePart { get => _creatureParts; set => _creatureParts = value; }

    public TypePart GetTypePart => TypePart.Mouth;

    public void ActionEnter(string tag, CreatureBase me, GameObject other) {
        switch (tag) {
            case "Alimento":
                other.GetComponent<IComestible>().Consume(CreaturePart.typeAlimentation);
                break;
            case "Player":
                other.GetComponent<CreaturePlayable>().TakeHit(CreaturePart.value);
                break;
            case "Bot":
                other.GetComponent<CreatureBot>().TakeHit(CreaturePart.value);
                break;
        }
    }

    public void ActionExit(string tag, CreatureBase me, GameObject other) { }
    public void ActionStay(string tag, CreatureBase me, GameObject other) { }
    public void Init() { }
}
