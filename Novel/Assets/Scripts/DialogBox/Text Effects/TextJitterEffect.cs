using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using TMPro;
using UnityEngine;

public class TextJitterEffect : MonoBehaviour, ITextEffect
{
    public bool use = true;
    public float jitterRange = 5;

    private TMP_Text _text;
    private TMP_TextInfo _textInfo;
    private TMP_CharacterInfo[] _charInfo;
    private List<TMP_LinkInfo> _links;
    private Coroutine _coroutine;
    private Vector3[][] _originalVertices;
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

                    // everything up to this point works fine
                    // how tf do i make this work

                    int charMaterialIndex = _charInfo[i].materialReferenceIndex;
                    TMP_MeshInfo meshInfo = _textInfo.meshInfo[charMaterialIndex];
                    Vector3[] charVerts = meshInfo.vertices;

                    int firstVertexIndex = _charInfo[i].vertexIndex;
                    for (int j = 0; j < 4; j++)
                    {
                        Vector3 original = _originalVertices[i][j];
                        charVerts[firstVertexIndex + j] = original + new Vector3(jitterX, jitterY, 0);
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


        //TMP_CharacterInfo[] charInfo = _textInfo.characterInfo;

        //foreach (TMP_LinkInfo linkInfo in _links)
        //{
        //    int firstIndex = linkInfo.linkTextfirstCharacterIndex;
        //    int lastIndex = linkInfo.linkTextLength + firstIndex;

        //    for (int i = firstIndex; i < lastIndex; i++)
        //    {
        //        int charMaterialIndex = charInfo[i].materialReferenceIndex;
        //        TMP_MeshInfo charMeshInfo = _textInfo.meshInfo[charMaterialIndex];
        //        Vector3[] charVerts = charMeshInfo.vertices;

        //        //for (int j = 0; j < 4; j++)
        //        //{
        //        //    int firstVertexIndex = charInfo[i].vertexIndex;
        //        //    Vector3 original = charVerts[firstVertexIndex + j];
        //        //    charVerts[firstVertexIndex + j] = original;
        //        //}
        //        charMeshInfo.mesh.vertices = charVerts; //charMeshInfo.vertices;

        //        _text.UpdateGeometry(charMeshInfo.mesh, i);
        //    }
        //}
    }
}
