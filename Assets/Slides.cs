using System;
//using System.Diagnostics;
//using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Photon.Pun;
using UnityEngine;

public class Slides : MonoBehaviourPun {

    public int textureSize;
    public int penSize;
    private Texture2D texture;
    private Color[] color;
    private Color colorpixel;
    public Sprite[] spriteArray = new Sprite[20];

    private bool touching, touchingLast;
    private float posx, posy;
    private float lastx, lasty, lastTime;
    private int spriteIndex;
    // Start is called before the first frame update
    void Start () {
        Renderer renderer = GetComponent<Renderer> ();
        // Collider collidere = GetComponent<Collider>();
        // Debug.Log(collidere.bounds.size);
        spriteIndex = 0;
        renderer.material.mainTexture = spriteArray[spriteIndex].texture;

        //this.texture.SetPixels(100, 30, penSize, penSize, color);
        //this.texture.Apply();
    }

    // Update is called once per frame
    void Update () {
        //Debug.Log(posx + " || " + posy);
        //int x = (int) (posx * textureSize - (penSize / 2));
        //int y = (int) (posy * textureSize - (penSize / 2));
        //texture.SetPixels(x, y, penSize, penSize, color);
        //Debug.Log(x + "|" + y);

        //
        //this.lastx = (float) x;
        //this.lasty = (float) y;
        //this.touchingLast = this.touching;
    }

    public void ToggleTouch (bool touch) {
        GetComponent<PhotonView> ().RPC ("ToggleTouchRPC", RpcTarget.All, touch);
    }

    [PunRPC]
    public void ToggleTouchRPC (bool touch) {

        //if (this.touching == false) {
        if (touch == true) {
            //sleep (9000f);
            this.spriteIndex = this.spriteIndex + 1;
            Debug.Log (this.spriteIndex);
            GetComponent<Renderer> ().material.mainTexture = spriteArray[this.spriteIndex].texture;
            this.touching = touch;
            /* } else {
                //sleep (9000f);
                this.touching = touch;
            }
        } else {
            sleep (9000f);
            this.touching = false;

        }*/

            //GetComponent<PhotonView> ().RPC ("ToggleTouchRPC", RpcTarget.All, touching);
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

    public void SetColor (float col, int size) {
        GetComponent<PhotonView> ().RPC ("SetColorRPC", RpcTarget.All, col, size);
    }

    public void SetTouchPosition (float x, float y) {
        GetComponent<PhotonView> ().RPC ("SetTouchPositionRPC", RpcTarget.All, x, y);
    }

    /*IEnumerator WaitFive () {
        //print (Time.time);
        Debug.Log ("Waiting..");
        yield return new WaitForSeconds (100);
        //Debug.Log ("stop..");
        //print (Time.time);
    }*/

    [PunRPC]
    public void SetTouchPositionRPC (float x, float y) {
        this.posx = x;
        this.posy = y;
        //Debug.Log("SetTouchPosition()");
    }

    [PunRPC]
    public void SetColorRPC (float col, int size) {
        if (col == 1.0) {
            this.penSize = size;
            colorpixel = Color.black;
        } else if (col == 2.0) {
            this.penSize = size;
            colorpixel = Color.red;
        } else if (col == 3.0) {
            this.penSize = size;
            colorpixel = Color.green;
        } else if (col == 4.0) {
            this.penSize = size;
            colorpixel = Color.blue;
        } else if (col == 5.0) {
            this.penSize = size;
            colorpixel = Color.yellow;
        } else {
            this.penSize = size;
            colorpixel = Color.white;
        }
        this.color = Enumerable.Repeat<Color> (colorpixel, penSize * penSize).ToArray<Color> ();
        //Debug.Log("SetColor");
    }

}