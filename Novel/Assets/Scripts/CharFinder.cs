using TMPro;
using UnityEngine;

public class CharFinder : MonoBehaviour
{
    public TMP_Text text;

    [ContextMenu("info")]
    private void Info ()
    {
        TMP_TextInfo textInfo = text.textInfo;

        TMP_LinkInfo[] linkInfo = textInfo.linkInfo;

        foreach (TMP_LinkInfo info in linkInfo)
        {
            Debug.Log(info.linkTextfirstCharacterIndex);
        }
        
    }
}
