using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;

public class PopUp : MonoBehaviour
{ 
    private Queue<GameObject> popUpQueue = new ();
    [SerializeField] private GameObject popUp;
    private GameObject popUpObject;
    private GameObject popUpActiveObject;
    private int numberOfPopUp = 3;
    [SerializeField] private GameObject canvasPopUp;
    
    public void Start()
    {
        for (int i = 0; i < numberOfPopUp; i++)
        {
            popUpObject = Instantiate(popUp, transform.position, Quaternion.identity);
            popUpObject.SetActive(false);
            popUpObject.transform.SetParent(transform);
            var button = popUpObject.transform.GetChild(1);
            button.GetComponent<Button>().onClick.AddListener(DeletePopUp);
            popUpQueue.Enqueue(popUpObject);
        }
        ActivatePopUp();
    }

    private void ActivatePopUp()
    {
        popUpActiveObject = popUpQueue.Dequeue();
        popUpActiveObject.SetActive(true);
    }

    public void DeletePopUp()
    {
        Destroy(popUpActiveObject);
        if (popUpQueue.Count != 0)
        {
            ActivatePopUp();
        }
    }
    
}
