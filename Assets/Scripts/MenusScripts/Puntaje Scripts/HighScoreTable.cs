using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreTable : MonoBehaviour
{
    // Clase para guardar instancias de puntajes - jugador
    [System.Serializable]

    private class HighScoreEntry
    {
        //Esto es un moco, los setters y getters estan al pedo porque JsonUtilities no serializa miembros privados
        //asi que los tuve que cambiar a publicos

        public int score;
        public string name;

        public int Score { get => score; set => score = value; }
        public string Name { get => name; set => name = value; }
        public HighScoreEntry(int scoreValue, string nameValue) {
            this.score = scoreValue;
            this.name = nameValue;
        }
    }

    private class HighScores
    {
        public List<HighScoreEntry> leaderboarList;

        public HighScores(List<HighScoreEntry> leadList)
        {
            leaderboarList = leadList;
        }
    }

    private Transform entryContainer; // El contenedor de las filas puntaje - jugador
    private Transform entryRowTemplate; // La plantilla pos - puntaje - jugador
    private List<HighScoreEntry> highScoreEntryList; // Una lista que almacena instancias de la clase HighScoreEntry
    private List<Transform> highScoreEntryTransformList; // Una lista que almacena las entradas para mostrar en la UI
    [SerializeField] private float separation = 30.0f; // La separacion entre filas pos - puntaje - jugador

    //Para debug
    [SerializeField] private bool clearPlayerPref = false;
    //[SerializeField] private bool addPlayer = true;
    [SerializeField] private bool addPlayer;
    //[SerializeField] private int newPlayerScore = 1000;
    //[SerializeField] private string newPlayerName = "OBS";

    private void Awake() {
        highScoreEntryTransformList = new List<Transform>();
        entryContainer = transform.Find("Contenedor");
        entryRowTemplate = entryContainer.Find("Fila");

        entryRowTemplate.gameObject.SetActive(false);
    }

    private void Start()
    {   
        LoadFromPlayerPref(clearPlayerPref);

        // Aca hay que cargar la data guardada en PlayerPref del jugador que esta jugando en este momento y sacar este hardcodeo
        if (addPlayer)
        {
            AddPlayerToList();
        }

        OrderListByPoints(highScoreEntryList);

        foreach (HighScoreEntry item in highScoreEntryList)
        {
            CreateEntry(item, entryContainer, highScoreEntryTransformList);
        }
    }

    private void GenerateMockData()
    {
        // Mock data
        // TODO: Quitar en release, generacion data ficticia

        //Debug.LogWarning("Esto es data ficticia!!!!!!!");

        //highScoreEntryList = new List<HighScoreEntry>() {
        //    new HighScoreEntry(32, "AAA"),
        //    new HighScoreEntry(52, "AAB"),
        //    new HighScoreEntry(22, "AVA"),
        //    //new HighScoreEntry(25, "ACA"),
        //    //new HighScoreEntry(62, "BAA"),
        //    //new HighScoreEntry(11, "EAA"),
        //    //new HighScoreEntry(95, "ATA"),
        //    //new HighScoreEntry(15, "AAE"),

        //};

        //SaveToPlayerPref();
       
    }

    private void SaveToPlayerPref()
    {
        HighScores highScores = new HighScores(highScoreEntryList);
        string leaderboardInString = JsonUtility.ToJson(highScores);
        PlayerPrefs.SetString("leaderboardTable", leaderboardInString);
        PlayerPrefs.Save();
    }

    private void LoadFromPlayerPref(bool clearPlayerPref)
    {
        if (clearPlayerPref)
        {
            ClearPlayerPref();
        }

        highScoreEntryList = new List<HighScoreEntry>();
        HighScores highScores = JsonUtility.FromJson<HighScores>(PlayerPrefs.GetString("leaderboardTable"));
        if (highScores == null)
        {
            GenerateMockData();
            return;
        }
        foreach (HighScoreEntry item in highScores.leaderboarList)
        {
            highScoreEntryList.Add(new HighScoreEntry(item.score, item.name));
        }
    }

    private void AddPlayerToList()
    {
        HighScoreEntry playerEntry = new HighScoreEntry(PlayerPrefs.GetInt("Puntaje", 0), PlayerPrefs.GetString("Nombre"));

        foreach (HighScoreEntry item in highScoreEntryList)
        {
            if (item.Name == playerEntry.Name)
            {
                Debug.Log(string.Format("Tu puntaje anterior era {0} y el nuevo es {1}", item.Score, playerEntry.Score));
                if (playerEntry.Score > item.Score)
                {
                    Debug.Log("Superaste tu propio record");
                    item.Score = playerEntry.Score;
                }
                else
                {
                    Debug.Log("No te dio la nafta");
                }

                SaveToPlayerPref();
                return;
            }
        }

        highScoreEntryList.Add(playerEntry);
        SaveToPlayerPref();
    }

    public void ClearPlayerPref()
    {
        addPlayer = false; //--
        PlayerPrefs.SetString("leaderboardTable", null);
        PlayerPrefs.Save();
    }

    public void ActivarListaPuntaje()
    {
        addPlayer = true;
    }

    private void OrderListByPoints(List<HighScoreEntry> entries)
    {
        for (int i = 0; i < entries.Count; i++)
        {
            for (int j = i + 1; j < entries.Count; j++)
            {
                if (entries[j].Score > entries[i].Score)
                {
                    HighScoreEntry temp = entries[i];
                    entries[i] = entries[j];
                    entries[j] = temp;
                }                
            }
        }
    }

    private void CreateEntry(HighScoreEntry newEntry, Transform container, List<Transform> transformList) {
        if (transformList.Count >= 10)
        {
            return;
        }
        Transform newEntryRow = Instantiate(entryRowTemplate, container);
        RectTransform newEntryRectTransform = newEntryRow.GetComponent<RectTransform>();
        newEntryRectTransform.anchoredPosition = new Vector2(0, -separation * transformList.Count);
        newEntryRow.gameObject.SetActive(true);

        int pos = 1 + transformList.Count;
        newEntryRow.Find("Pos_text").GetComponent<Text>().text = pos.ToString();
        //Temporal data
        //int score = Random.Range(0, 10000);
        //string name = "OBS";
        newEntryRow.Find("Score_text").GetComponent<Text>().text = newEntry.Score.ToString();
        newEntryRow.Find("Name_text").GetComponent<Text>().text = newEntry.Name;

        transformList.Add(newEntryRow);
    }
}
