using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private Vector3 _offcet;
    [SerializeField] private float _cameraSpeed;


    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        var nextPosition = Vector3.Lerp(transform.position,_target.position + _offcet,_cameraSpeed * Time.fixedDeltaTime);

        transform.position = nextPosition;
    }
}
