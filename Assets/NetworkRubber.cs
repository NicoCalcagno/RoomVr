using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class NetworkRubber : MonoBehaviourPunCallbacks
{
    private PhotonView photonView;
    public Transform rubberGlobal;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("i'm a chalk, and i'm instantiated");
        rubberGlobal = GameObject.Find("Rubber").transform;
    }

    

    void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            stream.SendNext(rubberGlobal.position);
            stream.SendNext(rubberGlobal.rotation);
        }
        else
        {
            this.transform.position = (Vector3)stream.ReceiveNext();
            this.transform.rotation = (Quaternion)stream.ReceiveNext();
        }
    }
}
