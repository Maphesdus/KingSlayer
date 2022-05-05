using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour {
    public int HP = 100;
    public int ATK = 45;
    public int DEF = 30;

    private Vector2 pos = new Vector2(Screen.width / 2, 10);
    private Vector2 size = new Vector2(20, 5);
    public Texture2D progressBarEmpty;
    public Texture2D progressBarFull;

    public int lbl_posX = 10;
    public int lbl_posY = 10;
    public int lbl_width = 100;
    public int lbl_height = 20;
    public GUIStyle myGUI = new GUIStyle();

    private SpriteRenderer spriteRend;
    private float flashTime = 0.2f;

    public AudioClip hitClip;
    AudioSource hitSource;

    // Use this for initialization
    void Start () {
        spriteRend = GetComponent<SpriteRenderer>();
        hitSource = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
        if (HP <= 0) {
            SceneManager.LoadScene(2);
        }

        flashTime -= Time.deltaTime;
        if (flashTime <= 0) {
            spriteRend.color = new Color(1f, 1f, 1f, 1f);
            flashTime = 0.2f;
        }
    }

    void OnGUI() {        
        GUI.Label(new Rect(pos.x - 50, pos.y + 5, lbl_width, lbl_height), "HP: " + HP, myGUI);
        //GUI.Label(new Rect(lbl_posX, lbl_posY + 20, lbl_width, lbl_height), "ATK: " + ATK);
        //GUI.Label(new Rect(lbl_posX, lbl_posY + 40, lbl_width, lbl_height), "DEF: " + DEF);

        GUI.DrawTexture(new Rect(pos.x - 50, pos.y, 100, size.y), progressBarEmpty, ScaleMode.StretchToFill, true, 1);
        GUI.DrawTexture(new Rect(pos.x - 50, pos.y, HP, size.y), progressBarFull, ScaleMode.StretchToFill, true, 1);
    }

    void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.tag == "Projectile" || col.gameObject.tag == "Sword") {
            HP--;
            spriteRend.color = new Color(1f, 0f, 0f, 1f);
            hitSource.Play();
        }
    }

    void OnTriggerExit2D() {
        spriteRend.color = new Color(1f, 1f, 1f, 1f);
    }
}