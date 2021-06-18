using UnityEngine;

public class QuestSetting : MonoBehaviour
{
    [SerializeField]
    float _frameRate = 72f;
    
    private void Start() {
        if(!FindObjectOfType<CheckOnVR>().OnVR){
            this.enabled = false;
            return;
        }
        OVRManager.fixedFoveatedRenderingLevel = OVRManager.FixedFoveatedRenderingLevel.Medium;
        float[] availableFrameRates = OVRManager.display.displayFrequenciesAvailable;
        foreach(float f in availableFrameRates){
            Debug.Log("AvailableFrameRate = " + f);
        }
        OVRManager.display.displayFrequency = _frameRate;
    }
}
