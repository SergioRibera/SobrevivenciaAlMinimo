using UnityEngine;

public class Interactable : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D other) => TriggerEnter2D(other.tag, other.gameObject);
    void OnTriggerStay2D(Collider2D other) => TriggerStay2D(other.tag, other.gameObject);
    void OnTriggerExit2D(Collider2D other) => TriggerExit2D(other.tag, other.gameObject);


    public virtual void TriggerEnter2D(string tag, GameObject go){}
    public virtual void TriggerStay2D(string tag, GameObject go){}
    public virtual void TriggerExit2D(string tag, GameObject go){}
}
