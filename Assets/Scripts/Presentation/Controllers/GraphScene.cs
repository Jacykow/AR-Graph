using UnityEngine;
using UnityEngine.UI;
public class GraphScene : MonoBehaviour
{
    private Button backToMenu;

    public void Start()
    {
        double screenHeight = Screen.height;
        double screenWidth = Screen.width;

        backToMenu = GameObject.Find("backToMenu").GetComponent<Button>();
        Debug.Log(backToMenu);
    }

    public void BackToMenu()
    {
        Debug.Log("Powrót do menu");
    }
}
