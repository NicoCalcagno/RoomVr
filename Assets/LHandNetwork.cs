using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class LHandNetwork : MonoBehaviourPunCallbacks
{
    private PhotonView photonView;
    public Transform lHandGlobal;
    // Start is called before the first frame update
    void Start()
    {
        photonView = GetComponent<PhotonView>();
        if (photonView.IsMine)
        {
            Debug.Log("left hand is mine");
            lHandGlobal = GameObject.Find("OVRPlayerController/OVRCameraRig/TrackingSpace/LeftHandAnchor").transform;
            this.transform.SetParent(lHandGlobal);
            this.transform.localPosition = Vector3.zero;
        }
    }


    void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            stream.SendNext(lHandGlobal.position);
            stream.SendNext(lHandGlobal.rotation);
            Debug.Log("L+++++++++ x:" + lHandGlobal.position.x + " y:" + lHandGlobal.position.y);
        }
        else
        {
            this.transform.position = (Vector3)stream.ReceiveNext();
            this.transform.rotation = (Quaternion)stream.ReceiveNext();
            Debug.Log("L%%%%%%%%% x:" + this.transform.position.x + " y:" + this.transform.position.y);
        }
    }
}
