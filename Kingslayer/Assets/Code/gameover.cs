using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class gameover : MonoBehaviour
{
    public Texture logo;
    private Vector2 pos = new Vector2((Screen.width / 2), (Screen.height / 2));
    private Vector2 size = new Vector2(480, 67);
    public GUIStyle buttonGUI = new GUIStyle();

    void OnGUI()
    {
        GUI.DrawTexture(new Rect(pos.x - 240, pos.y - 300, size.x, size.y), logo, ScaleMode.StretchToFill, true, 1);

        if (GUI.Button(new Rect(pos.x - 75, (pos.y / 2) + 150, 150, 50), "Play Again!", buttonGUI))
        {
            Debug.Log("Play Again!");
            SceneManager.LoadScene(1);
        } // END IF

        if (GUI.Button(new Rect(pos.x - 75, (pos.y / 2) + 203, 150, 50), "Quit", buttonGUI))
        {
            Debug.Log("Quit");
            Application.Quit();
        } // END IF
    }
}