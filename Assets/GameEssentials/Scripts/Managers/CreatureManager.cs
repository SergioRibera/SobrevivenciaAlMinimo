using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class CreatureManager : MonoBehaviour {

    [Header("Parts")]
    [SerializeField] List<Sprite> level1, level2, level3, level4, level5;
    
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

    void Start() {
        parts = new List<ICreaturePart>();
        print(DataManager.Level);
        for (int i = 0; i < DataManager.Level; i++)
            if (i < unlockLevels.Length)
                unlockLevels[i]?.Invoke();
        if (!DataManager.DataLoaded) return;
        if (!DataManager.IsNewData) {
            // TODO: Load all parts and others
            if (parts.Count > 0) {
                foreach (var p in parts)
                    if (DataManager.ExistsCreaturePart(p.CreaturePart.name))
                        CreaturePlayable.Main.AddCreaturePart(p, false);
            }
        }
    }

    public void Init() {}

    void UnlockLevel1() {
        parts.Add(new Eye(){
                CreaturePart = new CreaturePart(
                        new Vector3(.003f, 0.093f, -1f),
                        Vector3.one * 5f,
                        0f,
                        level1[0],
                        "Vista Gorda",
                        1, 2, TypeAlimentation.Any, value: 100
                        )
                });
        parts.Add(new Eye(){
                CreaturePart = new CreaturePart(
                        new Vector3(.003f, 0.093f, -1f),
                        Vector3.one * 5f,
                        0f,
                        level1[1],
                        "Punto de Vista",
                        1, 1, TypeAlimentation.Any, value: 60
                        )
                });
        parts.Add(new Mouth(){
                CreaturePart = new CreaturePart(
                        new Vector3(0f, .435f, -1f),
                        Vector3.one * 3f,
                        .07f,
                        level1[2],
                        "Destroza Huesos",
                        1, 3, TypeAlimentation.Carnivore, value: 20
                        )
                });
        parts.Add(new Mouth(){
                CreaturePart = new CreaturePart(
                        new Vector3(0f, .435f, -1f),
                        Vector3.one * 3f,
                        .07f,
                        level1[3],
                        "Pastadora",
                        1, 3, TypeAlimentation.Herbivore, value: 20
                        )
                });
        // Omnivoro
        parts.Add(new Mouth(){
                CreaturePart = new CreaturePart(
                        new Vector3(0f, .435f, -1f),
                        Vector3.one * 3f,
                        .07f,
                        level1[2],
                        "Aspira Nutrientes",
                        1, 3, TypeAlimentation.Omnivore, value: 20
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
