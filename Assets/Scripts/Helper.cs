using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Helper : MonoBehaviour
{
    public Button playButton;
    public Button clearOnePath, clearAllPath;

    [SerializeField] private GameObject IFObject;
    [SerializeField] private GameObject IFClearOneObject;
    [SerializeField] private GameObject IFClearAllObject;

    void Start()
    {
        playButton.onClick.AddListener(ScoreManager.Instance.SubmitPlayer);
        ScoreManager.Instance.inputField = IFObject.GetComponent<TMP_InputField>();

        clearAllPath.onClick.AddListener(ScoreManager.Instance.ClearAllPath);
        ScoreManager.Instance.clearAllInputField = IFClearAllObject.GetComponent<TMP_InputField>();

        clearOnePath.onClick.AddListener(ScoreManager.Instance.ClearOnePath);
        ScoreManager.Instance.clearOneInputField = IFClearOneObject.GetComponent<TMP_InputField>();
    }
}