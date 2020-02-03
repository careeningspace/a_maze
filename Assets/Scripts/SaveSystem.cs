using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    public static void SavePlayer (Player player)
    {
        string fileName = "player_" + player.playerName + ".dat";
        string path = Path.Combine(Application.persistentDataPath, fileName);

        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = new FileStream(path, FileMode.Create);

        PlayerData data = new PlayerData(player);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static PlayerData LoadPlayer (Player player)
    {
        string fileName = "player_" + player.playerName + ".dat";
        string path = Path.Combine(Application.persistentDataPath, fileName);

        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();

            FileStream stream = new FileStream(path, FileMode.Open);

            try
            {
                PlayerData data = formatter.Deserialize(stream) as PlayerData;
                return data;
            }
            catch (IOException e)
            {
                Debug.Log(("Something went wrong with (0). Message: (1)", fileName, e.Message));
                return null;
            }
            finally
            {
                stream.Close();
            }

        } else
        {
            Debug.LogError("Save file not found in " + path);
            return null;
        }
    }

}
