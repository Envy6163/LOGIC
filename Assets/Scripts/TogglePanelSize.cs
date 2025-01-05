using UnityEngine;
using UnityEngine.UI;
using TMPro; // ���ʹ�� TextMeshPro

public class TogglePanelSize : MonoBehaviour
{
    // ԭʼ��С
    private Vector2 originalSize;
    // ��չ��Ĵ�С
    private Vector2 expandedSize;
    // ��ǰ״̬
    private bool isExpanded = false;
    // ��ť
    public Button toggleButton;
    // ��¼RectTransform
    private RectTransform rectTransform;
    // ����ʱ�䣨��ѡ��
    public float animationDuration = 0.2f;
    // ��ǰ��������
    private float currentTime = 0f;
    // Ŀ���С
    private Vector2 targetSize;
    // �Ƿ����ڶ���
    private bool isAnimating = false;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        originalSize = rectTransform.sizeDelta;
        expandedSize = new Vector2(originalSize.x * 2f, originalSize.y); // �������չΪ����

        if (toggleButton != null)
        {
            toggleButton.onClick.AddListener(ToggleSize);
        }
    }

    void Update()
    {
        if (isAnimating)
        {
            currentTime += Time.deltaTime;
            float t = Mathf.Clamp01(currentTime / animationDuration);
            rectTransform.sizeDelta = Vector2.Lerp(rectTransform.sizeDelta, targetSize, t);

            if (t >= 1f)
            {
                isAnimating = false;
                rectTransform.sizeDelta = targetSize;
            }
        }
    }

    public void ToggleSize()
    {
        if (isAnimating) return; // ��ֹ�ظ����

        isExpanded = !isExpanded;
        targetSize = isExpanded ? expandedSize : originalSize;
        currentTime = 0f;
        isAnimating = true;

        // ��ѡ����ת��ť��������
        // ���谴ť����һ��Image��Ϊ������
        Image triangle = toggleButton.GetComponentInChildren<Image>();
        if (triangle != null)
        {
            // ��ת90�Ȼ�-90�ȣ�������չ״̬
            triangle.transform.rotation = isExpanded ? Quaternion.Euler(0, 0, 90) : Quaternion.Euler(0, 0, 0);
        }
    }
}
