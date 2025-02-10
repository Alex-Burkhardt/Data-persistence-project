using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class Helper : MonoBehaviour
{
    
    public Button playButton;
    public Button clearAllPath;
    public Button clearOnePath;

    [SerializeField] private GameObject IFObject;
    [SerializeField] private GameObject IFClearOneObject;
    [SerializeField] private GameObject IFClearAllObject;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playButton.onClick.AddListener(ScoreManager.Instance.SubmitPlayer);
        ScoreManager.Instance.inputField = IFObject.GetComponent<TMP_InputField>();

        clearAllPath.onClick.AddListener(ScoreManager.Instance.ClearAllPath);
        ScoreManager.Instance.clearAllInputField = IFClearAllObject.GetComponent<TMP_InputField>();

        clearOnePath.onClick.AddListener(ScoreManager.Instance.ClearOnePath);
        ScoreManager.Instance.clearOneInputField = IFClearOneObject.GetComponent<TMP_InputField>();
    }

    // Update is called once per frame
    void Update()
    {
        print(ScoreManager.Instance.inputField.text);
        Debug.LogError(ScoreManager.Instance.clearAllInputField.text);
        Debug.LogWarning(ScoreManager.Instance.clearOneInputField.text);
    }
}
