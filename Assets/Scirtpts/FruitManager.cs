using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FruitManager : MonoBehaviour
{
    private int _fruitsDestroyed;
    private int _totalFruits;

    private void Start()
    {
        _totalFruits = GameObject.FindGameObjectsWithTag("Fruit").Length;
        _fruitsDestroyed = 0;
    }
    public void FruitsDestroyed() 
    {
        _fruitsDestroyed++;
        if (_fruitsDestroyed == _totalFruits) 
        {
            Debug.Log("Фрукты закончились");
            StartCoroutine(WaitForLoadNextLevel());
        }
    }
    private IEnumerator WaitForLoadNextLevel() 
    {
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene(1);
    }
}
