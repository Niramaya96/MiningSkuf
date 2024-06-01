using UnityEngine;

public class CharacterMining : MonoBehaviour
{
    [SerializeField] private Transform _startPoint;
    [SerializeField] private Vector3 _offset;
    [SerializeField,Min(0f)] private float _sphereRadius;
    [SerializeField] private LayerMask _resourseLayer;

    [Header("Gizmos")]
    [SerializeField] private Color _gizmosColor;

    private readonly Collider[] _hitColliders = new Collider[10];
    private int _hitCount;

    private void Update()
    {
        if (Input.GetMouseButton(0))
            TryGetResources();

    }

    private void OnDrawGizmos()
    {
        var position = _startPoint.TransformPoint(_offset);
        Gizmos.color = _gizmosColor;
        Gizmos.DrawSphere(position,_sphereRadius);
        
    }
    private void TryGetResources()
    {
       if (TryFindResources())
       {
            PerformMining();
       }
    }

    private bool TryFindResources()
    {
        var position = _startPoint.TransformPoint(_offset);
        _hitCount = Physics.OverlapSphereNonAlloc(position, _sphereRadius, _hitColliders, _resourseLayer.value);
        return _hitCount > 0;
    }
    private void PerformMining()
    {
        for (int i = 0; i < _hitCount; i++)
        {
            if (_hitColliders[i].TryGetComponent(out ResourceV2 resource) == false)
            {
                Debug.Log("Не найдено");
            }
            
            Debug.Log(resource.name);
        }
    }
}
