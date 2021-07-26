using UnityEngine;

public class Eye : ICreaturePart {
    CreaturePart _creatureParts;

    public CreaturePart CreaturePart { get => _creatureParts; set => _creatureParts = value; }

    public TypePart GetTypePart => TypePart.Vision;

    public void Action(CreatureBase me, CreatureBase other) { }
    public void ActionEnter(string tag, CreatureBase me, GameObject other) { }
    public void ActionExit(string tag, CreatureBase me, GameObject other) { }
    public void ActionStay(string tag, CreatureBase me, GameObject other) { }

    public void Init() {
        CameraController.Main.ChangeVision(CreaturePart.value);
        CameraController.Main.CanAnimateVision(true);
    }
}
