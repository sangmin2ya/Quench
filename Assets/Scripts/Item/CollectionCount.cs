using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CollectionCount : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void ExitGame()
    {
        Application.Quit();
    }
    public void SetData()
    {
        transform.Find("EndingExp").GetComponent<TextMeshProUGUI>().text =
            !DataManager.Instance._getGemstone ? JsonReader.Instance.IngameText("end_01") : JsonReader.Instance.IngameText("end_02");
        GetComponent<TextMeshProUGUI>().text = JsonReader.Instance.IngameText("result_01") + $" [ {DataManager.Instance.GetCollectedCount().ToString()} / 8 ]";
        transform.parent.Find("DeathCount").GetComponent<TextMeshProUGUI>().text = JsonReader.Instance.IngameText("result_02") + $" : {DataManager.Instance._deathCount}";
    }
}