using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using TMPro;

public class AdvancedUIInteractable : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler {

    [SerializeField] bool interactive;
    [SerializeField] [Range(0f, 1f)] float lerpFade = .2f;

    public bool Interactive {
        get {
            return interactive;
        }
        set {
            interactive = value;
            Color target = interactive ? colors.NormalColor : colors.DisabledColor;
            PaintColor(target);
            ExitAll();
        }
    }
    public AdvancedUIColors colors = new AdvancedUIColors();
    public AdvancedUIImages images;
    public AdvancedUIAudios audios;
    [SerializeField] UnityEvent onHover, onExit, onClick, onDown, onUp;

    Text textMesh = null;
    TextMeshProUGUI textMeshPro = null;
    Image image = null;
    RawImage rawImage = null;

    void Start(){
        textMesh = GetComponent<Text>() ?? null;
        textMeshPro = GetComponent<TextMeshProUGUI>() ?? null;
        image = GetComponent<Image>() ?? null;
        rawImage = GetComponent<RawImage>() ?? null;
    }

    void OnMouse(){
        if (!interactive) return;
        OnHover();
    }
    void OnMouseExit(){
        if (!interactive) return;
        OnExit();
    }
    public void OnPointerEnter(PointerEventData eventData) {
        if (!interactive) return;
        OnHover();
    }
    public void OnPointerExit(PointerEventData eventData) {
        if (!interactive) return;
        OnExit();
    }
    public void OnPointerClick(PointerEventData eventData) {
        if (!interactive) return;
        OnClick();
    }

    public void AddOnHoverListener(Action<GameObject> action) => onHover.AddListener(new UnityAction(() => action(gameObject)));
    public void AddOnExitListener(Action<GameObject> action)  => onExit.AddListener(new UnityAction(() => action(gameObject)));
    public void AddOnClickListener(Action<GameObject> action) => onClick.AddListener(new UnityAction(() => action(gameObject)));
    public void AddOnDownListener(Action<GameObject> action)  => onDown.AddListener(new UnityAction(() => action(gameObject)));
    public void AddOnUpListener(Action<GameObject> action)    => onUp.AddListener(new UnityAction(() => action(gameObject)));

    public void AddOnHoverListener(Action action) => onHover.AddListener(new UnityAction(() => action()));
    public void AddOnExitListener(Action action)  => onExit.AddListener(new UnityAction(() => action()));
    public void AddOnClickListener(Action action) => onClick.AddListener(new UnityAction(() => action()));
    public void AddOnDownListener(Action action)  => onDown.AddListener(new UnityAction(() => action()));
    public void AddOnUpListener(Action action)    => onUp.AddListener(new UnityAction(() => action()));


    public void RemoveOnHoverListener(Action<GameObject> action) => onHover.RemoveListener(new UnityAction(() => action(gameObject)));
    public void RemoveOnExitListener(Action<GameObject> action)  => onExit.RemoveListener(new UnityAction(() => action(gameObject)));
    public void RemoveOnClickListener(Action<GameObject> action) => onClick.RemoveListener(new UnityAction(() => action(gameObject)));
    public void RemoveOnDownListener(Action<GameObject> action)  => onDown.RemoveListener(new UnityAction(() => action(gameObject)));
    public void RemoveOnUpListener(Action<GameObject> action)    => onUp.RemoveListener(new UnityAction(() => action(gameObject)));

    public void RemoveOnHoverListener(Action action) => onHover.RemoveListener(new UnityAction(() => action()));
    public void RemoveOnExitListener(Action action)  => onExit.RemoveListener(new UnityAction(() => action()));
    public void RemoveOnClickListener(Action action) => onClick.RemoveListener(new UnityAction(() => action()));
    public void RemoveOnDownListener(Action action)  => onDown.RemoveListener(new UnityAction(() => action()));
    public void RemoveOnUpListener(Action action)    => onUp.RemoveListener(new UnityAction(() => action()));

    public virtual void OnHover(){
        onHover?.Invoke();
        PaintColor(colors.HoverColor);
    }
    public virtual void OnExit(){
        onExit?.Invoke();
        PaintColor(colors.NormalColor);
    }
    public virtual void OnClick(){
        onClick?.Invoke();
        PaintColor(colors.PressedColor);
    }
    public virtual void OnDown(){
        onDown?.Invoke();
        PaintColor(colors.PressedColor);
    }
    public virtual void OnUp(){
        onUp?.Invoke();
        PaintColor(colors.NormalColor);
    }
    void PaintColor(Color target){
        StopAllCoroutines();
        if (textMesh != null)
            StartCoroutine(AdvancedUITools.FadeText(textMesh, target, lerpFade));
        if (textMeshPro != null)
            StartCoroutine(AdvancedUITools.FadeTextMeshPro(textMeshPro, target, lerpFade));
        if (image != null)
            StartCoroutine(AdvancedUITools.FadeImage(image, target, lerpFade));
        if (rawImage != null)
            StartCoroutine(AdvancedUITools.FadeRawImage(rawImage, target, lerpFade));
    }
    void ExitAll(){
        onExit?.Invoke();
        onUp?.Invoke();
        StopAllCoroutines();
    }
}
