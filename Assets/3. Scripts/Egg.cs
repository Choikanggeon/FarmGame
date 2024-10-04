using EnumTypes;
using EventLibrary;


public class Egg : Resource
{
    private void OnEnable()
    {
        Data.Name = "Egg";
        Data.EA = 1.5f;
        Data.Price = 10;
    }

    public override void OnMouseDown()
    {
        // 클릭하면 자원이 인벤토리에 추가됨
        EventManager<UIEvents>.TriggerEvent<Resource>(UIEvents.OnClickRestoreResource, this);
        this.gameObject.SetActive(false);
    }
    
}
