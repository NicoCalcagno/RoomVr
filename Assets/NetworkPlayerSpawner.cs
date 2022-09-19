using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class NetworkPlayerSpawner : MonoBehaviourPunCallbacks
{
    private GameObject spawnedPlayerPrefab;
    public Transform spawnPointProf;
    public override void OnJoinedRoom(){
        base.OnJoinedRoom();
        spawnedPlayerPrefab = PhotonNetwork.Instantiate("OVRPlayerController", spawnPointProf.position, spawnPointProf.rotation);

    }

    public override void OnLeftRoom(){
        base.OnLeftRoom();
        PhotonNetwork.Destroy(spawnedPlayerPrefab);
    }
}
