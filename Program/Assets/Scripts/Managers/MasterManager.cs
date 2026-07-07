using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using UnityEngine;

public class MasterManager : MonoBehaviourPunCallbacks
{
    [SerializeField] Transform createTransform;
    [SerializeField] GameObject clone;

    private IEnumerator Start()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            while (true)
            {
                if(PhotonNetwork.CurrentRoom != null)
                {
                    if(clone == null)
                    {
                        clone = PhotonNetwork.Instantiate("Robot", Vector3.zero, Quaternion.identity);

                        clone.transform.position = createTransform.position;
                    }
                }
                yield return new WaitForSeconds(5.0f);
            }
        }
    }

    public override void OnMasterClientSwitched(Player newMasterClient)
    {
        PhotonNetwork.SetMasterClient(PhotonNetwork.PlayerList[0]);
    }

}