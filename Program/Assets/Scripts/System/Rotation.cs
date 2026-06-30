using UnityEngine;

public class Rotation : MonoBehaviour
{
    [SerializeField] float axis; 
    [SerializeField] float speed; 

    [SerializeField] float mouseX;
    [SerializeField] float mouseY;

    void Update()
    {
        mouseX += Input.GetAxisRaw("Mouse X");
        mouseY += Input.GetAxisRaw("Mouse Y");
    }  
    
    public void RotateY(Rigidbody rigidbody)
    {
        axis += mouseX * speed * Time.fixedDeltaTime;

        rigidbody.transform.eulerAngles = new Vector3(0, axis, 0);
    }
}
