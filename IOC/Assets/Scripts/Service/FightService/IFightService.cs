namespace Service.FightService
{
    public interface IFightService : IService, ISwitchableService
    {
        public void CreateFighter();
        public void RotateFighter();
    }
}
