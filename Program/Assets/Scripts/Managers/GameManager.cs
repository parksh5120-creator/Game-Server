using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class GameManager : MonoBehaviourPunCallbacks
{
    [SerializeField] double time;
    [SerializeField] double initializeTime;

    private void Awake()
    {
       initializeTime = PhotonNetwork.Time;
    }

    private void Update()
    {
        time = PhotonNetwork.Time - initializeTime;

        Debug.Log(time);
    }
}
