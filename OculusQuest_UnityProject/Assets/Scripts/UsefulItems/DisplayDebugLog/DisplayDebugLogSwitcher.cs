using UnityEngine;
using UniRx;
using UniRx.Triggers;

public class DisplayDebugLogSwitcher : MonoBehaviour
{
    [SerializeField, Tooltip("このキーを3秒長押しすると表示非表示切り替える")]
    private KeyCode displayLogSwitchKey = KeyCode.C;//default : C of Console
    [SerializeField, Tooltip("Questでのキー")]
    GameObject debugLogPanel;

    private void Start() {
        bool isOnVR = FindObjectOfType<CheckOnVR>().OnVR;
        if(isOnVR){
            this.UpdateAsObservable()
            .Where(_ => OVRInput.Get(OVRInput.Button.One) && OVRInput.Get(OVRInput.Button.Two))//one,two抑えている間にサムスティック
            .Where(_ => OVRInput.GetDown(OVRInput.Button.PrimaryThumbstick) || OVRInput.GetDown(OVRInput.Button.SecondaryThumbstick))
            .Subscribe(_ => DisplayLogPanel());
        }else{
            this.UpdateAsObservable()
            .Where(_ => Input.GetKeyDown(displayLogSwitchKey))
            .Subscribe(_ => DisplayLogPanel());
        }
    }

    private void DisplayLogPanel(){
        Debug.Log("push");
        debugLogPanel.SetActive(!debugLogPanel.activeSelf);
            if(debugLogPanel.activeSelf) Debug.Log("Activate Debug Log Panel");
    }
}
