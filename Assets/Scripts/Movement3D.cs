using UnityEngine;

public class Movement3D : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed;
    private Rigidbody rigidbody3D;

    private void Awake()
    {
        rigidbody3D = GetComponent<Rigidbody>();
    }

    public void MoveTo(Vector3 direction, float force = 0)
    {
        Vector3 moveForce = Vector3.zero;

        if( force == 0 ) 
        {
            direction.y = 0;
            moveForce = direction.normalized * moveSpeed;
        }
        else
        {
            moveForce = direction * force;
        }

        //moveForce의 힘으로 오브젝트를 민다
        rigidbody3D.AddForce(moveForce);
    }
}
