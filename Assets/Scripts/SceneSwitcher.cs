using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    public void SwitchScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

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
