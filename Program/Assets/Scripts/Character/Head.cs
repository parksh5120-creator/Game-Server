using Photon.Pun;
using UnityEngine;

public class Head : MonoBehaviourPunCallbacks
{
    [SerializeField] Rotation rotation;

    [SerializeField] float minimumAngle = -55f;
    [SerializeField] float maximumAngle = 55f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        rotation = GetComponent<Rotation>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
