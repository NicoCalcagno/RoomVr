using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class RHandNetwork : MonoBehaviourPunCallbacks
{
    private PhotonView photonView;
    public Transform rHandGlobal;
    // Start is called before the first frame update
    void Start()
    {
        photonView = GetComponent<PhotonView>();
        if (photonView.IsMine)
        {
            Debug.Log("right hand is mine");
            rHandGlobal = GameObject.Find("OVRPlayerController/OVRCameraRig/TrackingSpace/RightHandAnchor").transform;
            this.transform.SetParent(rHandGlobal);
            this.transform.localPosition = Vector3.zero;
        }
    }


    void OnPhotonSerializeView(PhotonStream stream1, PhotonMessageInfo info)
    {
        if (stream1.IsWriting)
        {
            stream1.SendNext(rHandGlobal.position);
            stream1.SendNext(rHandGlobal.rotation);
            Debug.Log("R+++++++++ x:" + rHandGlobal.position.x + " y:" + rHandGlobal.position.y);
        }
        else
        {
            this.transform.position = (Vector3)stream1.ReceiveNext();
            this.transform.rotation = (Quaternion)stream1.ReceiveNext();
            Debug.Log("R%%%%%%%%% x:" + this.transform.position.x + " y:" + this.transform.position.y);
        }
    }
}
