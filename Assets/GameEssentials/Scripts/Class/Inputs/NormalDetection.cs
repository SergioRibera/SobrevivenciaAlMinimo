using UnityEngine;
using UnityEngine.InputSystem;

public class NormalDetection : IInput {

    float creatureSpeed;
    Rigidbody2D creature;

    InputActions input;
    Vector2 mousePos = Vector2.zero, _mousePosTemp = Vector2.zero;

    public NormalDetection(Rigidbody2D creature, float creatureSpeed) {
        this.creature = creature;
        this.creatureSpeed = creatureSpeed;
        /* Debug.Log("Setters"); */

        input = new InputActions();
        input.PlayerNormal.MousePosition.performed += ctx => {
            float z = Mathf.Abs(creature.transform.position.z - Camera.main.transform.position.z);
            _mousePosTemp = Camera.main.ScreenToWorldPoint(((Vector3) ctx.ReadValue<Vector2>()) + new Vector3(0, 0, z));
        };
        input.PlayerNormal.MousePosition.canceled += ctx =>
            mousePos = _mousePosTemp = Vector2.zero;

        input.PlayerNormal.Pause.performed += ctx =>
            UIManager.Main.ToglePauseMenu(ctx.ReadValueAsButton());
        input.PlayerNormal.Pause.canceled += ctx =>
            UIManager.Main.ToglePauseMenu(false);
        /* Debug.Log("Input"); */
    }

    public void Init() {
        /* Debug.Log("Init"); */
        input.Enable();
    }

    public void Stop() {
        /* Debug.Log("Stop"); */
        input.Disable();
    }

    public void Update() {
        if (!input.asset.enabled) return;
        if (Mouse.current.leftButton.isPressed && !GameManager.Main.pausedGame)
            mousePos = _mousePosTemp;
        var dir = new Vector2(
            mousePos.x - creature.position.x,
            mousePos.y - creature.position.y
        );
        creature.transform.up = dir;
        creature.MovePosition(Vector3.MoveTowards(creature.position, mousePos,
                creatureSpeed * Time.deltaTime));
        /* creature.MovePosition(Vector3.Lerp(creature.position, mousePos, */
        /*         creatureSpeed * Time.deltaTime)); */
    }
}
