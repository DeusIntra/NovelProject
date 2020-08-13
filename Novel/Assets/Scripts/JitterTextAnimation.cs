using TMPro;
using UnityEngine;

public class JitterTextAnimation : MonoBehaviour
{
    public float jitterRange;
    private TMP_Text _textComponent;

    private void Awake()
    {
        _textComponent = GetComponent<TMP_Text>();
    }

    private void Update()
    {
        _textComponent.ForceMeshUpdate();
        TMP_TextInfo textInfo = _textComponent.textInfo;
        TMP_CharacterInfo charInfo = textInfo.characterInfo[0];
        int charMaterialIndex = charInfo.materialReferenceIndex;
        TMP_MeshInfo charMeshInfo = textInfo.meshInfo[charMaterialIndex];
        Vector3[] charVerts = charMeshInfo.vertices;

        float jitterX = Random.Range(0f, jitterRange) - jitterRange / 2;
        float jitterY = Random.Range(0f, jitterRange) - jitterRange / 2;

        for (int i = 0; i < 4; i++)
        {
            int firstVertexIndex = charInfo.vertexIndex;
            Vector3 original = charVerts[firstVertexIndex + i];
            charVerts[firstVertexIndex + i] = original + new Vector3(jitterX, jitterY, 0);
        }

        charMeshInfo.mesh.vertices = charMeshInfo.vertices;

        _textComponent.UpdateGeometry(charMeshInfo.mesh, 0);                
    }
}
