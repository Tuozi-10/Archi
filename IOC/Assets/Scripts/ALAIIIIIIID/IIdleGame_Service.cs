using Service;

namespace ALAIIIIIIID
{
    public interface IIdleGame_Service : IGameService
    {
        public void Switch();

        public void Enable();

        public void Disable();

        public void InitService();

        public void MakeLumberJack();

        public void MakeMinecraft();

        public void MakeDavidLaforge();
        
        public void SetUiIdleGame(UI_Idle_Game uiIdleGame);
    }
}