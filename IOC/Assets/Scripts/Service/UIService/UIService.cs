using Attributes;

public class UIService : IUIService
{
    [DependsOnService]
    private IMenuService menuService;
    
    
    public void LoadUI()
    {
        menuService.LoadMenu();
    }
}
