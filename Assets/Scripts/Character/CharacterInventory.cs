using Lessons;
using Newtonsoft.Json.Linq;
using UnityEngine;

public class CharacterInventory : MonoBehaviour
{
    [SerializeField] private InventoryUI _inventoryDisplay;

    private ResourcesFeature _resourñes;

    private void Awake()
    {
        var wood = new Resource(ResourceType.Wood);
        var iron = new Resource(ResourceType.Iron);
        var stone = new Resource(ResourceType.Stone);

        var res = new[] {wood, iron, stone};

        _resourñes = new ResourcesFeature(res);

        _resourñes.ResourceChanged += OnResourceChanged;
    }
    public void AddResource(ResourceType resourceType,int value)
    {
        _resourñes.AddResource(resourceType, value);
    }
    public void SpendResource(ResourceType resourceType,int value)
    {
        bool hasResourñes = _resourñes.HasResource(resourceType, value);

        if (hasResourñes)
        {
            _resourñes.SpendResource(resourceType, value);
        }
    }
    private void OnResourceChanged(ResourceType type,int oldValue,int newValue)
    {
        Debug.Log($"Resource amount changed: {type} - Old:{oldValue} - New:{newValue}");
        _inventoryDisplay.ChangeResourceValueDisplay(type, newValue);
    }

    private void OnDestroy()
    {
        _resourñes.ResourceChanged -= OnResourceChanged;
    }
}
