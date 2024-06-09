using UnityEngine;

public class CharacterMining : MonoBehaviour
{
    [SerializeField] private Transform _startPoint;
    [SerializeField] private Vector3 _offset;
    [SerializeField,Min(0f)] private float _sphereRadius;
    [SerializeField] private LayerMask _resourseLayer;

    [Header("Inventory")]
    [SerializeField] private CharacterInventory _inventory;

    [Header("Gizmos")]
    [SerializeField] private Color _gizmosColor;

    private readonly Collider[] _hitColliders = new Collider[10];
    private int _hitCount;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
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
            PerformGather();
       }
    }

    private bool TryFindResources()
    {
        var position = _startPoint.TransformPoint(_offset);
        _hitCount = Physics.OverlapSphereNonAlloc(position, _sphereRadius, _hitColliders, _resourseLayer.value);
        return _hitCount > 0;
    }
    private void PerformGather()
    {
        for (int i = 0; i < _hitCount; i++)
        {
            if (_hitColliders[i].TryGetComponent(out ResourceAdapter resource) == false)
            {
                Debug.Log("Не найдено");
                continue;
            }

            var amount = resource.Gather();
            var type = resource.Type;
            _inventory.AddResource(type,amount);
        }
    }
}
