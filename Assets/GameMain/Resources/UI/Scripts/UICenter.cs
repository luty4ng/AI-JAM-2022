using UnityEngine;
using GameKit;
// 限制：不同种类的UIGroup同一时间只能拥有一个。有特殊需求的做成手拖式的就行。
public class UICenter : MonoSingletonBase<UICenter>
{
    private const string AssetPath = "UI/Prefabs/";
    public Transform UI_Instances;
    public T OpenUI<T>(string name) where T : UIGroup
    {
        Debug.Log(name);
        if (UIManager.instance.HasUI<T>(name))
        {
            T ui = UIManager.instance.GetUI<T>(name);
            ui.Show();
            ui.GetComponent<CanvasGroup>().interactable = true;
            return ui;
        }
        else
        {
            T ui = ResourceManager.instance.Load<T>(AssetPath + name);
            T uiInstance = Instantiate<T>(ui, Vector3.zero, Quaternion.identity, UI_Instances);
            uiInstance.gameObject.name = uiInstance.idName = name;
            uiInstance.OnInstantiate();
            return uiInstance;
        }
    }

    public UIGroup OpenUI(string name)
    {
        return OpenUI<UIGroup>(name);
    }

    public T CloseUI<T>(string name) where T : UIGroup
    {
        if (UIManager.instance.HasUI<T>(name))
        {
            UIManager.instance.HideUI<T>(name);
            UIManager.instance.GetUI<T>(name).GetComponent<CanvasGroup>().interactable = false;
            return UIManager.instance.GetUI<T>(name);
        }
        else
        {
            Debug.LogWarning("Try close un-opened ui.");
            return null;
        }
    }

    public void CloseUI(string name)
    {
        if (UIManager.instance.HasUI<UIGroup>(name))
        {
            UIManager.instance.HideUI<UIGroup>(name);
        }
        else
        {
            Debug.LogWarning("Try close un-opened ui.");
        }
    }

    public bool HasUI(string name) 
    {
        if (UIManager.instance.HasUI<UIGroup>(name))
        {
            return true;
        }
        return false;
    }

    public void GetUI()
    {
        UIManager.instance.GetUI<UIGroup>(name);
    }

    public T GetUI<T>(string name) where T : UIGroup
    {
        if (UIManager.instance.HasUI<T>(name))
        {          
            return UIManager.instance.GetUI<T>(name);
        }
        else
        {
            T ui = ResourceManager.instance.Load<T>(AssetPath + name);
            T uiInstance = Instantiate<T>(ui, Vector3.zero, Quaternion.identity, UI_Instances);
            uiInstance.gameObject.name = uiInstance.idName = name;
            uiInstance.OnInstantiate();
            return uiInstance;
        }
    }
    public T OpenOrCloseUI<T>(string name) where T : UIGroup
    {
        if (UIManager.instance.HasUI<T>(name))
        {
            T ui = UIManager.instance.GetUI<T>(name);
            ui.Show();
            ui.GetComponent<CanvasGroup>().interactable = true;
            return ui;
        }
        else
        {
            T ui = ResourceManager.instance.Load<T>(AssetPath + name);
            T uiInstance = Instantiate<T>(ui, Vector3.zero, Quaternion.identity, UI_Instances);
            uiInstance.gameObject.name = uiInstance.idName = name;
            uiInstance.OnInstantiate();
            return uiInstance;
        }
    }

}