using UnityEngine;

public class NetworkingExample : MonoBehaviour
{
    private void Start()
    {
        new UnityWebRequest
        {
            url = "https://www.google.pl/",
            method = "GET"
        }.ObserveRequestResult().Subscribe(text =>
        {
            Debug.Log(text);
        }).AddTo(this);
    }

    private void ExampleGET()
    {
        DataManager.Main.GraphDataUrlProperty.Value = "https://argraph.azurewebsites.net/graph/1";
    }

    private void ExamplePOST()
    {
        DataManager.Main.SendGraph("\"id\" : 1, \"data\" : \"przykladowe dane do grafu\"");
    }

    private void ExampleDELETE()
    {
        DataManager.Main.DeleteGraph("https://argraph.azurewebsites.net/graph/1");
    }
}
