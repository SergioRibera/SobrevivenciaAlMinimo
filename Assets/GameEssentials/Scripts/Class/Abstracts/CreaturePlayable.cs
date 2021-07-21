using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreaturePlayable : CreatureBase {

    [SerializeField] float creatureSpeed; 

    IInput[] inputs;
    IInput inputSelected;
    List<ICreaturePart> parts;

    List<Action> levelsActions;

    public static CreaturePlayable Main = null;

    void Awake() {
        if (Main == null)
            Main = this;
        else
            Destroy(gameObject);
    }

    void Start() {
        DataManager.Init();
        if (DataManager.DataLoaded) {
            maxHealthDefault = DataManager.Health;
        }
        health = maxHealthDefault;
        inputs = new IInput[] {
            new NormalDetection(GetComponent<Rigidbody2D>(), creatureSpeed),
            new KeyboardDetection(transform)
        };
        inputSelected = inputs[DataManager.IndexInputSelected];
        levelsActions = new List<Action>() {
            () => StartCoroutine(Level0()),
            Level1,
            Level2,
            Level3,
            Level4,
            Level5
        };
        // TODO: Load Parts
        parts = new List<ICreaturePart>();
    }

    public bool ContainsPart(ICreaturePart part) => parts.Contains(part);
    public int ContainsPart(TypePart typePart) => parts.FindAll(p => p.GetTypePart == typePart).Count;

    GameObject goPart;
    public void AddCreaturePart(ICreaturePart part) {
        parts.Add(part);
        goPart = new GameObject(part.GetTypePart.ToString() + part.CreaturePart.name);
        goPart.transform.localRotation = Quaternion.identity;
        goPart.transform.SetParent(transform);
        goPart.AddComponent<SpriteRenderer>().sprite = part.CreaturePart.img;
        goPart.transform.localPosition = part.CreaturePart.pos;
        goPart.transform.localScale = part.CreaturePart.scale;
        if (part.CreaturePart.collisionSize != 0f) {
            var cc = goPart.AddComponent<CircleCollider2D>();
            cc.radius = part.CreaturePart.collisionSize;
            cc.isTrigger = true;
        }
        part.Init();
    }

    public void RemovePart(ICreaturePart part) {
        var p = transform.Find(part.GetTypePart.ToString() + part.CreaturePart.name);
        if (p != null)
            Destroy(p.gameObject);
        if (part.GetTypePart == TypePart.Vision) {
            int cPart = ContainsPart(part.GetTypePart);
            if (cPart > 1) {
                int sumParts = parts.Sum(i => i.CreaturePart.value) - part.CreaturePart.value;
                CameraController.Main.Init(sumParts);
            } else
                CameraController.Main.Init(visionRadiusDefault);
        }
        parts.Remove(part);
    }

    public override void Init() {
        base.Init();
        inputSelected?.Init();
        UIManager.Main.UpdateHealth(1.0f / maxHealthDefault * health);
        // TODO: Init Creature manager
        if (DataManager.Level >= 1)
            UIManager.Main.EnableInteractable();
        foreach (var part in parts)
            part.Init();
        levelsActions[DataManager.Level]();
    }
    IEnumerator Level0() {
        int timeDuration = 30,
              time = 0;
        while (time < timeDuration) {
            yield return new WaitForSeconds(1);
            // UIManager.Main.UpdateNutritionPoint(1.0f / DataManager.MaxNutrition * time);
            float nextStep = 1.0f / timeDuration * time;
            LeanTween.value(UIManager.Main.nutritionPoint.fillAmount, nextStep, 1f).setOnUpdate((float v) => {
                if (DataManager.Level == 0)
                    UIManager.Main.UpdateNutritionPoint(v);
            });
            time++;
        }
        NextLevel();
    }
    void Level1() {
        CreatureManager.Main.UnlockPlayerLevel();
        UIManager.Main.EnableInteractable();
        print("Level 1");
    }
    void Level2() {}
    void Level3() {}
    void Level4() {}
    void Level5() {}

    void NextLevel() {
        // TODO: Add effect
        DataManager.Level++;
        levelsActions[DataManager.Level]();
        UIManager.Main.UpdateLevel();
    }
    void FixedUpdate() {
        if (isDead || GameManager.Main.pausedGame) return;
        inputSelected?.Update();
    }

    public override int TakeHit(int damage) {
        int res = base.TakeHit(damage);
        DataManager.Health = health;
        print(health);
        print(maxHealthDefault);
        return res;
    }

    public override void TriggerEnter2D(string tag, GameObject go) {
        if (isDead)
            return;
        foreach (var part in parts) {
            if (tag == "Alimento" && part.GetTypePart == TypePart.Mouth)
                part.Action(this, go);
            // TODO: Fill all
        }
    }

    [ContextMenu("Take Damage")]
    public void Damage() {
        TakeHit(10);
    }
}
