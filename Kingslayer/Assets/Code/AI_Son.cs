using UnityEngine;
using System.Collections;

public class AI_Son : MonoBehaviour {
    private SpriteRenderer spriteRend;
    private GameObject Player;
    public int HP = 10;
    private float DistanceToPlayer;
    private float ChaseDistance = 1.0f;
    private float followDistance = 0.5f;
    public static bool follow = false;
    Animator anim;

    public AudioClip hitClip;
    AudioSource hitSource;

    // START:
    void Start () {
        spriteRend = GetComponent<SpriteRenderer>();
        Player = GameObject.FindGameObjectWithTag("Player");
        anim = GetComponent<Animator>();
        hitSource = GetComponent<AudioSource>();
    }
	
	// UPDATE:
	void Update () {
        DistanceToPlayer = Vector2.Distance(transform.position, Player.transform.position);

        if (HP <= 0) {
            MainQuest.sonDead = true;
            //AI_Knight.hostile = false;
            Destroy(this.gameObject);
        }
        if (follow) {
            if (DistanceToPlayer <= ChaseDistance && DistanceToPlayer > followDistance) {
                anim.SetBool("isWalking", true);
                transform.position = Vector2.MoveTowards(transform.position, Player.transform.position, Time.deltaTime);
            }

            if (DistanceToPlayer <= followDistance) {
                anim.SetBool("isWalking", true);
                transform.position = transform.position;
            }
        }
    } // END UPDATE

    void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.tag == "Projectile" || col.gameObject.tag == "Sword") {
            Debug.Log(HP);
            spriteRend.color = new Color(1f, 0f, 0f, 1f);
            HP--;
            hitSource.Play();
        }
    }

    void OnTriggerExit2D() {
        spriteRend.color = new Color(1f, 1f, 1f, 1f);
    }
}