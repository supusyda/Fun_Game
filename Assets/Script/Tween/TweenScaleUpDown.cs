using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class TweenScaleUpDown : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float dur = 0;
    [SerializeField] int vib = 0;
    [SerializeField] float scale = 0.2f;


    void Start()
    {
        // var sequence = DOTween.Sequence()
        //           .Append(transform.DOLocalRotate(new Vector3(0, 0, 360), 10, RotateMode.FastBeyond360).SetRelative())
        //        .Join(transform.DOPunchScale(new Vector3(0.5f, 0.5f, 0.5f), dur, vib, .5f));
        // sequence.SetLoops(-1, LoopType.Yoyo);
        Vector3 OriginalScale = transform.localScale;
        var sequence = DOTween.Sequence()
          .Append(transform.DOScale(new Vector3(OriginalScale.x + scale, OriginalScale.y + scale, OriginalScale.z + scale), dur).SetEase(Ease.Linear))
          .Append(transform.DOScale(OriginalScale, dur).SetEase(Ease.Linear));
        sequence.SetLoops(-1, LoopType.Yoyo);
    }


    // Update is called once per frame
    void Update()
    {

    }
}
