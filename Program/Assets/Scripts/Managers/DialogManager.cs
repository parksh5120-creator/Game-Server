using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using System;
using UnityEngine.UI;

public class DialogManager : MonoBehaviourPunCallbacks
{
    [SerializeField] InputField inputField;
    [SerializeField] ScrollRect scrollRect;
    [SerializeField] Transform parentTransform;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return))
        {
            inputField.ActivateInputField();

            if(inputField.text.Length < 0)
            {
                return;
            }

            string message = $"<color=green>{PhotonNetwork.LocalPlayer.NickName} </color>" + " : " + inputField.text;

            photonView.RPC("Send", RpcTarget.All, message);

            inputField.text = "";

            inputField.ActivateInputField();
        }
    }

    [PunRPC]
    public void Send(string message)
    {
        Text talk = Instantiate(Resources.Load<Text>("Message"), parentTransform);

        talk.text = message;

        Canvas.ForceUpdateCanvases();

        scrollRect.verticalNormalizedPosition = 0.0f;
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        string message = $"<color=green>{newPlayer.NickName} joined the room.</color>";

        photonView.RPC("Send", RpcTarget.All, message);
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        string message = $"<color=green>{otherPlayer.NickName} left the room.</color>";

        photonView.RPC("Send", RpcTarget.All, message);
    }
}
