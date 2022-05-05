using UnityEngine;
using System.Collections;

public class KnightDialogue : MonoBehaviour {
    public Texture2D window;
    private Vector2 pos = new Vector2(400, 400);
    private Vector2 size = new Vector2(800, 200);
    public string[] questions;
    public string[] answers;
    private bool displayDialogue = false;
    private bool activateQuest = false;
    private bool activateQuest2 = false;
    public int RewardAmount;

    private int margin = 10;
    public GUIStyle textGUI = new GUIStyle();
    public GUIStyle buttonGUI = new GUIStyle();

    // START:
    void Start () {	}

    // UPDATE:
    void Update() {
        if (AI_Knight.hostile) {
            displayDialogue = false;
            this.GetComponent<Collider2D>().enabled = false;
        }
    }


    void OnGUI() {
        GUILayout.BeginArea(new Rect(pos.x, pos.y, size.x, size.y));
            if (displayDialogue) {
                GUI.DrawTexture(new Rect(0, 0, size.x, size.y), window, ScaleMode.StretchToFill, true, 1);
            }

            GUILayout.BeginArea(new Rect(margin, margin, size.x - (margin * 2), size.y - (margin * 2)));
                if (!MainQuest.kingDead) {
                    if (displayDialogue && !activateQuest) {
                        GUILayout.Label(questions[0], textGUI); // Halt! In the name of the king!

                        if (GUILayout.Button(answers[0], buttonGUI)) { // I'm sorry, I didn't mean any harm!
                            activateQuest = true;
                            displayDialogue = false;
                        }

                        if (GUILayout.Button(answers[1], buttonGUI)) { // (Quietly slink away...)
                            displayDialogue = false;
                        }
                    }

                    if (displayDialogue && activateQuest && !activateQuest2) {
                        GUILayout.Label(questions[1], textGUI); // You filthy peasants should learn to fear the king!
                        if (GUILayout.Button(answers[2], buttonGUI)) { // What are you doing to do?
                            activateQuest2 = true;
                            displayDialogue = false;
                        }
                    }

                    if (displayDialogue && activateQuest && activateQuest2) {
                        GUILayout.Label(questions[2], textGUI); // This should put the fear of the king in you!
                        if (GUILayout.Button(answers[3], buttonGUI)) { // Oh no!
                            AI_Knight.hostile = true;
                            displayDialogue = false;
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

    void OnTriggerEnter2D() {
        displayDialogue = true;
    }

    void OnTriggerExit2D() {
        displayDialogue = false;
    }

    void QuestComplete() {
        PlayerGold.playerGold += RewardAmount;
        this.GetComponent<Collider2D>().enabled = false;
    }
}