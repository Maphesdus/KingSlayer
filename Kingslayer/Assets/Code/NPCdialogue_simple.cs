using UnityEngine;
using System.Collections;

public class NPCdialogue_simple : MonoBehaviour {
    public Texture2D window;
    private Vector2 pos = new Vector2(400, 600);
    private Vector2 size = new Vector2(800, 200);
    public string[] questions;
    public string[] answers;
    private bool displayDialogue = false;
    private bool activateQuest = false;
    public int RewardAmount;

    private int margin = 10;
    public GUIStyle textGUI = new GUIStyle();
    public GUIStyle buttonGUI = new GUIStyle();

    // START:
    void Start () { }

    // UPDATE:
    void Update() { }


    void OnGUI() {
        GUILayout.BeginArea(new Rect(pos.x, pos.y, size.x, size.y));
        if (displayDialogue) {
            GUI.DrawTexture(new Rect(0, 0, size.x, size.y), window, ScaleMode.StretchToFill, true, 1);
        }        
            GUILayout.BeginArea(new Rect(margin, margin, size.x - (margin * 2), size.y - (margin * 2)));
                if (!MainQuest.kingDead) {
                    if (displayDialogue && !activateQuest) {
                        GUILayout.Label(questions[0], textGUI);
                        GUILayout.Label(questions[1], textGUI);

                        if (GUILayout.Button(answers[0], buttonGUI)) {
                            activateQuest = true;                
                            displayDialogue = false;
                        }

                        if (GUILayout.Button(answers[1], buttonGUI)) {
                            displayDialogue = false;
                        }
                    }

                    if (displayDialogue && activateQuest) {
                        GUILayout.Label(questions[2], textGUI);

                        if (GUILayout.Button(answers[2], buttonGUI)) {
                            displayDialogue = false;
                            if (this.gameObject.tag == "Son_dialogue") {
                                AI_Son.follow = true;
                                this.GetComponent<Collider2D>().enabled = false;
                            }
                        }
                    }
                }

                if (displayDialogue && MainQuest.kingDead) {
                    GUILayout.Label(questions[3], textGUI);

                    if (GUILayout.Button(answers[3], buttonGUI)) {
                        QuestComplete();
                        displayDialogue = false;
                    }
                }
            GUILayout.EndArea();
        GUILayout.EndArea();
    } // END OnGUI

    void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.tag == "Player") {
            displayDialogue = true;
        }
    }

    void OnTriggerExit2D() {
        displayDialogue = false;
    }

    void QuestComplete() {
        PlayerGold.playerGold += RewardAmount;
        this.GetComponent<Collider2D>().enabled = false;
    }
}