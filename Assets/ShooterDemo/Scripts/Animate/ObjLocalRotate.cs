using DG.Tweening.Core;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;
using DG.Tweening.Plugins.Options;

public class ObjLocalRotate : MonoBehaviour, IAnimate
{
    [SerializeField] float x, y, z, duration;
    [Tooltip("-1 for infinity")]
    [SerializeField] private int loopCount = 0;
    [SerializeField] private bool snapping;
    [SerializeField] Ease ease = Ease.Linear;
    [SerializeField] LoopType loopType = LoopType.Restart;
    [SerializeField] UnityEvent tweenCallback = null;
    Transform objTransform;
    TweenerCore<Quaternion, Vector3, QuaternionOptions> tween;
    public void SetX(float val) => x = val;
    public void SetY(float val) => y = val;
    public void SetZ(float val) => z = val;
    public void SetDur(float val) => duration = val;
    public void Restart()
    {
        tween?.Restart();
    }
    public void Kill()
    {
        tween?.Kill();
        tween = null;
    }
    public void Pause()
    {
        tween?.Pause();
    }

    public void Play()
    {
        objTransform = transform;
        tween = objTransform
            .DOLocalRotate(new Vector3(x, y, z), duration)
            .SetLoops(loopCount,loopType)
            .SetEase(ease)
            .OnComplete(() => { tweenCallback?.Invoke(); }
            );
    }
    private void Start()
    {
        
    }
}
