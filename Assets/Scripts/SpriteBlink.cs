using System.Collections;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class SpriteBlink : MonoBehaviour
{
    [SerializeField] private float _blinkTime = 1.0f;
    [SerializeField] private float _blinkRate = 0.1f;

    private SpriteRenderer _spriteRenderer;
    private bool _isBlinking = false;

    void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnEnable()
    {
        StartBlinking();
    }

    public void StartBlinking()
    {
        if (_isBlinking) return;
        StartCoroutine(Blink());

        enabled = false;
    }

    private IEnumerator Blink()
    {
        _isBlinking = true;
        float endTime = Time.time + _blinkTime;

        while (Time.time < endTime)
        {
            _spriteRenderer.enabled = !_spriteRenderer.enabled;
            yield return new WaitForSeconds(_blinkRate);
        }

        _spriteRenderer.enabled = true;
        _isBlinking = false;

        //
        //gameObject.SetActive(false);
    }
}
