public class CreatureBot : CreatureBase {
    CreatureData creatureData;
    IInput input;

    void Start() {
        input = new BotInput(transform);
        input.Init();
    }

    void Update() {
    }
}
