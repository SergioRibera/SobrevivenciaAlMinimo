using UnityEngine;
using UnityEngine.Events;

public interface IUInteractable {
    event UnityAction<GameObject> OnHover, OnExit, OnClick, OnDown, OnUp;
}
