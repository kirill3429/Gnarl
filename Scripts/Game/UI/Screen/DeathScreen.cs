using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class DeathScreen : Screen
{
    public override void Show(bool state = true)
    {
        base.Show(state);
        Time.timeScale = 0;
    }
    private void OnDisable()
    {
        Time.timeScale = 1;
    }
}
