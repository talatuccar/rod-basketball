
using UnityEngine;

public class ExitButton : UIManager
{
    protected override void OnClicked()
    {
        Application.Quit();
    }
}
