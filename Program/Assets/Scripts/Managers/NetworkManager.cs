using UnityEngine;
using Photon.Pun;
using System.Collections.Generic;
public class NetworkManager : MonoBehaviourPunCallbacks
{

    [SerializeField] List<Transform> transforms = new List<Transform>();
    private void Start()
    {
        Create();
    }
    public void Create()
    {
        int index = PhotonNetwork.CurrentRoom.PlayerCount - 1;

        PhotonNetwork.Instantiate("Character", transforms[index].position, Quaternion.identity);
    }
}
