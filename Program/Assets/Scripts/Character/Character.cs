using UnityEngine;
using Photon.Pun;

public class Character : MonoBehaviourPun
{
    private void Start()
    {
        DisableCamera();
    }

    private void DisableCamera()
    {
        if (photonView.IsMine == false)
        {
            Camera.main.gameObject.SetActive(false);
        }
        else
        { 
            Camera eyes = transform.GetComponent<Camera>();

            eyes.GetComponent<AudioListener>().gameObject.SetActive(false);

            eyes.gameObject.SetActive(false);
        }
    }
}
