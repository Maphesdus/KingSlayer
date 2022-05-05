using UnityEngine;
using System.Collections;

public class PlayerCombat : MonoBehaviour {
    public float waitTime = 0.2f;
    public int attackSpeed = 2000;
    private bool isAttacking = false;

    public GameObject sword;
    private GameObject Player;

    // START:
    void Start () {
        Player = GameObject.FindGameObjectWithTag("Player");
        sword.gameObject.SetActive(false);
    }

	// UPDATE:
	void Update () {
        sword.gameObject.transform.RotateAround(Player.gameObject.transform.position, Vector3.back, attackSpeed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space)) {
            if (MainQuest.foundSword) {
                attack();
            }
        }

        if (isAttacking == true) {
            //Debug.Log(waitTime);
            waitTime -= Time.deltaTime;

            if (waitTime <= 0) {
                //Debug.Log("Attacking stopped...");
                isAttacking = false;
                sword.gameObject.SetActive(false);
                waitTime = 0.2f;
            }
        }
    }

    void attack() {
        //Debug.Log("Attacking!");
        sword.gameObject.SetActive(true);
        isAttacking = true;
    }
}