using UnityEngine;
using System.Collections;

public class castleDoor : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (MainQuest.kingDead) {
            this.GetComponent<Collider2D>().enabled = false;
        }
    }
}
