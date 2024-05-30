using UnityEngine;

public class CharacterMining : MonoBehaviour
{
    [SerializeField] private Vector3 _centrePosition;
    [SerializeField] private float _sphereRadius;
    [SerializeField] private LayerMask _resourseLayer;

    private Collider[] _hitColliders = new Collider[10];
    private void TryMining()
    {
       var colliders = Physics.OverlapSphere(_centrePosition,_sphereRadius);

        foreach (var collider in colliders)
        {
            collider.TryGetComponent(out ResourceV2 resourse);
            Debug.Log(resourse.Name);
        }
    }
}
