using UnityEngine;

public class SayHello : MonoBehaviour
{
    public void Hello()
    {
        Debug.Log("Dialog has ended");
    }

    public void Yes()
    {
        Debug.Log("Yes");
    }

    public void No()
    {
        Debug.Log("No");
    }

    public void Quit()
    {
        Application.Quit();
    }

}
