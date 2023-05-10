using Service.SceneService;
using UnityEngine;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;

public class UIManager : MonoBehaviour
{
   [SerializeField] private Button button;

   private ISceneService _sceneService;
   
   public void Setup(ISceneService sceneService)
   {
      _sceneService = sceneService;
   }

   public void onClick()
   {
      _sceneService.LoadScene("Test");
   }
}
