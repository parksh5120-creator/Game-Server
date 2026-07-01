using UnityEngine;
using Photon.Pun;

public class Character : MonoBehaviourPun
{
    [SerializeField] float speed;
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
    private void Control()
    {
        direction.x = Input.GetAxisRaw("Horizontal");
        direction.z = Input.GetAxisRaw("Vertical");

        if(direction.x > 0 || direction.z > 0)
        {
          //  animator.SetInteger()
        }

        direction.Normalize();
    }

    private void Move()
    {
        rigidBody.MovePosition(rigidBody.position + rigidBody.transform.TransformDirection(direction) * speed * Time.fixedDeltaTime);
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
}
