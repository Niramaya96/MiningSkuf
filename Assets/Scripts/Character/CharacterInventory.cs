using Lessons;
using Newtonsoft.Json.Linq;
using UnityEngine;

public class CharacterInventory : MonoBehaviour
{
    [SerializeField] private InventoryUI _inventoryDisplay;

    private ResourcesFeature _resourņes;

    private void Awake()
    {
        var wood = new Resource(ResourceType.Wood);
        var iron = new Resource(ResourceType.Iron);
        var stone = new Resource(ResourceType.Stone);

        var res = new[] {wood, iron, stone};

        _resourņes = new ResourcesFeature(res);

        _resourņes.ResourceChanged += OnResourceChanged;
    }
    public void AddResource(ResourceType resourceType,int value)
    {
        _resourņes.AddResource(resourceType, value);
    }
    public void SpendResource(ResourceType resourceType,int value)
    {
        bool hasResourņes = _resourņes.HasResource(resourceType, value);

        if (hasResourņes)
        {
            _resourņes.SpendResource(resourceType, value);
        }
    }
    private void OnResourceChanged(ResourceType type,int oldValue,int newValue)
    {
        Debug.Log($"Resource amount changed: {type} - Old:{oldValue} - New:{newValue}");
        _inventoryDisplay.ChangeResourceValueDisplay(type, newValue);
    }

    private void OnDestroy()
    {
        _resourņes.ResourceChanged -= OnResourceChanged;
    }
}
