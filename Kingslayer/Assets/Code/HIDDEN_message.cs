using UnityEngine;
using System.Collections;

public class HIDDEN_message : MonoBehaviour {
    private Vector2 pos = new Vector2((Screen.width / 2), 600);
    private Vector2 size = new Vector2(800, 200);
    private bool displayDialogue = false;
    public string text = "A sword was HIDDEN under this rock!";
    private bool pushed = false;
    private float wait = 5.0f;
    public GUIStyle textGUI = new GUIStyle();

    // Use this for initialization
    void Start () { }

	// Update is called once per frame
	void Update () {
        if (pushed) {
            wait -= Time.deltaTime;
            if (wait <= 0) {
                displayDialogue = false;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.tag == "Player") {
            displayDialogue = true;
        }
    }

    void OnTriggerExit2D() {
        displayDialogue = false;
    }

    void OnGUI() {
        if (displayDialogue) {
            GUILayout.BeginArea(new Rect(pos.x, pos.y, size.x, size.y));
                GUILayout.Label(text, textGUI);
            GUILayout.EndArea();
        }
    }
}