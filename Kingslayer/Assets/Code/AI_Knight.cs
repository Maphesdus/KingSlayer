using UnityEngine;
using System.Collections;

public class AI_Knight : MonoBehaviour {
    // AI VARIABLES:
    public int HP = 10;
    public float MoveSpeed = 0.5f;
    public float ChaseDistance = 3.0f;
    public float AttackDistance = 0.5f;
    public float waitTime = 0.5f;
    private float DistanceToPlayer;
    private Vector2 POS;
    private Vector2 SpawnPoint = new Vector2(0, 0);
    Animator anim;

    public static bool hostile = false;
    public float attackTime = 0.2f;
    public int attackSpeed = 2000;
    private bool isAttacking = false;

    public GameObject sword;
    private SpriteRenderer spriteRend;
    private GameObject Player;

    public AudioClip hitClip;
    AudioSource hitSource;

    // START:
    void Start() {
        Player = GameObject.FindGameObjectWithTag("Player");
        anim = GetComponent<Animator>();
        SpawnPoint = transform.position;
        spriteRend = GetComponent<SpriteRenderer>();
        hitSource = GetComponent<AudioSource>();
    } // END START()

    // UPDATE:
    void Update() {
        if (MainQuest.sonDead) {
            Player = GameObject.FindGameObjectWithTag("Player");
        } else {
            Player = GameObject.FindGameObjectWithTag("Son");
        }

        DistanceToPlayer = Vector2.Distance(transform.position, Player.transform.position);
        POS = new Vector2(transform.position.x, transform.position.y);
        sword.gameObject.transform.RotateAround(this.gameObject.transform.position, Vector3.back, attackSpeed * Time.deltaTime);

        if (HP <= 0) {
            Destroy(this.gameObject);
        }

        if (POS == SpawnPoint) {
            anim.SetBool("isWalking", false);
        }

        if (hostile) {
            //  If the distance between the mob and the player
            //  is less than or equal to the ChaseDistance,
            //  and greater than the AttackDistance,
            //  the mob moves towards the player.
            if (DistanceToPlayer <= ChaseDistance && DistanceToPlayer > AttackDistance) {
                anim.SetBool("isWalking", true);
                transform.position = Vector2.MoveTowards(transform.position, Player.transform.position, MoveSpeed * Time.deltaTime);
            } else {
                transform.position = Vector2.MoveTowards(transform.position, SpawnPoint, MoveSpeed * Time.deltaTime);
            }

            //  If the distance between the mob and the player
            //  is less than or equal to the AttackDistance,
            //  the mob launches a projectile at the player.
            if (DistanceToPlayer <= AttackDistance) {
                //Debug.Log(this.gameObject.name + " is now in range! Ready to shoot player!");
                anim.SetBool("isWalking", true);
                //transform.position = transform.position;

                waitTime -= Time.deltaTime;
                if (waitTime <= 0) {
                    attack();
                    waitTime = 0.5f;
                }

                if (isAttacking == true)
                {
                    //Debug.Log(waitTime);
                    attackTime -= Time.deltaTime;
                    if (attackTime <= 0)
                    {
                        //Debug.Log("Attacking stopped...");
                        isAttacking = false;
                        sword.gameObject.SetActive(false);
                        attackTime = 0.2f;
                    }
                }
            }

            else if (!hostile && POS != SpawnPoint) {
                transform.position = Vector2.MoveTowards(transform.position, SpawnPoint, MoveSpeed * Time.deltaTime);
            }
        }
    } // END UPDATE()

    void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.tag == "Sword") {
            //Debug.Log(HP);
            spriteRend.color = new Color(1f, 0f, 0f, 1f);
            HP--;
            hitSource.Play();

            if (!hostile) {
                hostile = true;
            }
        }
    }

    void OnTriggerExit2D() {
        spriteRend.color = new Color(1f, 1f, 1f, 1f);
    }

    void attack() {
        //Debug.Log("Attacking!");
        sword.gameObject.SetActive(true);
        isAttacking = true;
    }
} // END CLASS AI_Knight