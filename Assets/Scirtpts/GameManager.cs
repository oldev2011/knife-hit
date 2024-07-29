using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public TMP_Text KnifesLeft;
    public int KnifeCount;
    public TMP_Text EndScreenText;
    public GameObject EndScreen;
    public Button RetryButton;
    public Button LinkButton;
    
    private string _linkDima = "https://www.youtube.com/watch?v=dQw4w9WgXcQ&list=PL8dZXjD8meS_WZzEKSReIBPLzKaW3HboH&index=1&ab_channel=RickAstley";

    private List<GameObject> _spawnedKnives = new List<GameObject>();

    private void Start()
    {
        KnifesLeft.text = KnifeCount.ToString();
        RetryButton.onClick.AddListener(RetryGame);
        EndScreen.SetActive(false);
        LinkButton.onClick.AddListener(OpenURL);
    }
    private void RetryGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    private void Update()
    {
        KnifesLeft.text = "Осталось ножей: X" + KnifeCount.ToString();
        if (KnifeCount == 0)
        {
            EndScreen.SetActive(true);
        }
;
    }
    public void OnKnifeThrown(GameObject knifeToSet)
    {
        if (KnifeCount > 0)
        {
            _spawnedKnives.Add(knifeToSet);
            KnifeCount--;
            KnifesLeft.text = "Осталось ножей: X" + KnifeCount.ToString();
        }
        else
        {
            Destroy(knifeToSet);
        }
    }
    private void OpenURL() 
    {
        Application.OpenURL(_linkDima);
    }
}
