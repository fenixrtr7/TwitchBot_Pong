using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GetName : MonoBehaviour
{
    [SerializeField] GameObject nameObj;
    TextMeshProUGUI textMP;
    private void Awake()
    {
        textMP = GetComponent<TextMeshProUGUI>();
    }
    // Start is called before the first frame update
    void Start()
    {
        textMP.text = nameObj.name.ToString();

        //StartCoroutine(IniNameObj());
    }

    IEnumerator IniNameObj()
    {
        yield return new WaitForSeconds(3f);
        Debug.Log("name: " + nameObj.name);
        
    }
    private void Update()
    {
        //Debug.Log("name: " + nameObj.name);
    }
}
