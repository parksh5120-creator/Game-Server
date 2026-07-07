using UnityEngine;
using Photon.Pun;

public class Character : MonoBehaviourPun, IPunObservable
{
    [SerializeField] float speed;
    [SerializeField] float health = 100;

    [SerializeField] Vector3 direction;
    [SerializeField] Rotation rotation;
    [SerializeField] Rigidbody rigidBody;
    [SerializeField] Animator animator;

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody>();
        rotation = GetComponent<Rotation>();
        animator = GetComponent<Animator>();
    }
    private void Start()
    {
        DisableCamera();
    }

    private void Update()
    {
        if (photonView.IsMine)
        {
            Control();

            Animate();

            Pause();
        }
    }
    private void FixedUpdate()
    {
        if (photonView.IsMine)
        {
            Move();

            rotation.RotateY(rigidBody);
        }
        
    }

    void Pause()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            MouseManager.Instance.SetMouse(true);

            PanelManager.Instance.Open(Panel.Pause);
        }
    }
    void Control()
    {
        rotation.MouseX = Input.GetAxisRaw("Mouse X");

        direction.x = Input.GetAxisRaw("Horizontal");
        direction.z = Input.GetAxisRaw("Vertical");

        direction.Normalize();
    }

    void Animate()
    {
      
        
        animator.SetInteger("X", Mathf.Abs((int)direction.x));
        animator.SetInteger("Y", Mathf.Abs((int)direction.z));
        

        
    }

    void Move()
    {
        rigidBody.linearVelocity = rigidBody.transform.TransformDirection(direction).normalized * speed;
    }
    private void DisableCamera()
    {
        if (photonView.IsMine)
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
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Robot"))
        {
            PhotonView view = other.GetComponent<PhotonView>();

            if (view != null)
            {
                Debug.Log("Robot Object does not have a PhotonView");
            }

            if (view.IsMine || PhotonNetwork.IsMasterClient)
            {
                PhotonNetwork.Destroy(other.gameObject);
            }

        }
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            stream.SendNext(health);
        }
        else
        {
            health = (float)stream.ReceiveNext();
        }
    }

}
