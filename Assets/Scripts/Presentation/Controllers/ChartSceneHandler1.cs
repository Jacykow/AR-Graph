using UnityEngine;
using UnityEngine.SceneManagement;
public class BackToMenuHandler : MonoBehaviour
{
    public void Start()
    {
        var graphTest = new GraphTest();
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("CameraScene", LoadSceneMode.Single);
    }

    public void ChangeChartView(int arg)
    {
        switch (arg)
        {
            case 0:
                Debug.Log("Wybrano: AR - dowolne miejsce");
                break;
            case 1:
                Debug.Log("Wybrono: AR - kartka");
                break;
            case 2:
                Debug.Log("Wybrano: Przestrzeń 3D");
                break;
        }
    }
}
