using UnityEngine;
using UnityEngine.UI;
public class BackToMenuHandler : MonoBehaviour
{
    public Button backToMenu;

    public void Start()
    {
        Debug.Log(backToMenu);
    }

    public void BackToMenu()
    {
        Debug.Log("Powrót do menu");
    }
}
