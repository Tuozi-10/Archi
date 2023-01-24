namespace Service.PopUpService
{
    public interface IPopUpService : IService
    {
        public void RegisterPopUp(string text, string header);

        public void LoadPopUp();
    }
}