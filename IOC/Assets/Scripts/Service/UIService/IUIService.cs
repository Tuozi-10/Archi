namespace Service
{
    public interface IUIService : IService
    {
        void DisplayMainMenu();
        void DisplayInGameMenu();
        void CallPopup();
    }
}