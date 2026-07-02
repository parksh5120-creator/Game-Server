using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using UnityEngine;

public class MasterManager : MonoBehaviourPunCallbacks
{
    [SerializeField] private Transform createTransform;

    private IEnumerator Start()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            while (true)
            {
                GameObject clone = PhotonNetwork.Instantiate("Robot", Vector3.zero, Quaternion.identity);

                clone.transform.position = createTransform.position;

                yield return new WaitForSeconds(5.0f);
            }
        }
    }

    public override void OnMasterClientSwitched(Player newMasterClient)
    {
        Debug.Log(PhotonNetwork.PlayerList[0].NickName);

        PhotonNetwork.SetMasterClient(PhotonNetwork.PlayerList[0]);
    }

}