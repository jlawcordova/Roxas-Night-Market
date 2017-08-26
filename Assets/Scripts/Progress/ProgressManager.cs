using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using StallSpace;

namespace Progress
{
    /// <summary>
    /// Tracks the progress of the player. Also handles the file manipulation of the save file.
    /// </summary>
    public static class ProgressManager
    {
        #region Progress Information
        /// <summary>
        /// Stall spaces information that can be saved.
        /// </summary>
        public static StallSpaceInformation[] StallSpaces;

        /// <summary>
        /// The amount of money the player has.
        /// </summary>
        public static int Money
        {
            get
            {
                return ProgressManager.money;
            }
            set
            {
                ProgressManager.money = value;
                // Informs all listeners that the money has been updated.
                if (MoneyUpdated != null)
                {
                    MoneyUpdated(null, new EventArgs());
                }
            }
        }
        private static int money;
        public static event EventHandler MoneyUpdated;
        #endregion

        /// <summary>
        /// The location of the save file.
        /// </summary>
        private static string SaveLocation = Application.persistentDataPath + "/Progress.dat";
        
        /// <summary>
        /// Saves stall space information to a save file.
        /// </summary>
        public static void SaveProgressToFile()
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream file = File.Open(SaveLocation, FileMode.Create);
            
            // Copy the current stall space information to the data that will be saved.
            ProgressData data = new ProgressData();
            data.StallSpaces = new StallSpaceInformation[3];
            Array.Copy(ProgressManager.StallSpaces, data.StallSpaces, 3);

            // Copy the current money to the data that will be saved.
            data.Money = ProgressManager.Money;

            // Save data to the file.
            formatter.Serialize(file, data);
            file.Close();
        }

        /// <summary>
        /// Gets stall space information from a save file.
        /// </summary>
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
                ProgressManager.StallSpaces = new StallSpaceInformation[3];
                Array.Copy(data.StallSpaces, ProgressManager.StallSpaces, 3);

                // Get the money from the data.
                ProgressManager.Money = data.Money;
            }
            else
            {
                // Create new stall space information.
                ProgressManager.StallSpaces = new StallSpaceInformation[3];
                // Create initial money.
                ProgressManager.Money = 1000;

                ProgressManager.StallSpaces[0] = new StallSpaceInformation() { StallSpaceNumber = 0, SpaceType = StallSpaceType.EmptyStall };
                ProgressManager.StallSpaces[1] = new StallSpaceInformation() { StallSpaceNumber = 1, SpaceType = StallSpaceType.EmptyStall };
                ProgressManager.StallSpaces[2] = new StallSpaceInformation() { StallSpaceNumber = 2, SpaceType = StallSpaceType.EmptyStall };

                // Save the information to the save file.
                SaveProgressToFile();
            }
        }

        /// <summary>
        /// Deletes the save file.
        /// </summary>
        public static void DeleteSaveFile()
        {
            File.Delete(SaveLocation);
        }
    }
}

