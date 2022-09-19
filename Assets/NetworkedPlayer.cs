using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

public class NetworkedPlayer : MonoBehaviourPunCallbacks
{
    public GameObject avatar;
    public GameObject lHandLocal, rHandLocal;
    private GameObject ovr;
    private PhotonView photonView;
    public Transform playerGlobal;
    public Transform playerLocal;
    public Transform lHandGlobal;
    public Transform rHandGlobal;
    public GameObject camera;

    public Transform head, rhand, lhand;
    private Transform headOvr, leftOvr, rightOvr;
    void Start()
    {
        photonView = GetComponent<PhotonView>();
        Debug.Log("i'm instantiated");

        /* if (photonView.IsMine) {
            Debug.Log ("player is mine");
             //ovr = GameObject.Find("OVRPlayerControllerLocal");
             //Debug.Log("OVR" + ovr.name);
             //Destroy(ovr);

            /*camera = GameObject.Find("CenterEyeAnchor1(Clone)");
            camera.transform.SetParent(GameObject.Find("OVRPlayerControllerHuman/OVRCameraRig/TrackingSpace").transform);
            camera.transform.localPosition = Vector3.zero;*/

        playerGlobal = GameObject.Find("OVRPlayerControllerHuman").transform;
        /*playerLocal = playerGlobal.Find("OVRCameraRig/TrackingSpace/CenterEyeAnchor");
        lHandGlobal = playerGlobal.Find("OVRCameraRig/TrackingSpace/LeftHandAnchor").transform;
        rHandGlobal = playerGlobal.Find("OVRCameraRig/TrackingSpace/RightHandAnchor").transform;

        this.transform.SetParent(playerLocal);
        this.transform.localPosition = Vector3.zero;

        lHandLocal.SetActive(false);
        rHandLocal.SetActive(false);
        avatar.SetActive(false);*/

        headOvr = playerGlobal.Find("OVRCameraRig/TrackingSpace/CenterEyeAnchor");
        leftOvr = playerGlobal.Find("OVRCameraRig/TrackingSpace/LeftHandAnchor").transform;
        rightOvr = playerGlobal.Find("OVRCameraRig/TrackingSpace/RightHandAnchor").transform;

    }


    void Update()
    {
        if(photonView.IsMine){
            head.gameObject.SetActive(false);
            rhand.gameObject.SetActive(false);
            lhand.gameObject.SetActive(false);

            MapPosition(head, headOvr);
            MapPosition(lhand, leftOvr);
            MapPosition(rhand, rightOvr);
        }

    }


    void MapPosition(Transform target, Transform rigTransform){
        target.position = rigTransform.position;
        target.rotation = rigTransform.rotation;
    }
}

    /* void OnPhotonSerializeView (PhotonStream stream, PhotonMessageInfo info) {
        if (stream.IsWriting) {
            stream.SendNext (playerGlobal.position);
            stream.SendNext (playerGlobal.rotation);
            stream.SendNext (playerLocal.transform.position);
            stream.SendNext (playerLocal.transform.rotation);
            stream.SendNext (lHandGlobal.position);
            stream.SendNext (lHandGlobal.rotation);
            stream.SendNext (rHandGlobal.position);
            stream.SendNext (rHandGlobal.rotation);
            //Debug.Log ("L:" + lHandGlobal.position.x + " " + lHandGlobal.position.y);
            //Debug.Log ("R:" + rHandGlobal.position.x + " " + rHandGlobal.position.y);
        } else {
            this.transform.position = (Vector3) stream.ReceiveNext ();
            this.transform.rotation = (Quaternion) stream.ReceiveNext ();
            avatar.transform.position = (Vector3) stream.ReceiveNext ();
            avatar.transform.rotation = (Quaternion) stream.ReceiveNext ();
            lHandLocal.transform.position = (Vector3) stream.ReceiveNext ();
            lHandLocal.transform.rotation = (Quaternion) stream.ReceiveNext ();
            rHandLocal.transform.position = (Vector3) stream.ReceiveNext ();
            rHandLocal.transform.rotation = (Quaternion) stream.ReceiveNext ();
            //Debug.Log ("Hello");
        }
    }*/
