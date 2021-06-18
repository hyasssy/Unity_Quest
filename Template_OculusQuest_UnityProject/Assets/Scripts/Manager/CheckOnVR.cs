using UnityEngine;

public class CheckOnVR : MonoBehaviour {
    //VR上でのプレイかチェックし、シーン上の不要な方を削除する。
    public bool OnVR { get; private set; } = false;
    [SerializeField]
    GameObject[] VRObjs;
    [SerializeField]
    GameObject[] PCObjs;

    void Awake () {
        if (OVRManager.isHmdPresent) {
            OnVR = true;
        }
        Debug.Log("isOnVR? - " + OnVR);
        if (OnVR) {
            foreach (GameObject obj in PCObjs) {
                Destroy (obj);
            }
        } else {
            foreach (GameObject obj in VRObjs) {
                Destroy (obj);
            }
        }
    }
}