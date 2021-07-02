using UnityEngine;

public class CreatureBot : CreatureBase {
    CreatureData creatureData;
    IInput input;

    void Start() {
        input = new BotInput();
    }

    void Update() {
        input.InputMoveMouse(transform);
        input.InputMoveCreature(transform);
    }
}
