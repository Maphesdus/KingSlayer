using UnityEngine;
using System.Collections;

public class AI_King : MonoBehaviour {
    // AI VARIABLES:
    public int HP = 10;
    public float MoveSpeed = 0.5f;
    public float ChaseDistance = 3.0f;
    public float AttackDistance = 1.0f;
    public float waitTime = 0.5f;
    private float DistanceToPlayer;
    private Vector2 POS;
    private Vector2 SpawnPoint = new Vector2(0, 0);
	Animator anim;

    private GameObject Player;
    public GameObject projectile;
	private SpriteRenderer spriteRend;
	
	public AudioClip hitClip;
	AudioSource hitSource;


    // START:
    void Start() {
		spriteRend = GetComponent<SpriteRenderer>();
        Player = GameObject.FindGameObjectWithTag("Player");
		anim = GetComponent<Animator>();
        hitSource = GetComponent<AudioSource>();
        SpawnPoint = transform.position;
    } // END START()

    // UPDATE:
    void Update() {
        DistanceToPlayer = Vector2.Distance(transform.position, Player.transform.position);
        POS = new Vector2(transform.position.x, transform.position.y);

        if (HP <= 0) {
            MainQuest.kingDead = true;
            Destroy(this.gameObject);
        }

        if (POS == SpawnPoint) {
            anim.SetBool("isWalking", false);
        }

        //  If the distance between the mob and the player
        //  is less than or equal to the ChaseDistance,
        //  and greater than the AttackDistance,
        //  the mob moves towards the player.
        if (DistanceToPlayer <= ChaseDistance && DistanceToPlayer > AttackDistance) {
            transform.position = Vector2.MoveTowards(transform.position, Player.transform.position, MoveSpeed * Time.deltaTime);
        } else {
            transform.position = Vector2.MoveTowards(transform.position, SpawnPoint, MoveSpeed * Time.deltaTime);
        }

        //  If the distance between the mob and the player
        //  is less than or equal to the AttackDistance,
        //  the mob launches a projectile at the player.
        if (DistanceToPlayer <= AttackDistance) {
            //Debug.Log(this.gameObject.name + " is now in range! Ready to shoot player!");
            transform.position = transform.position;

            waitTime -= Time.deltaTime;
            if (waitTime <= 0) {
                Instantiate(projectile, transform.position, Quaternion.identity);
                waitTime = 0.5f;
            }
        }
    } // END UPDATE()

    void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.tag == "Sword") {
            Debug.Log(HP);
            spriteRend.color = new Color(1f, 0f, 0f, 1f);
            HP--;
            hitSource.Play();
        } 
    }

    void OnTriggerExit2D() {
        spriteRend.color = new Color(1f, 1f, 1f, 1f);
    }
} // END CLASS AI_Mob