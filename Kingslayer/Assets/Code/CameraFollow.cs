using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {
    public Transform target;
    public float scale = 4f;
    public float speed = 0.1f;
    Camera cam;
    Vector3 start;
    Vector3 end;


    // Use this for initialization
    void Start () {
        cam = GetComponent<Camera>();
	}
	
	// Update is called once per frame
	void Update () {
        cam.orthographicSize = (Screen.height / 100f) / scale;
        start = transform.position;
        end = target.position;

        if (target) {
            transform.position = Vector3.Lerp(start, end, speed) + new Vector3(0, 0, -10);
        }
	}
}