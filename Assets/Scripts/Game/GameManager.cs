using Game.Level;
using Zenject;

namespace Game
{
    // needed for debugging
    public class GameManager : IGameManager
    {
            // Unity Message
            [Inject] private ILevelManager _levelManager;
            
            public void OnStart() {}

            public void OnQuit() {}

            public void StartLevelPlay()
            {

            }

            public void WinLevel()
            {
      
            }

            public void Fail()
            {
       
            }

            public void NextLevel()
            {
                _levelManager.NextLevel();
     
            }

            public void Replay()
            {
                _levelManager.LoadCurrent();
            }

            


    }
}