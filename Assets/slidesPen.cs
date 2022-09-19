using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slidesPen : MonoBehaviour {
    public Slides slidesBoard;
    public int size;
    public float colorpen;
    public Color colorray;
    private RaycastHit touch;
    public float time, timeLastPass;
    public LineRenderer laser;
    public Color c1, c2;
    public GameObject spawnPointlaser;
    // Start is called before the first frame update
    void Start () {
        c1 = Color.red;
        c2 = Color.green;
        this.slidesBoard = GameObject.Find ("slides").GetComponent<Slides> ();
        laser = GameObject.Find ("Laser").GetComponent<LineRenderer> ();
        spawnPointlaser = GameObject.Find ("spawnPointLaser");
    }

    // Update is called once per frame
    void Update () {
        laser.SetColors (c2, c2);
        laser.SetPosition (0, spawnPointlaser.transform.position);
        laser.SetPosition (1, transform.TransformDirection (Vector3.up) * 5000);
        if (OVRInput.Get (OVRInput.Button.One)) {
            if (Physics.Raycast (transform.position, transform.TransformDirection (Vector3.up), out touch, Mathf.Infinity)) {
                //laser.SetPosition (0, this.transform.position);
                laser.SetPosition (1, touch.point);
                laser.SetColors (c1, c1);
                time = Time.time; //The time at the beginning of this frame (Read Only). This is the time in seconds since the start of the game.
                float deltaTime = time - timeLastPass; //The time since the spacebar was successfully used
                if (deltaTime > 0.6f) {
                    if ((touch.collider.tag == "SlidesBoard")) {
                        // Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.up) * 1000, Color.white);
                        this.slidesBoard.ToggleTouch (true);
                        Debug.Log (touch.collider.tag);
                        //sleep (900000f);
                    } else {
                        this.slidesBoard.ToggleTouch (false);
                    }
                    timeLastPass = time;
                }

            } else {
                this.slidesBoard.ToggleTouch (false);
                //laser.SetPosition (0, this.transform.position);
                laser.SetPosition (1, transform.forward * 5000);
            }
        }
    }

    void sleep (float seconds) {
        StartCoroutine (WaitFive (seconds));
    }

    IEnumerator WaitFive (float seconds) {
        //print (Time.time);
        Debug.Log ("Waiting..");
        yield return new WaitForSeconds (seconds);
        //Debug.Log ("stop..");
        //print (Time.time);
    }
}