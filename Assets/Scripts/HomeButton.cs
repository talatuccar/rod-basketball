
using UnityEngine.SceneManagement;

public class HomeButton : UIManager
{
    protected override void OnClicked()
    {
        SceneManager.LoadScene(0);
    }
}
