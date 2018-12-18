using UnityEngine;
using DG.Tweening;
using System;

public class PortalRender : MonoBehaviour {

    [SerializeField] Ease ease;
    [SerializeField] float transitionSpeed;
    [SerializeField] float minSize;
    [SerializeField] float peakSize;
    [SerializeField] float maxSize;

    Sequence seq;
    
    public void PeakPortal(Action onComplete)
    {
        seq.Append(transform.DOScale(peakSize * Vector3.one, transitionSpeed).SetEase(ease).OnComplete(() =>
        {
            onComplete();
        }));
    }

    public void CancelPeakPortal(Action onComplete)
    {
        seq.Append(transform.DOScale(minSize * Vector3.one, transitionSpeed).SetEase(ease).OnComplete(() =>
        {
            onComplete();
        }));
    }

    public void OpenPortal(Action onComplete)
    {
        seq.Append(transform.DOScale(maxSize * Vector3.one, transitionSpeed).OnComplete(() =>
        {
            onComplete();
        }));
    }

    public void OnTeleportComplete(Action onComplete)
    {
        seq.Kill();
        transform.localScale = Vector3.zero;
        onComplete();
    }

}
