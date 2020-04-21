using System.Collections;
using System.Collections.Generic;
using Bestiary;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class _queueController : MonoBehaviour
{
    [SerializeField] private Transform underDoor;
    [SerializeField] private Transform Exit;
    [SerializeField] private Animation door;
    [SerializeField] private GameObject ourPeople;
    
    void Start()
    {
        PlayerPrefs.SetInt("Supreme", 1);
        InfoAboutIlnesses info = new InfoAboutIlnesses();
        int numOfSymptoms = info.getSymptoms()[ourPeople.GetComponent<_PeopleIssues>()._issueName].Count;

        if (PlayerPrefs.GetInt("Supreme") == 1 && numOfSymptoms > 1)
        {
            GetComponent<Image>().color = Color.red;
        }
    }
    
    public void GoodBye()
    {
        transform.DOMove(underDoor.position, 2f).OnComplete(() =>
        {
            door.Play();
            Invoke(nameof(RealyGoodBye), 1.5f);
        });
    }

    private void RealyGoodBye()
    {
        transform.DOMove(Exit.position, 2f).OnComplete(() =>
        {
           // Destroy(gameObject);
        });
    }
}
