using System;
using UnityEngine;

[Serializable]
public class AdvancedUIColors {
    public Color NormalColor, HoverColor, PressedColor, DisabledColor;

    public AdvancedUIColors(){
        NormalColor = Color.white;
        HoverColor = new Color(.7843f, .7843f, .7843f, .7f);
        PressedColor = new Color(.7843f, .7843f, .7843f, 1f);
        DisabledColor = new Color(.7843f, .7843f, .7843f, .5f);
    }
}
