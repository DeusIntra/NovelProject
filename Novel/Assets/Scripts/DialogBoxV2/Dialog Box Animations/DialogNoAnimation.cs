using UnityEngine;

public class DialogNoAnimation : MonoBehaviour, IDialogBoxAnimation
{
    public bool isAnimating()
    {
        return false;
    }

    public void Open(GameObject gameObject)
    {
        gameObject.SetActive(true);
    }

    public void Close(GameObject gameObject)
    {
        gameObject.SetActive(false);
    }
}
