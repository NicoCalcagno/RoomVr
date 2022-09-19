using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class WhiteboardPen : MonoBehaviour {
    public WhiteBoard whiteboard;
    public int size;
    public float colorpen;
    public Color colorray;
    private RaycastHit touch;
    // Start is called before the first frame update
    void Start () {
        this.whiteboard = GameObject.Find("Whiteboard").GetComponent<WhiteBoard>();
        /* Vector3[] initLaserPositions = new Vector3[2] { Vector3.zero, Vector3.zero };
        laserLineRenderer.SetPositions(initLaserPositions);
        laserLineRenderer.startWidth = laserWidth;
        laserLineRenderer.endWidth = laserWidth;*/
    }

    // Update is called once per frame
    void Update () {
        // float tipHeight = transform.Find("Tip").transform.localScale.y;
        // Vector3 tip = transform.Find("Tip").transform.position;

        if(OVRInput.Get(OVRInput.Button.One)) {
        if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.up), out touch, Mathf.Infinity)) {
            /* laserLineRenderer.enabled = true;

            laserLineRenderer.SetPosition(0, transform.TransformDirection(Vector3.up));
            laserLineRenderer.SetPosition(1, touch.transform.position);*/
            //Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.up) * touch.distance, colorray);
            if (!(touch.collider.tag == "WhiteBoard")) {
                // Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.up) * 1000, Color.white);
                return;
            }

            //this.whiteboard = touch.collider.GetComponent<WhiteBoard>();
            //Debug.Log("WhiteBoard");

            this.whiteboard.SetColor(colorpen, size);
            this.whiteboard.SetTouchPosition(touch.textureCoord.x, touch.textureCoord.y);
            this.whiteboard.ToggleTouch(true);
        } else {
            this.whiteboard.ToggleTouch(false);
        }
        }
    }
}