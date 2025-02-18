using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Helper : MonoBehaviour
{
    public Button clearOnePath, clearAllPath, playButton;

    [SerializeField] public GameObject IFObject;
    [SerializeField] public GameObject IFClearOneObject;
    [SerializeField] public GameObject IFClearAllObject;

    void Start()
    {
        ScoreManager.Instance.inputField = IFObject.GetComponent<TMP_InputField>();
        ScoreManager.Instance.clearAllInputField = IFClearAllObject.GetComponent<TMP_InputField>();
        ScoreManager.Instance.clearOneInputField = IFClearOneObject.GetComponent<TMP_InputField>();
    
        playButton.onClick.AddListener(ScoreManager.Instance.SubmitPlayer);
        clearAllPath.onClick.AddListener(ScoreManager.Instance.ClearAllPath);
        clearOnePath.onClick.AddListener(ScoreManager.Instance.ClearOnePath);

    }
}