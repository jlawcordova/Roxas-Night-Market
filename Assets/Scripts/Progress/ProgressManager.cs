using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using StallSpace;
using UnityEngine;

namespace Progress
{
    public static class ProgressManager
    {
        /// <summary>
        /// Stall spaces information that can be saved.
        /// </summary>
        public static StallSpaceInformation[] StallSpaces;
        private static string SaveLocation = Application.persistentDataPath + "/Progress.dat";

        /// <summary>
        /// Gets stall space information from a save file.
        /// </summary>
        public static void SaveProgressToFile()
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream file = File.Open(SaveLocation, FileMode.Create);
            
            // Copy the current stall space information to the data that will be saved.
            ProgressData data = new ProgressData();
            data.StallSpaces = new StallSpaceInformation[3];
            Array.Copy(StallSpaces, data.StallSpaces, 3);

            // Save data to the file.
            formatter.Serialize(file, data);
            file.Close();
        }

        public static void GetProgressFromFile()
        {
            if (File.Exists(SaveLocation))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                FileStream file = File.Open(SaveLocation, FileMode.Open);

                // Get the content from the file and place in the data object.
                ProgressData data = (ProgressData)formatter.Deserialize(file);
                file.Close();

                // Copy the data to the current stall space information.
                StallSpaces = new StallSpaceInformation[3];
                Array.Copy(data.StallSpaces, StallSpaces, 3);
            }
            else
            {
                // Create new stall space information.
                StallSpaces = new StallSpaceInformation[3];

                StallSpaces[0] = new StallSpaceInformation() { StallSpaceNumber = 0, SpaceType = StallSpaceType.EmptyStall };
                StallSpaces[1] = new StallSpaceInformation() { StallSpaceNumber = 1, SpaceType = StallSpaceType.EmptyStall };
                StallSpaces[2] = new StallSpaceInformation() { StallSpaceNumber = 2, SpaceType = StallSpaceType.EmptyStall };

                // Save the information to the save file.
                SaveProgressToFile();
            }
        }
    }

    [Serializable]
    class ProgressData
    {
        public StallSpaceInformation[] StallSpaces;
    }
}

