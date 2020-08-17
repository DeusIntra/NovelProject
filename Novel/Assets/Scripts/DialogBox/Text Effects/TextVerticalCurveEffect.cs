using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Novella.Dialog;

public class TextVerticalCurveEffect : MonoBehaviour, ITextEffect
{
    
    public bool use = true;
    public string linkID = "curve";
    public float amplitude = 2f;
    public float speed = 0.02f;
    public float charDifference = 0.3f;
    public AnimationCurve curve;

    private TMP_Text _textComponent;
    private List<TMP_LinkInfo> _links;
    private Coroutine _coroutine;
    private TMP_MeshInfo[] _cachedMeshInfo;
    private float _time;

    public void Apply(TMP_Text textComponent)
    {
        if (!use) return;

        textComponent.ForceMeshUpdate();

        _textComponent = textComponent;
        _links = new List<TMP_LinkInfo>();
        TMP_TextInfo textInfo = textComponent.textInfo;

        for (int i = 0; i < textInfo.linkCount; i++)
        {
            if (textInfo.linkInfo[i].GetLinkID() == linkID)
            {
                _links.Add(textInfo.linkInfo[i]);
            }
        }

        if (_links.Count == 0) return;

        _cachedMeshInfo = textInfo.CopyMeshInfoVertexData();
        _time = 0f;

        _coroutine = StartCoroutine(AnimationCoroutine());
    }

    public void Terminate()
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
            // ResetVertices();
        }
    }

    private IEnumerator AnimationCoroutine()
    {
        TMP_TextInfo textInfo = _textComponent.textInfo;

        while (true)
        {
            _time += speed;

            foreach (TMP_LinkInfo linkInfo in _links)
            {
                int firstIndex = linkInfo.linkTextfirstCharacterIndex;
                int lastIndex = linkInfo.linkTextLength + firstIndex;

                for (int i = firstIndex; i < lastIndex; i++)
                {
                    TMP_CharacterInfo charInfo = textInfo.characterInfo[i];
                    if (!charInfo.isVisible) continue;

                    float curveY = curve.Evaluate(_time + i * charDifference) * amplitude;

                    int materialIndex = charInfo.materialReferenceIndex;
                    Vector3[] destinationVertices = textInfo.meshInfo[materialIndex].vertices;

                    int vertexIndex = charInfo.vertexIndex;

                    for (int j = 0; j < 4; j++)
                    {
                        Vector3 original = _cachedMeshInfo[materialIndex].vertices[vertexIndex + j];
                        destinationVertices[vertexIndex + j] = original + new Vector3(0, curveY, 0);
                    }
                }
                for (int i = 0; i < textInfo.meshInfo.Length; i++)
                {
                    var meshInfo = textInfo.meshInfo[i];
                    meshInfo.mesh.vertices = meshInfo.vertices;

                    _textComponent.UpdateGeometry(meshInfo.mesh, i);
                }
            }
            yield return new WaitForFixedUpdate();
        }
    }

    private void ResetVertices()
    {
        if (_cachedMeshInfo == null) return;

        TMP_TextInfo textInfo = _textComponent.textInfo;

        for (int i = 0; i < textInfo.characterCount; i++)
        {
            TMP_CharacterInfo charInfo = textInfo.characterInfo[i];

            int materialIndex = charInfo.materialReferenceIndex;
            Vector3[] destinationVertices = textInfo.meshInfo[materialIndex].vertices;

            int vertexIndex = charInfo.vertexIndex;

            for (int j = 0; j < 4; j++)
            {
                Vector3 original = _cachedMeshInfo[materialIndex].vertices[vertexIndex + j];
                destinationVertices[vertexIndex + j] = original;
            }
        }

        for (int i = 0; i < textInfo.meshInfo.Length; i++)
        {
            var meshInfo = textInfo.meshInfo[i];
            meshInfo.mesh.vertices = meshInfo.vertices;

            _textComponent.UpdateGeometry(meshInfo.mesh, i);
        }
    }
}
