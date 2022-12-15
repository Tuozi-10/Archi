using Attributes;
using Service.AudioService;

namespace Service
{
    public class GameService : IGameService
    {
        [DependsOnService] 
        private IAudioService m_audioService;

        [ServiceInit]
        private void Initialize()
        {
            m_audioService.PlaySound(0);
        }
    }
}