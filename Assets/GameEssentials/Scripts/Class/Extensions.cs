using System;
using UnityEngine;

public static class Extensions {
    public static void CleanChilds(this Transform t) {
        /* for (int i = 0; i < t.childCount; i++) */
        /*     t.Destroy(t.GetChild(i).gameObject); */
    }
}
