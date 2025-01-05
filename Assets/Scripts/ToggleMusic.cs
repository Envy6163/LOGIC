using UnityEngine;
using UnityEngine.UI;  // ����UI�����ռ��Ա�ʹ��Image��Button

public class ToggleMusic : MonoBehaviour
{
    public AudioSource audioSource;  // ���ֲ���Դ
    public Image buttonImage;        // ��ť��Image���
    public Sprite playIcon;          // ����ͼ��
    public Sprite pauseIcon;         // ��ͣͼ��

    private bool isMusicPlaying = true;  // ��ǰ���ֲ���״̬

    // �ڰ�ť���ʱ����
    public void ToggleAudio()
    {
        if (isMusicPlaying)
        {
            // ����������ڲ��ţ�����ͣ����
            audioSource.Pause();
            buttonImage.sprite = playIcon;  // ����Ϊ����ͼ��
        }
        else
        {
            // �������û�в��ţ��򲥷�����
            audioSource.Play();
            buttonImage.sprite = pauseIcon;  // ����Ϊ��ͣͼ��
        }

        // �л�����״̬
        isMusicPlaying = !isMusicPlaying;
    }
}
