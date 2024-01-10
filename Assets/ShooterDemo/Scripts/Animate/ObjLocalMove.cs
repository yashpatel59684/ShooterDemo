using DG.Tweening;
using DG.Tweening.Core;
using UnityEngine;
using UnityEngine.Events;

public class ObjLocalMove : MonoBehaviour, IAnimate
{
    [SerializeField] Vector3 pos = Vector2.zero;
    [SerializeField] private float duration = .5f;
    [Tooltip("-1 for infinity")]
    [SerializeField] private int loopCount = 0;
    [SerializeField] private bool snapping;
    [SerializeField] Ease ease = Ease.Linear;
    [SerializeField] LoopType loopType = LoopType.Restart;
    [SerializeField] UnityEvent tweenCallback = null;
    Transform objTransform;
    TweenerCore<Vector3, Vector3, DG.Tweening.Plugins.Options.VectorOptions> tween;

    public void SetX(float val) => pos.x = val;
    public void SetY(float val) => pos.y = val;
    public void SetZ(float val) => pos.z = val;
    public void SetDur(float val) => duration = val;
    public void Restart()
    {
       tween?.Restart();
    }
    public void Kill()
    {
        tween?.Kill();
        tween=null;
    }
    public void Pause()
    {
       tween?.Pause();
    }

    public void Play()
    {
        objTransform = transform;
        if(tween==null) tween = objTransform
            .DOLocalMove(new Vector3(objTransform.localPosition.x + pos.x, objTransform.localPosition.y + pos.y, objTransform.localPosition.z + pos.z), duration, snapping)
            .SetLoops(loopCount, loopType)
            .SetEase(ease)
            .OnComplete(() => { tweenCallback?.Invoke(); }
            );
    }
    private void Start()
    {
        
    }
}
