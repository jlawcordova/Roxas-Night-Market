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
        private const int MaxStallSpacesCount = 7;

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

        public static int PlaceSize;
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
            data.StallSpaces = new StallSpaceInformation[MaxStallSpacesCount];
            Array.Copy(ProgressManager.StallSpaces, data.StallSpaces, MaxStallSpacesCount);

            // Copy the current money to the data that will be saved.
            data.Money = ProgressManager.Money;
            // Copy the current place size to the data that will be saved.
            data.PlaceSize = ProgressManager.PlaceSize;

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
                ProgressManager.StallSpaces = new StallSpaceInformation[MaxStallSpacesCount];
                Array.Copy(data.StallSpaces, ProgressManager.StallSpaces, MaxStallSpacesCount);
                    
                // Get the money from the data.
                ProgressManager.Money = data.Money;
                // Get the place size from the data.
                ProgressManager.PlaceSize = data.PlaceSize;
            }
            else
            {
                // Create new stall space information.
                ProgressManager.StallSpaces = new StallSpaceInformation[MaxStallSpacesCount];

                ProgressManager.StallSpaces[0] = new StallSpaceInformation() { StallSpaceNumber = 0, SpaceType = StallSpaceType.EmptyStall };
                ProgressManager.StallSpaces[1] = new StallSpaceInformation() { StallSpaceNumber = 1, SpaceType = StallSpaceType.EmptyStall };
                ProgressManager.StallSpaces[2] = new StallSpaceInformation() { StallSpaceNumber = 2, SpaceType = StallSpaceType.EmptyStall };
                ProgressManager.StallSpaces[3] = null;
                ProgressManager.StallSpaces[4] = null;
                ProgressManager.StallSpaces[5] = null;
                ProgressManager.StallSpaces[6] = null;

                // Create initial money.
                ProgressManager.Money = 10000;
                ProgressManager.PlaceSize = 0;

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

        /// <summary>
        /// Checks if the place size should be upgraded.
        /// </summary>
        /// <returns></returns>
        public static bool CheckPlaceSizeUpgrade()
        {
            switch (ProgressManager.PlaceSize)
            {
                // First upgrade.
                case 0:
                    bool allStallsBought = true;
                    for (int i = 0; i < 3; i++)
                    {
                        if (ProgressManager.StallSpaces[i].SpaceType == StallSpaceType.EmptyStall)
                        {
                            allStallsBought = false;
                        }
                    }

                    // Add three stall spaces and increase place size.
                    if (allStallsBought)
                    {
                        ProgressManager.PlaceSize = 1;

                        ProgressManager.StallSpaces[3] = new StallSpaceInformation() { StallSpaceNumber = 3, SpaceType = StallSpaceType.EmptyStall }; 
                        ProgressManager.StallSpaces[4] = new StallSpaceInformation() { StallSpaceNumber = 4, SpaceType = StallSpaceType.EmptyStall }; 
                        ProgressManager.StallSpaces[5] = new StallSpaceInformation() { StallSpaceNumber = 5, SpaceType = StallSpaceType.EmptyStall }; 

                        return true;
                    }
                    break;

                default:
                    break;
            }

            return false;
        }
    }
}

