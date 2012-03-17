using System;
using System.IO;
using System.Xml.Serialization;
using Microsoft.Xna.Framework.Storage;

//http://www.xnawiki.com/index.php?title=How_do_I_handle_high_scores%3F
namespace SpaceShip4042.Class
{
    public class Score
    {
        [Serializable]
        public struct HighScoreData
        {
            public string[] PlayerName;
            public int[] Score;
            public int[] Level;

            public int Count;

            public HighScoreData(int count)
            {
                PlayerName = new string[count];
                Score = new int[count];
                Level = new int[count];

                Count = count;
            }
        }

        public static void SaveHighScores(HighScoreData data, string filename)
        {
            // Get the path of the save game
            string fullpath = Path.Combine(StorageContainer.TitleLocation, filename);

            // Open the file, creating it if necessary
            FileStream stream = File.Open(fullpath, FileMode.OpenOrCreate);
            try
            {
                // Convert the object to XML data and put it in the stream
                XmlSerializer serializer = new XmlSerializer(typeof(HighScoreData));
                serializer.Serialize(stream, data);
            }
            finally
            {
                // Close the file
                stream.Close();
            }
        }

        public static HighScoreData LoadHighScores(string filename)
        {
            HighScoreData data;

            // Get the path of the save game
            string fullpath = Path.Combine(StorageContainer.TitleLocation, filename);

            // Open the file
            FileStream stream = File.Open(fullpath, FileMode.OpenOrCreate,
            FileAccess.Read);
            try
            {

                // Read the data from the file
                XmlSerializer serializer = new XmlSerializer(typeof(HighScoreData));
                data = (HighScoreData)serializer.Deserialize(stream);
            }
            finally
            {
                // Close the file
                stream.Close();
            }

            return (data);
        }
    }
}
