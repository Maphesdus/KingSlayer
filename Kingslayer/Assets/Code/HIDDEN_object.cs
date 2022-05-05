using UnityEngine;
using System.Collections;

public class HIDDEN_object : MonoBehaviour {

    // Use this for initialization
    void Start() { }

    // Update is called once per frame
    void Update() { }

    void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.tag == "Player") {
            if (this.gameObject.tag == "Sword") {
                MainQuest.foundSword = true;
            }
            //this.gameObject.SetActive(false);
        }
    }

    void OnTriggerExit2D() {
        this.gameObject.SetActive(false);
    }
}
