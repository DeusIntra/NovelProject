using TMPro;
using UnityEngine;

public class JitterTextAnimation : MonoBehaviour
{
    public bool apply;
    public float jitterRange;
    public TMP_Text _textComponent;

    private void Awake()
    {
        //_textComponent = GetComponent<TMP_Text>();
    }

    private void Update()
    {
        if (apply)
        {
            for (int i = 0; i < _textComponent.textInfo.characterCount; i++)
            {
                _textComponent.ForceMeshUpdate();
                TMP_TextInfo textInfo = _textComponent.textInfo;
                TMP_CharacterInfo charInfo = textInfo.characterInfo[i];
                int charMaterialIndex = charInfo.materialReferenceIndex;
                TMP_MeshInfo charMeshInfo = textInfo.meshInfo[charMaterialIndex];
                Vector3[] charVerts = charMeshInfo.vertices;

                float jitterX = Random.Range(0f, jitterRange) - jitterRange / 2;
                float jitterY = Random.Range(0f, jitterRange) - jitterRange / 2;

                for (int j = 0; j < 4; j++)
                {
                    int firstVertexIndex = charInfo.vertexIndex;
                    Vector3 original = charVerts[firstVertexIndex + j];
                    charVerts[firstVertexIndex + j] = original + new Vector3(jitterX, jitterY, 0);
                }
            }

            for (int i = 0; i < _textComponent.textInfo.meshInfo.Length; i++)
            {
                _textComponent.textInfo.meshInfo[i].mesh.vertices = _textComponent.textInfo.meshInfo[i].vertices;
                _textComponent.UpdateGeometry(_textComponent.textInfo.meshInfo[i].mesh, i);
            }
        }
    }
}
