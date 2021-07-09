using UnityEngine;

public class BotInput : IInput {

    Transform creature;

    public BotInput(Transform creature) {
        this.creature = creature;
    }

    public void Init() {
        throw new System.NotImplementedException();
    }

    public void Stop() {
        throw new System.NotImplementedException();
    }

    public void Update()
    {
        throw new System.NotImplementedException();
    }
}
