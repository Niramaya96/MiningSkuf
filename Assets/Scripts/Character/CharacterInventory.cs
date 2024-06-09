using Lessons;
using Newtonsoft.Json.Linq;
using UnityEngine;

public class CharacterInventory : MonoBehaviour
{
    [SerializeField] private InventoryUI _inventoryDisplay;

    private ResourcesFeature _resour�es;

    private void Awake()
    {
        var wood = new Resource(ResourceType.Wood);
        var iron = new Resource(ResourceType.Iron);
        var stone = new Resource(ResourceType.Stone);

        var res = new[] {wood, iron, stone};

        _resour�es = new ResourcesFeature(res);

        _resour�es.ResourceChanged += OnResourceChanged;
    }
    public void AddResource(ResourceType resourceType,int value)
    {
        _resour�es.AddResource(resourceType, value);
    }
    public void SpendResource(ResourceType resourceType,int value)
    {
        bool hasResour�es = _resour�es.HasResource(resourceType, value);

        if (hasResour�es)
        {
            _resour�es.SpendResource(resourceType, value);
        }
    }
    private void OnResourceChanged(ResourceType type,int oldValue,int newValue)
    {
        Debug.Log($"Resource amount changed: {type} - Old:{oldValue} - New:{newValue}");
        _inventoryDisplay.ChangeResourceValueDisplay(type, newValue);
    }

    private void OnDestroy()
    {
        _resour�es.ResourceChanged -= OnResourceChanged;
    }
}
