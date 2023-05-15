using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Windows.Storage;
using Windows.UI.Xaml;
using Newtonsoft.Json;
using Windows.UI.Popups;
using System.Reflection;
using System.Text.Json.Serialization;
using Microsoft.Toolkit.Uwp.Helpers;

namespace UWPTestApp
{
   public  class AppStarter
    {
        #region Const
        public const string AppDataFolder = "UWPAppData.json";
        #endregion

        #region Methods
        /// <summary>
        /// To save the pateintID and its related notes over file
        /// </summary>
        /// <param name="patientModel" ></param>
        public static async void WriteJSONAsync(PatientModel patientModel)
        {
            StorageFolder localFolder = ApplicationData.Current.LocalFolder;
            //will replace the existing 
            StorageFile fileName = await localFolder.CreateFileAsync(AppDataFolder, CreationCollisionOption.ReplaceExisting);
            string patientdetails = JsonConvert.SerializeObject(  new { PatientId = patientModel.PatientId, Notes= patientModel.Notes});
            // Write some text to the file
            await FileIO.WriteTextAsync(fileName, patientdetails);

        }
        /// <summary>
        /// To read the pateintID and its related notes from file
        /// </summary>
        public static async Task<PatientModel> ReadJSONAsync()
        {
             //To Get the local app folder path
            StorageFolder storageFolder =ApplicationData.Current.LocalFolder;
            //Create a datafilee in case it doesn't exist
            StorageFile fileName = await storageFolder.CreateFileAsync(AppDataFolder, CreationCollisionOption.OpenIfExists);
            //Read data from file
            string patientData = await Windows.Storage.FileIO.ReadTextAsync(fileName);
            return JsonConvert.DeserializeObject<PatientModel>(patientData); 
        }
        #endregion
    }
}
