using UnityEngine;

public class CurveTest : MonoBehaviour
{

    public Transform target1;
    public Transform target2;

    public AnimationCurve curve;

    public float amplitute = 1f;
    public float speed = 1f;

    private float _timer = 0f;

    private void Update()
    {
        _timer += Time.deltaTime * speed;

        float x = Mathf.Lerp(target1.position.x, target2.position.x, curve.Evaluate(_timer) / 2 + 0.5f);

        transform.position = new Vector3(x * amplitute, transform.position.y, transform.position.z);
    }
}
