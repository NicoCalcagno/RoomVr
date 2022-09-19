using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

public class WBNetwork : MonoBehaviourPunCallbacks {
    public Texture2D whiteBoardTX;
    public Color[, ] array;
    // Start is called before the first frame update
    void Start () {
        array = new Color[2048, 2048];
        Debug.Log ("i'm a whiteboard, and i'm instantiated");
        whiteBoardTX = (Texture2D) GameObject.Find ("Whiteboard").GetComponent<Renderer> ().material.mainTexture;
        for (int i = 0; i < 2048; i++) {
            for (int j = 0; j < 2048; j++) {
                array[i, j] = whiteBoardTX.GetPixel (i, j);
                //Debug.Log("x" + i + " y" + j + " c" + array[i ,j]);
            }
        }
        
        //Debug.Log("x" + 0 + " y" + 0 + " c" + array[0 ,0]);
    }

    void OnPhotonSerializeView (PhotonStream stream, PhotonMessageInfo info) {
        if (stream.IsWriting) {
            Debug.Log("x" + 0 + " y" + 0 + " c" + array[0 ,0]);
            stream.SendNext(array);
            for (int k = 0; k < array.Length; k++) {
                for (int l = 0; l < array.Length; l++) {
                    Debug.Log ("x" + k + " y" + l + " c" + array[k, l]);
                    //whiteBoardTX.SetPixels (k, l, 10, 10, array[k][l]);
                }
            }

        } else {
            Debug.Log("x" + 0 + " y" + 0 + " c" + array[0 ,0]);
            array = (Color[, ]) stream.ReceiveNext ();
            for (int k = 0; k < array.Length; k++) {
                for (int l = 0; l < array.Length; l++) {
                    Debug.Log ("x" + k + " y" + l + " c" + array[k, l]);
                    //whiteBoardTX.SetPixels (k, l, 10, 10, array[k][l]);
                }
            }
            //whiteBoardTX.Apply ();
        }
    }
}