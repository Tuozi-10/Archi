using System;

namespace Service.FightSerice
{
    public interface IFightService : ISwitchableService
    {
        public Action OnFightAction { get; set; }
    }
}