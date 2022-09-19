
using System;
//using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Photon.Pun;
public class WhiteBoard : MonoBehaviourPun {
    public int textureSize;
    public int penSize;
    private Texture2D texture;
    private Color[] color;
    private Color colorpixel;

    private bool touching, touchingLast;
    private float posx, posy;
    private float lastx, lasty, lastTime;

    // Start is called before the first frame update
    void Start () {
        Renderer renderer = GetComponent<Renderer> ();
        // Collider collidere = GetComponent<Collider>();
        // Debug.Log(collidere.bounds.size);
        this.texture = new Texture2D (textureSize, textureSize);
        renderer.material.mainTexture = this.texture;
        //this.texture.SetPixels(100, 30, penSize, penSize, color);
        //this.texture.Apply();
    }

    // Update is called once per frame
    void Update () {
        //Debug.Log(posx + " || " + posy);
        int x = (int) (posx * textureSize - (penSize / 2));
        int y = (int) (posy * textureSize - (penSize / 2));
        //texture.SetPixels(x, y, penSize, penSize, color);
        //Debug.Log(x + "|" + y);

        if (touchingLast) {
            if (Math.Abs (lasty - y) < 50 && Math.Abs (lastx - x) < 50)
                for (float t = 0.01f; t < 1.00f; t += 0.01f) {
                    int lerpx = (int) Mathf.Lerp (lastx, (float) x, t);
                    int lerpy = (int) Mathf.Lerp (lasty, (float) y, t);
                    //Debug.Log(lerpx + " | " + lerpy);
                    texture.SetPixels (lerpx, lerpy, penSize, penSize, color);
                }
            else
                texture.SetPixels (x, y, penSize, penSize, color);
            texture.Apply ();

        }
        this.lastx = (float) x;
        this.lasty = (float) y;
        this.touchingLast = this.touching;
    }

    

    public void ToggleTouch (bool touching) {
        GetComponent<PhotonView>().RPC("ToggleTouchRPC", RpcTarget.All, touching);
    }

    public void SetColor (float col, int size) {
        GetComponent<PhotonView>().RPC("SetColorRPC", RpcTarget.All, col, size);
    }

    public void SetTouchPosition (float x, float y) {
        GetComponent<PhotonView>().RPC("SetTouchPositionRPC", RpcTarget.All, x, y);
    }

    [PunRPC]
    public void SetTouchPositionRPC (float x, float y) {
        this.posx = x;
        this.posy = y;
        //Debug.Log("SetTouchPosition()");
    }

    [PunRPC]
    public void SetColorRPC (float col, int size){
        if (col == 1.0)
        {
            this.penSize = size;
            colorpixel = Color.black;
        }
        else if (col == 2.0)
        {
            this.penSize = size;
            colorpixel = Color.red;
        }
        else if (col == 3.0)
        {
            this.penSize = size;
            colorpixel = Color.green;
        }
        else if (col == 4.0)
        {
            this.penSize = size;
            colorpixel = Color.blue;
        }
        else if(col == 5.0)
        {
            this.penSize = size;
            colorpixel = Color.yellow;
        }
        else{
            this.penSize = size;
            colorpixel = Color.white;
        }
        this.color = Enumerable.Repeat<Color>(colorpixel, penSize * penSize).ToArray<Color>();
        //Debug.Log("SetColor");
    }

    [PunRPC]
    public void ToggleTouchRPC(bool touching){
        this.touching = touching;
        //Debug.Log("ToggleTouch");
    }
}