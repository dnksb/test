using System.Collections;
using System.Collections.Generic;
using System.Data;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChoiceUserControler : MonoBehaviour
{

    [SerializeField] private GameObject menu;
    [SerializeField] private GameObject add_player;

    [SerializeField] private GameObject player;
    [SerializeField] private GameObject content;
    [SerializeField] private List<GameObject> clones;

    [SerializeField] private static string player_nickname;
    [SerializeField] private static int player_money;

    public static string GetPlayerNickname()
    {
        return player_nickname;
    }

    public static int GetPlayerMoney()
    {
        return player_money;
    }

    public void UpdateTable()
    {
        foreach (GameObject clon in clones)
        {
            Destroy(clon);
        }

        clones.Clear();

        Start();
    }

    private void Start()
    {
        clones = new List<GameObject>();

        DataTable scoreboard = DataBase.GetTable("SELECT * FROM players");
        //цикл добавление игроков из БД
        foreach (DataRow row in scoreboard.Rows)
        {
            var cells = row.ItemArray;

            clones.Add(Instantiate(player, player.transform));

            clones[clones.Count - 1].GetComponent<RectTransform>().SetParent(content.transform);
            clones[clones.Count - 1].SetActive(true);
            clones[clones.Count - 1].transform.GetChild(0).GetChild(0).gameObject.GetComponent<Text>().text = $"бюджет: {cells[2].ToString()}";
            clones[clones.Count - 1].transform.GetChild(0).GetChild(1).gameObject.GetComponent<Text>().text = $"{cells[1].ToString()}";
        }
    }

    public void OpenAddPlayer()
    {
        menu.SetActive(false);
        add_player.SetActive(true);
    }

    public void ChoicePlayer(GameObject text)
    {
        player_nickname = text.GetComponent<Text>().text;
        foreach (GameObject clon in clones)
        {
            if(clon.transform.GetChild(0).GetChild(1).gameObject.GetComponent<Text>().text == player_nickname)
            {
                //Debug.Log(player_nickname);
                SceneManager.LoadScene("Garage");
            }
        }
    }

    public void OpenGarage()
    {
        SceneManager.LoadScene("Garage");
    }

    public void OpenTrain()
    {
        SceneManager.LoadScene("train");
    }

}
