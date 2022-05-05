using UnityEngine;
using System.Collections;

public class magicOrb : MonoBehaviour {
    private Vector2 pos = new Vector2((Screen.width / 2) - 400, (Screen.height / 2) - 200);
    private Vector2 size = new Vector2(800, 200);
    private bool displayDialogue = false;
    public GameObject son;
    public float wait = 5.0f;
    public GameObject orb;


    public string text = "You see a magical orb lying in the sand. A mysterious power envelopes you, impressing upon your mind a single thought: \"1,000 gold pieces to restore that which was lost...\" What could it mean?";
    public string text2 = "You don't have enough gold pieces...";

    public GUIStyle textGUI = new GUIStyle();

    // Use this for initialization
    void Start () { }
	
	// Update is called once per frame
	void Update () { }

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

                GUILayout.BeginArea(new Rect(300, 70, size.x, size.y));
                    if (MainQuest.kingDead) {
                        if (PlayerGold.playerGold == 1000) {
                            wait -= Time.deltaTime;
                            if (wait <= 0) {
                                Instantiate(son, transform.position, Quaternion.identity);
                                PlayerGold.playerGold = 0;
                                DestroyObject(orb);
                            }
                        }

                        else
                            GUILayout.Label(text2, textGUI);
                    }
                GUILayout.EndArea();
            GUILayout.EndArea();
        }
    }
}