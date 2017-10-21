using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using StallSpace;
using System.Collections.Generic;

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
        private const int MaxStallSpacesCount = 12;

        /// <summary>
        /// The day of the game.
        /// </summary>
        public static int Day;

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

        public static List<int> CustomersUnlocked;

        public static int PlaceSize;
        private const int MaxPlaceSize = 3;

        public static bool TutorialMode;
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

            // Copy the current day to the data that will be saved.
            data.Day = ProgressManager.Day;
            // Copy the current money to the data that will be saved.
            data.Money = ProgressManager.Money;
            // Copy the unlocked customers to the data.
            int[] tempCustomerUnlock = new int[ProgressManager.CustomersUnlocked.Count];
            ProgressManager.CustomersUnlocked.CopyTo(tempCustomerUnlock);
            data.CustomersUnlocked = new List<int>(tempCustomerUnlock);
            // Copy the current place size to the data that will be saved.
            data.PlaceSize = ProgressManager.PlaceSize;
            // Copy the current tutorial mode.
            data.TutorialMode = ProgressManager.TutorialMode;

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

                ProgressManager.Day = data.Day;

                // Get the money from the data.
                ProgressManager.Money = data.Money;
                // Get the unlocked customers.
                int[] tempCustomerUnlock = new int[data.CustomersUnlocked.Count];
                data.CustomersUnlocked.CopyTo(tempCustomerUnlock);
                ProgressManager.CustomersUnlocked = new List<int>(tempCustomerUnlock);
                // Get the place size from the data.
                ProgressManager.PlaceSize = data.PlaceSize;
                // Get the tutorial mode.
                ProgressManager.TutorialMode = data.TutorialMode;
            }
            else
            {
                // Create new stall space information.
                ProgressManager.StallSpaces = new StallSpaceInformation[MaxStallSpacesCount];

                // Only the first 3 stalls are activated and they are all empty.
                ProgressManager.StallSpaces[0] = new StallSpaceInformation() { StallSpaceNumber = 0, SpaceType = StallSpaceType.EmptyStall };
                ProgressManager.StallSpaces[1] = new StallSpaceInformation() { StallSpaceNumber = 1, SpaceType = StallSpaceType.EmptyStall };
                ProgressManager.StallSpaces[2] = new StallSpaceInformation() { StallSpaceNumber = 2, SpaceType = StallSpaceType.EmptyStall };

                // Set the remaining stalls to be null.
                for (int i = 3; i < MaxStallSpacesCount; i++)
                {
                    ProgressManager.StallSpaces[i] = null;
                }

                // Initialize day.
                ProgressManager.Day = 1;

                // Create initial money.
                ProgressManager.Money = 0;

                // Unlock initial customers.
                ProgressManager.CustomersUnlocked = new List<int>();
                ProgressManager.CustomersUnlocked.Add(0);
                ProgressManager.CustomersUnlocked.Add(1);

                ProgressManager.PlaceSize = 0;

                // Tutorial is enabled.
                ProgressManager.TutorialMode = true;

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
        /// Checks of a customer is unlocked.
        /// </summary>
        /// <returns>The indication if a customer is unlocked.</returns>
        public static bool CheckCustomerUnlock(out int unlockedCustomerNumber)
        {
            switch (ProgressManager.Day)
            {
                case 3:
                    // Unlock rich kid on day 3.
                    UnlockCustomer(2);

                    unlockedCustomerNumber = 2;
                    return true;

                case 5:
                    // Unlock the businessman on day 5.
                    UnlockCustomer(3);

                    unlockedCustomerNumber = 3;
                    return true;

                case 9:
                    // Unlock the granny on day 9.
                    UnlockCustomer(4);

                    unlockedCustomerNumber = 4;
                    return true;

                case 15:
                    // Unlock the vegan on day 15.
                    UnlockCustomer(5);

                    unlockedCustomerNumber = 5;
                    return true;

                case 24:
                    // Unlock Vice Gander on day 24.
                    UnlockCustomer(6);

                    unlockedCustomerNumber = 6;
                    return true;

                case 35:
                    // Unlock P. Diggy on day 35.
                    UnlockCustomer(7);

                    unlockedCustomerNumber = 7;
                    return true;
                case 50:
                    // Unlock the chicken head on day 50.
                    UnlockCustomer(8);

                    unlockedCustomerNumber = 8;
                    return true;
                default:
                    break;
            }

            unlockedCustomerNumber = 0;
            return false;
        }

        /// <summary>
        /// Checks of a customer is unlocked.
        /// </summary>
        /// <returns>The indication if the game has reached its endpoint.</returns>
        public static bool CheckGameEnd()
        {
            return ProgressManager.Day == 100;
        }


        /// <summary>
        /// Unlocks a customer number and saves the progress to the save file.
        /// </summary>
        /// <param name="customerNumberToUnlock">The customer number to unlock.</param>
        /// <param name="unlockedCustomerNumber"></param>
        private static void UnlockCustomer(int customerNumberToUnlock)
        {
            if (!ProgressManager.CustomersUnlocked.Contains(customerNumberToUnlock))
            {
                ProgressManager.CustomersUnlocked.Add(customerNumberToUnlock);
                
                ProgressManager.SaveProgressToFile();
            }
        }

        /// <summary>
        /// Checks if the place size should be upgraded.
        /// </summary>
        /// <returns></returns>
        public static bool CheckPlaceSizeUpgrade()
        {
            if (ProgressManager.PlaceSize < MaxPlaceSize)
            {
                bool allStallsBought = true;

                // Check if all stalls are not empty.
                for (int i = 0; i < (ProgressManager.PlaceSize + 1) * 3; i++)
                {
                    if (ProgressManager.StallSpaces[i].SpaceType == StallSpaceType.EmptyStall)
                    {
                        allStallsBought = false;
                    }
                }

                // If no stall is empty, upgrade the size and create more empty stalls.
                if (allStallsBought)
                {
                    ProgressManager.PlaceSize++;

                    for (int i = (ProgressManager.PlaceSize) * 3; i < ((ProgressManager.PlaceSize + 1) * 3); i++)
                    {
                        ProgressManager.StallSpaces[i] = new StallSpaceInformation() { StallSpaceNumber = i, SpaceType = StallSpaceType.EmptyStall };
                    }
                    
                    return true;
                }
            }
            
            return false;
        }
    }
}

