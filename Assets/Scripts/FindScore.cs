using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FindScore : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textMesh;
    
    [SerializeField] private int index;
    
    [SerializeField] private GameObject inputFieldObj;

    public void ShowText()
    {
        var playersList = ScoreManager.Instance.highScores;

        textMesh.text = $"{playersList[index].playerName} --- {playersList[index].score}";    
    }

    public void SetText()
    {
        var playersList = ScoreManager.Instance.highScores;
        
        inputFieldObj.GetComponent<TMP_InputField>().text = playersList[index].playerName; 
    }
}
