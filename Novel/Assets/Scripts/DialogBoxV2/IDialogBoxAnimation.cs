using UnityEngine;

public interface IDialogBoxAnimation
{
    bool isAnimating();
    void Open(GameObject gameObject);
    void Close(GameObject gameObject);
}
