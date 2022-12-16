using UnityEngine;
using GameKit;
using UnityEngine.UI;

public class DialogExample : MonoBehaviour
{
    public DialogAsset dialogAsset;
    public GameObject Hint;


    void Update()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            Hint.SetActive(false);
            DialogSystem.current.StartDialog(dialogAsset.title, dialogAsset.contents);

            
        }

        
    }
}