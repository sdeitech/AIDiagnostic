using Windows.ApplicationModel.Payments;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;


// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace UWPTestApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        #region Ctor
        public MainPage()
        {
            this.InitializeComponent();
            OnLoad();
        }
        #endregion

        #region Method
        /// <summary>
        /// To get the saved PateintId and Notes.
        /// </summary>
        public async void OnLoad()
        {
            PatientModel patientdetails = await AppStarter.ReadJSONAsync();
            if (patientdetails != null)
            {
                PatientIdValue.Text = patientdetails.PatientId;
                Notesvalues.Text = patientdetails.Notes;
            }
        }
        #endregion

        #region EventHandlers
        /// <summary>
        /// Save the PatientId and Its related Noted Over the File, In JSON format.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(PatientIdValue.Text) && !string.IsNullOrEmpty(Notesvalues.Text))
            {
                PatientModel patientModel = new PatientModel();
                patientModel.PatientId = PatientIdValue.Text;
                patientModel.Notes = Notesvalues.Text;
                AppStarter.WriteJSONAsync(patientModel);
            }

        }

        /// <summary>
        /// After the selction of Password Menu from the right hand setting icon, popup for password confirmation is appeared.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PasswordMenu_Click(object sender, RoutedEventArgs e)
        {
            confirmationPopup.IsOpen = true;
        }

        /// <summary>
        ///In case the password entered is correct(i.e 123), the user automatically exit from the app, else the pop up disaapers only.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Confirm_Click(object sender, RoutedEventArgs e)
        {
            if (txt_password.Text != "123")
                confirmationPopup.IsOpen = false;
            else
            {
                Windows.UI.Xaml.Application.Current.Exit();
            }
        }
        #endregion

        /// <summary>
        /// Clear the prefilled PatientId and Notes.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnclear_Click(object sender, RoutedEventArgs e)
        {
            PatientIdValue.Text =string.Empty;
            Notesvalues.Text = string.Empty;
        }
    }
}
