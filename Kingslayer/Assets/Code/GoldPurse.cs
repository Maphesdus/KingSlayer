using UnityEngine;
using System.Collections;

public class GoldPurse : MonoBehaviour {
    private Vector2 pos = new Vector2(25, 25);
    private Vector2 size = new Vector2(150, 150);
    public GUIStyle myGUI = new GUIStyle();

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnGUI() {
        GUILayout.BeginArea(new Rect(pos.x, pos.y, size.x, size.y));
        GUILayout.Box("GOLD: " + PlayerGold.playerGold, myGUI);
        GUILayout.EndArea();
    }
}
