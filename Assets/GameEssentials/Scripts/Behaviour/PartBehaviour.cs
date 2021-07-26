using UnityEngine;
public class PartBehaviour : Interactable {
    ICreaturePart creaturePart;
    CreatureBase creature;

    public void Init(ICreaturePart creaturePart, CreatureBase creature) {
        this.creaturePart = creaturePart;
        this.creature = creature;
    }

    public override void TriggerEnter2D(string tag, GameObject go) =>
        creaturePart?.ActionEnter(tag, creature, go);
    public override void TriggerStay2D(string tag, GameObject go) =>
        creaturePart?.ActionStay(tag, creature, go);
    public override void TriggerExit2D(string tag, GameObject go) =>
        creaturePart?.ActionExit(tag, creature, go);
}
