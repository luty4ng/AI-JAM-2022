using UnityEngine;

public class UIExample_Tester : MonoBehaviour
{
    UIExample_Panel m_CachedUIExample;
    MenuUI menuUI;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            m_CachedUIExample = UICenter.current.OpenUI<UIExample_Panel>("ExampleUI");
            menuUI = UICenter.current.OpenUI<MenuUI>("MenuUI");
        }

        // m_CachedUIExample... 其他操作
        if (Input.GetKeyDown(KeyCode.X))
        {
            if(m_CachedUIExample!=null)
            {
                UICenter.current.CloseUI<UIExample_Panel>(m_CachedUIExample.idName);
            }
        }

       if (Input.GetKeyDown(KeyCode.S))
       {
           
           if (!m_CachedUIExample.IsActive)
           {
     
                m_CachedUIExample = UICenter.current.OpenUI<UIExample_Panel>("ExampleUI");              
           }
           else
           {
               UICenter.current.CloseUI<UIExample_Panel>(m_CachedUIExample.idName);
           }
       }

    }
}