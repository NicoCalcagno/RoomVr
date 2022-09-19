using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class NetworkChalkB : MonoBehaviourPunCallbacks
{
    public Transform chalkGlobal;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("i'm a chalk, and i'm instantiated");
        chalkGlobal = GameObject.Find("ChalkB").transform;
    }

    

    void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            stream.SendNext(chalkGlobal.position);
            stream.SendNext(chalkGlobal.rotation);
        }
        else
        {
            this.transform.position = (Vector3)stream.ReceiveNext();
            this.transform.rotation = (Quaternion)stream.ReceiveNext();
        }
    }
}
