
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using UnityEngine.XR;
using Photon.Realtime;
public class NetworkController : MonoBehaviourPunCallbacks
{
    public Transform spawnPointProf;
    public Transform spawnPointChalkB;
    public Transform spawnPointChalkBl;
    public Transform spawnPointChalkG;
    public Transform spawnPointChalkR;
    public Transform spawnPointChalkY;
    public Transform spawnPointRubber;
    public Transform spawnPointWB;
    void Start()
    {
        ConnectToServer();
    }

    void ConnectToServer(){
        PhotonNetwork.ConnectUsingSettings();
        Debug.Log("Try Connect to server...");

    }

    public override void OnConnectedToMaster(){
        Debug.Log("Connected to server.");
        base.OnConnectedToMaster();
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = 15;
        roomOptions.IsVisible = true;
        roomOptions.IsOpen = true;

        PhotonNetwork.JoinOrCreateRoom("Room1", roomOptions, TypedLobby.Default);
    }

    public override void OnJoinedRoom(){
        base.OnJoinedRoom();
        Debug.Log("OnJoinedRoom");
        //PhotonNetwork.Instantiate("OVRPlayerControllerHuman", spawnPointProf.position, spawnPointProf.rotation, 0);
        //Destroy(GameObject.Find("OVRPlayerControllerHuman/OVRCameraRig/TrackingSpace/CenterEyeAnchor"));
        //PhotonNetwork.Instantiate("CenterEyeAnchor1", spawnPointProf.position, spawnPointProf.rotation, 0);
        PhotonNetwork.Instantiate("NetworkedPlayer", spawnPointProf.position, spawnPointProf.rotation, 0);
        PhotonNetwork.Instantiate("NetworkedChalkB", spawnPointChalkB.position, spawnPointChalkB.rotation, 0);
        //PhotonNetwork.Instantiate("NetworkedChalkBl", spawnPointChalkBl.position, spawnPointChalkBl.rotation, 0);
        //PhotonNetwork.Instantiate("NetworkedChalkG", spawnPointChalkG.position, spawnPointChalkG.rotation, 0);
        //PhotonNetwork.Instantiate("NetworkedChalkR", spawnPointChalkR.position, spawnPointChalkR.rotation, 0);
        //PhotonNetwork.Instantiate("NetworkedChalkY", spawnPointChalkY.position, spawnPointChalkY.rotation, 0);
        //PhotonNetwork.Instantiate("NetworkedRubber", spawnPointRubber.position, spawnPointRubber.rotation, 0);
        //PhotonNetwork.Instantiate("WBNetwork", spawnPointWB.position, spawnPointWB.rotation, 0);
        //PhotonNetwork.Instantiate("LHandNet", spawnPointProf.position, spawnPointProf.rotation, 0);
        //PhotonNetwork.Instantiate("RHandNet", spawnPointProf.position, spawnPointProf.rotation, 0);
    }
}
