using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using DG.Tweening;

public class FlyInAnim : MonoBehaviour
{
    [SerializeField] private RectTransform _targetRectTransform;
    [SerializeField] private float _endScale = 1f;
    [SerializeField] private float _endPositionx = 0f;
    // public GameObject _logo;

    private Sequence _sequence;

    public void StartAnim()
    {
        // _logo.SetActive(true);
        _targetRectTransform
            .DOLocalMoveX(endValue: _endPositionx, duration: 2f, snapping: false)
            .OnComplete(() =>
        {
            _targetRectTransform
            .DOScale(endValue: _endScale, duration: 3f);
        });
    }

    public void StopEnterLogos()
    {
        _sequence = DOTween
                        .Sequence()
                        .SetAutoKill(false);
    }
    public void Reset()
    {
         _targetRectTransform
            .DOScale(endValue: 0.001f, duration: 0.1f);
    }

}
