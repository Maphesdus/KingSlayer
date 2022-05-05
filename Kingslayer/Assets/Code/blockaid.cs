using UnityEngine;
using System.Collections;

public class blockaid : MonoBehaviour {

	// Use this for initialization
	void Start () {
        gameObject.SetActive(true);
    }
	
	// Update is called once per frame
	void Update () {
        if (MainQuest.sonDead || MainQuest.kingDead) {
            gameObject.SetActive(false);
        }
	}
}
