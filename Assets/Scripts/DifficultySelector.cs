using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DifficultySelector : MonoBehaviour
{
    public DifficultySelectorEnum difficultySelector;
    Button btn;

    private void Awake()
    {
        btn = GetComponent<Button>();
        btn.onClick.AddListener(delegate { LoadDifficultyScene(difficultySelector); });
    }

    public enum DifficultySelectorEnum
    {
        Back = 0,
        Easy = 1,
        Normal = 2,
        Hard = 3,
        Test = 4
    }

    public void LoadDifficultyScene(DifficultySelectorEnum difficulty)
    {
        SceneManager.LoadScene((int)difficulty);
    }
}