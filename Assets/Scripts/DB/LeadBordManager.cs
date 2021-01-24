using System.Data;
using Mono.Data.Sqlite;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class LeadBordManager : MonoBehaviour
{

    private string connectionString;
    private List<HighScores> highScores = new List<HighScores>();
    public GameObject prefab; //ScorePrefab
    public Transform scoreParent;
    public int topRan;
    public int saveScores;
    public InputField enterName;

    public GameObject nameDialog;

    // Start is called before the first frame update
    void Start()
    {
        //int scores = PlayerPrefs.GetInt("Coins");
        connectionString = "URI=file:" + Application.dataPath + "/LeadBoardDB.db";
        //InsertScores("Yuli", PlayerPrefs.GetInt("Score"));
        //GetScores();

        DeleteExtraScores();
        ShowScores();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            nameDialog.SetActive(!nameDialog.activeSelf);
        }
    }


    //to input the name of the user in the LeadBoard
    public void EnterName()
    {
        // insert a new score if the editText is not empty
        if(enterName.text != string.Empty)
        {
            int score = UnityEngine.Random.Range(1, 500);
            InsertScores(enterName.text, PlayerPrefs.GetInt("Score"));
            enterName.text = string.Empty;

            ShowScores();
        }
    }

    //to insert the data
    private void InsertScores(string name, int score)
    {
        GetScores();
        int hsCount = highScores.Count;
        if (highScores.Count > 0)
        {
            HighScores lowestScore = highScores[highScores.Count - 1];
            if (lowestScore != null && saveScores > 0 && highScores.Count >= saveScores)
            {
                DeleteScore(lowestScore.ID);
                hsCount--;
            }
        }
        if (hsCount < saveScores)
        {
            //get a connection to database
            using (IDbConnection dbConnection = new SqliteConnection(connectionString))
            {
                dbConnection.Open();

                //using our connection to create command
                using (IDbCommand dbCmd = dbConnection.CreateCommand())
                {
                    //insert new Score
                    string sqlQuery = string.Format("INSERT INTO HightScores(Name, Score) " +
                        "VALUES(\"{0}\", \"{1}\")", name, score);
                    //execute the command
                    dbCmd.CommandText = sqlQuery;
                    dbCmd.ExecuteScalar();

                    //close the coxnnection
                    dbConnection.Close();
                }
            }
        }
    }

    private void GetScores()
    {
        highScores.Clear();
        //get a connection to database
        using (IDbConnection dbConnection = new SqliteConnection(connectionString))
        {
            dbConnection.Open();

            //using our connection to create command
            using (IDbCommand dbCmd = dbConnection.CreateCommand())
            {
                string sqlQuery = "SELECT * from HightScores";
                //execute the command
                dbCmd.CommandText = sqlQuery;

                //return result from execute to reader
                using (IDataReader reader = dbCmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        highScores.Add(new HighScores(reader.GetInt32(0),
                            reader.GetInt32(2), reader.GetString(1), reader.GetDateTime(3)));

                    }
                    //close the connection
                    dbConnection.Close();
                    reader.Close();
                }
            }
        }
        highScores.Sort();
    }


    private void DeleteScore(int id)
    {
        using (IDbConnection dbConnection = new SqliteConnection(connectionString))
        {
            dbConnection.Open();

            //using our connection to create command
            using (IDbCommand dbCmd = dbConnection.CreateCommand())
            {
                //delete scores
                string sqlQuery = string.Format("DELETE FROM HightScores WHERE PlayerID = \"{0}\"", id);

                //execute the command
                dbCmd.CommandText = sqlQuery;
                dbCmd.ExecuteScalar();

                //close the coxnnection
                dbConnection.Close();
            }
        }
    }

    //show board of scores
    private void ShowScores()
    {
        GetScores();

        foreach(GameObject score in GameObject.FindGameObjectsWithTag("Score"))
        {
            Destroy(score);
        }

        for (int i = 0; i < topRan; i++)
        {
            if (i <= highScores.Count - 1)
            {
                GameObject tmpObj = Instantiate(prefab);
                HighScores tmpScore = highScores[i]; //take each highScore

                //get values of scores
                tmpObj.GetComponent<HSScript>().SetScore(tmpScore.Name, tmpScore.Score.ToString(), "#" + (i + 1).ToString());
                tmpObj.transform.SetParent(scoreParent); //put our score above the title in the table

                tmpObj.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
                tmpObj.GetComponent<Transform>().localPosition = new Vector3(gameObject.transform.position.x,
                    gameObject.transform.position.y, 0);
            }
        }
    }
    private void DeleteExtraScores()
    {
        GetScores();

        if (saveScores <= highScores.Count)
        {
            int deleteCount = highScores.Count - saveScores;
            highScores.Reverse();

            using (IDbConnection dbConnection = new SqliteConnection(connectionString))
            {
                dbConnection.Open();

                //using our connection to create command
                using (IDbCommand dbCmd = dbConnection.CreateCommand())
                {

                    for (int i = 0; i < deleteCount; i++)
                    {
                        //delete scores
                        string sqlQuery = string.Format("DELETE FROM HightScores WHERE PlayerID = \"{0}\"", highScores[i].ID);

                        //execute the command
                        dbCmd.CommandText = sqlQuery;
                        dbCmd.ExecuteScalar();
                    }

                    //close the coxnnection
                    dbConnection.Close();

                }
            }
        }
    }
}
