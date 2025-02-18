using UnityEngine;

public class SlidePositionAnimator : MonoBehaviour
{
    public Vector3 SlideAxis;
    [Tooltip("Exp Decay constant. 1-25ish will get you from slow to fast.")]
    [Min(0)]
    public float Decay = 16;
    [SerializeField] private int _position;
    
    public void SetPosition(int value)
    {
        _position = value;
    }

    private void Update()
    {
        Vector3 desiredLocalPosition = SlideAxis * _position;
        transform.localPosition = ExponentialDecay(transform.localPosition,desiredLocalPosition,16,Time.deltaTime);
    }

    //why?: https://www.youtube.com/watch?v=LSNQuFEDOyQ
    float ExponentialDecay(float a, float b, float decay, float deltaTime)
    {
        return b+(a-b)*Mathf.Exp(-decay*deltaTime);
    }

    Vector3 ExponentialDecay(Vector3 a, Vector3 b, float decay, float deltaTime)
    {
        return new Vector3(ExponentialDecay(a.x,b.x,decay,deltaTime),ExponentialDecay(a.y, b.y,decay,deltaTime),ExponentialDecay(a.z, b.z,decay,deltaTime));
    }
}
