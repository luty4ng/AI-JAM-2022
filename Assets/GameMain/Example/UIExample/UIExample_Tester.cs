using UnityEngine;

public class UIExample_Tester : MonoBehaviour
{
    UIExample_Panel m_CachedUIExample = null;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            m_CachedUIExample = UICenter.current.OpenUI<UIExample_Panel>("ExampleUI");
        }

        // m_CachedUIExample... 其他操作
        if (Input.GetKeyDown(KeyCode.X))
        {
            if(m_CachedUIExample!=null)
            {
                UICenter.current.CloseUI<UIExample_Panel>(m_CachedUIExample.idName);
            }
        }

    }
}