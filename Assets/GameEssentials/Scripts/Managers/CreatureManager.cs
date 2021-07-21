using System;
using System.Collections.Generic;
using UnityEngine;

public class CreatureManager : MonoBehaviour {

    [Header("Parts")]
    [SerializeField] Sprite basicEye;
    [SerializeField] Sprite basicMouth;
    
    public static CreatureManager Main = null;

    internal List<ICreaturePart> parts;
    Action[] unlockLevels;

    void Awake() {
        if (Main == null)
            Main = this;
        else
            Destroy(gameObject);
        // TODO: Array of functions
        unlockLevels = new Action[]{
            null,
            UnlockLevel1,
            UnlockLevel2,
            UnlockLevel3,
            UnlockLevel4,
            UnlockLevel5,
        };
    }

    public void Init() {
        /* TODO: call functions by level */
        parts = new List<ICreaturePart>();
        for (int i = 0; i < DataManager.Level; i++)
            unlockLevels[i]?.Invoke();
    }

    void UnlockLevel1() {
        parts.Add(new Eye(){
            CreaturePart = new CreaturePart(
                new Vector3(.003f, 0.093f, -1f),
                Vector3.one * 5f,
                0f,
                basicEye,
                "Basic Eye",
                1, 2, value: 100
            )
        });
        parts.Add(new SimpleMouth(){
            CreaturePart = new CreaturePart(
                new Vector3(0f, .435f, -1f),
                Vector3.one * 3f,
                .07f,
                basicMouth,
                "Basic Mouth",
                1, 3, value: 20
            )
        });
    }
    void UnlockLevel2() {
    }
    void UnlockLevel3() {
    }
    void UnlockLevel4() {
    }
    void UnlockLevel5() {
    }

    public void UnlockPlayerLevel() {
        unlockLevels[DataManager.Level]?.Invoke();
        UIManager.Main.UpdateUIParts();
    }
}
