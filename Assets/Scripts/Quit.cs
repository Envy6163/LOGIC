using UnityEngine;

public class ExitGame : MonoBehaviour
{
    // �˳���Ϸ�ĺ���
    public void ExitApplication()
    {
        // ����������ڱ༭���У�ֹͣ����
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;  // �ڱ༭����ֹͣ��Ϸ
#else
        // �����˳�Ӧ�ó���
        Application.Quit();  // �ڹ����汾���˳���Ϸ
#endif
    }
}
