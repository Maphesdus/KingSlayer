using UnityEngine;
using System.Collections;

public class Warp : MonoBehaviour {
    public Transform warpTarget;

    // On Trigger Enter 2D:
    IEnumerator OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.tag == "Player") {

            //Debug.Log("An object collided.");
            ScreenFader sf = GameObject.FindGameObjectWithTag("Fader").GetComponent<ScreenFader>();

            // Debug.Log("PRE FADE OUT");

            yield return StartCoroutine(sf.FadeToBlack());

            //Debug.Log("UPDATE PLAYER POS");

            col.gameObject.transform.position = warpTarget.position;
            Camera.main.transform.position = warpTarget.position;

            //Debug.Log("PRE FADE IN");

            yield return StartCoroutine(sf.FadeToClear());

            //Debug.Log("FADE IN COMPLETE");
        }
    }
}