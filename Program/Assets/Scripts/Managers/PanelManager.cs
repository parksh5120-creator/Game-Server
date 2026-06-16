using UnityEngine;

public class PanelManager : Singleton<PanelManager>
{
   public void Open(string Message)
    {
        Debug.Log(Message);
    }
}
