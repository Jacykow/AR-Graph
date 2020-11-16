using UniRx;
using UnityEngine;

public class Example : MonoBehaviour
{
    public float interval;

    private float timeElapsed;

    private void Awake()
    {
        timeElapsed = 0f;
    }

    private void Start()
    {
        DataManager.Main.GraphDataProperty.Subscribe(data =>
        {
            Debug.Log(data?.Name);
        }).AddTo(this);
    }

    private void Update()
    {
        timeElapsed += Time.deltaTime;
        if (timeElapsed >= interval)
        {
            timeElapsed = 0f;
            var data = new ExampleGraphData
            {
                Name = Time.time.ToString()
            };
            DataManager.Main.GraphDataProperty.Value = data;
        }
    }
}
