using UnityEngine;
using System.IO;





public class MainManger : MonoBehaviour
{
    public static MainManger Instance;
    public Color unitColour;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);



    }




    [System.Serializable]
    class saveData
    {
        public Color _unitColor;
    }

    public void saveColour()
    {
        saveData data = new saveData();
        data._unitColor = unitColour;

        string jsonData = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", jsonData);



        //test:
        Debug.Log("Color saved: " + unitColour);
        Debug.Log("JSON saved: " + jsonData);
    }




    public void loadColour()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            saveData data = JsonUtility.FromJson<saveData>(json);
            unitColour = data._unitColor;


            ///TEST:
            Debug.Log("JSON loaded: " + json);
            Debug.Log("Color loaded: " + unitColour);
        }
    }



}
