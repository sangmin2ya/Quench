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
        transform.parent.Find("EndingExp").GetComponent<TextMeshProUGUI>().text =
            !DataManager.Instance._getGemstone ? "당신은 사막의 비밀을 파헤치지는 못했지만\n카라반의 도움으로 끝없는 죽음의 굴레에서는 탈출할 수 있었습니다.\n그러나 할아버지가 원했던 보물이 무엇인지는  다시는 알 수 없겠죠..."
            : "당신은 사막의 모든 비밀을 파헤치고\n할아버지의 숙원이었던 사막의 보물을 얻은 후,\n무사히 카라반의 도움을 받아 사막을 탈출하였습니다.";
        GetComponent<TextMeshProUGUI>().text = $"수집품 [ {DataManager.Instance.GetCollectedCount().ToString()} / 8 ]";
        transform.parent.Find("DeathCount").GetComponent<TextMeshProUGUI>().text = $"부활 횟수 : {DataManager.Instance._deathCount}";
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}