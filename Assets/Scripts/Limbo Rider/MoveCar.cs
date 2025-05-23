using UnityEngine;
using DG.Tweening;

public class MOveCar : MonoBehaviour
{
    public Transform model;          // Assign the model in the Inspector
    public float duration = 1f;      // Duration of the animation
    public Transform previoustransform;

    void Start()
    {

    }

    public void MoveCarAnim()
    {
        if (model == null)
        {
            Debug.LogError("Model is not assigned!");
            return;
        }

        Vector3 targetScale = new Vector3(0.01f, 0.01f, 0.01f);
        float targetY = 120f;

        // Create a DOTween sequence
        Sequence animationSequence = DOTween.Sequence();

        // Add scale and move animations to play at the same time
        animationSequence.Join(model.DOScale(targetScale, duration).SetEase(Ease.OutQuad));
        animationSequence.Join(model.DOLocalMoveY(targetY, duration).SetEase(Ease.OutQuad));

        // Optional: Do something when animation completes
        animationSequence.OnComplete(() =>
        {
            Debug.Log("Animation complete!");
            ResetCar();
        });
    }

    public void ResetCar()
    {
        model.transform.localPosition = new Vector3(0, -140, 0);
        model.transform.localScale = new Vector3(1, 1, 1);
    }
}
