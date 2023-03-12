using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.UI;

public class AddPlayerControl : MonoBehaviour
{

    [SerializeField] private GameObject menu;
    [SerializeField] private GameObject add_player;

    [SerializeField] private GameObject error_text;
    [SerializeField] private GameObject textBox;

    private bool HaveNicknameInBD(string nickname)
    {
        bool found = false;
        DataTable scoreboard = DataBase.GetTable("SELECT * FROM players");

        foreach (DataRow row in scoreboard.Rows)
        {
            var cells = row.ItemArray;

            foreach (object cell in cells)
            {
                if(cell.ToString() == nickname)
                {
                    found = true;
                }
            }
        }
        return found;
    }

    public void AddPlayer()
    {
        string nickname = textBox.transform.GetChild(2).gameObject.GetComponent<Text>().text;
        if(HaveNicknameInBD(nickname))
        {
            error_text.SetActive(true);
        }
        else
        {
            DataBase.ExecuteQueryWithoutAnswer($"INSERT INTO players (nickname, level) VALUES ('{nickname}',{1})");
        }
    }

    public void CloseAddPlayer()
    {
        menu.SetActive(true);
        add_player.SetActive(false);
    }

}
