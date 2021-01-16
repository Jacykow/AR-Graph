using UnityEngine;

public abstract class AxisRenderer : MonoBehaviour
{
    public abstract void Redraw(IAxisProperties properties);
    public abstract void Hide();
}
