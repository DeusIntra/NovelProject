using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Novella.Dialog;

public class TextJitterEffect : MonoBehaviour, ITextEffect
{
    public bool use = true;
    public float jitterRange = 2.5f;

    private TMP_Text _text;
    private TMP_TextInfo _textInfo;
    private TMP_CharacterInfo[] _charInfo;
    private List<TMP_LinkInfo> _links;
    private Coroutine _coroutine;
    private TMP_MeshInfo[] _cachedMeshInfo;

    public void Apply(TMP_Text text)
    {
        if (!use) return;

        _text = text;
        _textInfo = text.textInfo;
        _charInfo = _textInfo.characterInfo;
        _links = new List<TMP_LinkInfo>();
        TMP_LinkInfo[] links = _textInfo.linkInfo;

        if (links.Length == 0) return;

        for (int i = 0; i < links.Length; i++)
        {
            if (links[i].GetLinkID() == "jitter")
            {
                _links.Add(links[i]);
            }
        }

        if (_links.Count == 0) return;

        _cachedMeshInfo = _textInfo.CopyMeshInfoVertexData();

        _coroutine = StartCoroutine(AnimationCoroutine());
    }

    public void Terminate()
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
            ResetVertices();
        }
    }

    private IEnumerator AnimationCoroutine()
    {
        while (true)
        {
            foreach (TMP_LinkInfo linkInfo in _links)
            {
                int firstIndex = linkInfo.linkTextfirstCharacterIndex;
                int lastIndex = linkInfo.linkTextLength + firstIndex;

                for (int i = firstIndex; i < lastIndex; i++)
                {
                    if (!_charInfo[i].isVisible) continue;

                    float jitterX = Random.Range(0f, jitterRange) - jitterRange / 2;
                    float jitterY = Random.Range(0f, jitterRange) - jitterRange / 2;

                    int charMaterialIndex = _charInfo[i].materialReferenceIndex;
                    TMP_MeshInfo meshInfo = _textInfo.meshInfo[charMaterialIndex];
                    Vector3[] charVerts = meshInfo.vertices;

                    int vertexIndex = _charInfo[i].vertexIndex;
                    for (int j = 0; j < 4; j++)
                    {
                        Vector3 original = _cachedMeshInfo[charMaterialIndex].vertices[vertexIndex + j];
                        charVerts[vertexIndex + j] = original + new Vector3(jitterX, jitterY, 0);
                    }
                }
                for (int i = 0; i < _textInfo.meshInfo.Length; i++)
                {
                    var meshInfo = _textInfo.meshInfo[i];
                    meshInfo.mesh.vertices = meshInfo.vertices;

                    _text.UpdateGeometry(meshInfo.mesh, i);
                }
            }
            yield return null;
        }
    }

    private void ResetVertices()
    {
        for (int i = 0; i < _textInfo.characterCount; i++)
        {
            int charMaterialIndex = _charInfo[i].materialReferenceIndex;
            TMP_MeshInfo meshInfo = _textInfo.meshInfo[charMaterialIndex];
            Vector3[] charVerts = meshInfo.vertices;
            int vertexIndex = _charInfo[i].vertexIndex;
            for (int j = 0; j < 4; j++)
            {
                Vector3 original = _cachedMeshInfo[charMaterialIndex].vertices[vertexIndex + j];
                charVerts[vertexIndex + j] = original;
            }
        }

        for (int i = 0; i < _textInfo.meshInfo.Length; i++)
        {
            var meshInfo = _textInfo.meshInfo[i];
            meshInfo.mesh.vertices = meshInfo.vertices;

            _text.UpdateGeometry(meshInfo.mesh, i);
        }
    }
}
