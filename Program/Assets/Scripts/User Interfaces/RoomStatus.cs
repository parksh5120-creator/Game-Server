using Photon.Pun;
using UnityEngine;
using TMPro;
using Photon.Realtime;

public class RoomStatus : MonoBehaviourPunCallbacks
{
    [SerializeField] Data data = new Data();

    [SerializeField] TextMeshProUGUI roomNameText;
    [SerializeField] TextMeshProUGUI roomIndexText;
    [SerializeField] TextMeshProUGUI roomPersonnelText;

    public void Refresh(RoomInfo roomInfo, int index)
    {
        data.Name = roomInfo.Name;
        data.Index = index + 1;
        data.PlayerCount = roomInfo.PlayerCount;
        data.maxPlayers = roomInfo.MaxPlayers;

        roomNameText.text = roomInfo.Name;
        roomIndexText.text = data.Index.ToString();
        roomPersonnelText.text = $"({roomInfo.PlayerCount} / {data.maxPlayers})";
    }
}
