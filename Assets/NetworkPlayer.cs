using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using UnityEngine.XR;

public class NetworkPlayer : MonoBehaviour {
    public Transform head;

    private PhotonView photonView;
    void Start () {
        photonView = GetComponent<PhotonView>();
    }

    // Update is called once per frame
    void Update () {

        if (!photonView.IsMine) {
            head.gameObject.SetActive(false);

            //MapPosition(head, XRNode.Head);
        }

    }

    void MapPosition (Transform target, XRNode node) {
        InputDevices.GetDeviceAtXRNode(node).TryGetFeatureValue(CommonUsages.devicePosition, out Vector3 position);
        InputDevices.GetDeviceAtXRNode(node).TryGetFeatureValue(CommonUsages.deviceRotation, out Quaternion rotation);

        target.position = position;
        target.rotation = rotation;
    }
}