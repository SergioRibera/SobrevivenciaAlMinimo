using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AdvancedUITools : MonoBehaviour {
    // in => 0 -> 1
    // out => 1 -> 0
    public static IEnumerator FadeImage(Image image, float targetAlpha = 1.0f, float fadeRate = 1.2f) {
        if (image != null) {
            Color curColor = image.color;
            while(Mathf.Abs(curColor.a - targetAlpha) > 0.0001f) {
                curColor.a = Mathf.Lerp(curColor.a, targetAlpha, fadeRate);
                image.color = curColor;
                yield return null;
            }
        }
    }
    public static IEnumerator FadeImage(Image image, Color targetColor, float fadeRate = 1.2f) {
        if (image != null && targetColor != null) {
            Color curColor = image.color;
            while(curColor != targetColor) {
                curColor = Color.Lerp(curColor, targetColor, fadeRate);
                image.color = curColor;
                yield return null;
            }
        }
    }
    public static IEnumerator FadeRawImage(RawImage image, Color targetColor, float fadeRate = 1.2f) {
        if (image != null && targetColor != null) {
            Color curColor = image.color;
            while(curColor != targetColor) {
                curColor = Color.Lerp(curColor, targetColor, fadeRate);
                image.color = curColor;
                yield return null;
            }
        }
    }
    public static IEnumerator FadeText(Text text, Color targetColor, float fadeRate = 1.2f) {
        if (text != null && targetColor != null) {
            Color curColor = text.color;
            while(curColor != targetColor) {
                curColor = Color.Lerp(curColor, targetColor, fadeRate);
                text.color = curColor;
                yield return null;
            }
        }
    }
    public static IEnumerator FadeTextMeshPro(TextMeshProUGUI text, Color targetColor, float fadeRate = 1.2f) {
        if (text != null && targetColor != null) {
            Color curColor = text.color;
            while(curColor != targetColor) {
                curColor = Color.Lerp(curColor, targetColor, fadeRate);
                text.color = curColor;
                yield return null;
            }
        }
    }
    public static IEnumerator MoveUIElement(RectTransform el, Vector2 a, Vector2 b, float speed) {
        float step = (speed / (a - b).magnitude) * Time.fixedDeltaTime;
        float t = 0;
        while (t <= 1.0f) {
            t += step; // Goes from 0 to 1, incrementing by step each time
            el.position = Vector3.Lerp(a, b, t); // Move objectToMove closer to b
            yield return new WaitForFixedUpdate();         // Leave the routine and return here in the next frame
        }
        el.position = b;
    }
    public static IEnumerator MoveFromTo(Transform objectToMove, Vector3 a, Vector3 b, float speed) {
        float step = (speed / (a - b).magnitude) * Time.fixedDeltaTime;
        float t = 0;
        while (t <= 1.0f) {
            t += step; // Goes from 0 to 1, incrementing by step each time
            objectToMove.position = Vector3.Lerp(a, b, t); // Move objectToMove closer to b
            yield return new WaitForFixedUpdate();         // Leave the routine and return here in the next frame
        }
        objectToMove.position = b;
    }
}
