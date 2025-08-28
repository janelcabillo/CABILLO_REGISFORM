namespace CABILLO_REGISTRATIONFORM
{
    public partial class MainPage : ContentPage
    {


        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnCounterClicked(object sender, EventArgs e)
        {
            var missingFields = new List<string>();

            if (string.IsNullOrWhiteSpace(FirstNameEntry.Text))
                missingFields.Add("First Name");

            if (string.IsNullOrWhiteSpace(LastNameEntry.Text))
                missingFields.Add("Last Name");

            if (string.IsNullOrWhiteSpace(AgeEntry.Text) || !int.TryParse(AgeEntry.Text, out int age) || age <= 0)
                missingFields.Add("Age");

            if (string.IsNullOrWhiteSpace(AddressEntry.Text))
                missingFields.Add("Address");

            if (string.IsNullOrWhiteSpace(EmailEntry.Text) || !IsValidEmail(EmailEntry.Text))
                missingFields.Add("Email");

            if (StatusPicker.SelectedIndex == -1)
                missingFields.Add("Status");

            if (!(MaleRadio.IsChecked || FemaleRadio.IsChecked))
                missingFields.Add("Gender");

            if (string.IsNullOrWhiteSpace(AboutEditor.Text))
                missingFields.Add("About You");

            if (missingFields.Count > 0)
            {
                string fields = string.Join(", ", missingFields);
                await DisplayAlert("Missing Input", $"Please check the missing inputs: {fields}.", "OK");
                return;
            }

            // If all required inputs are filled
            await DisplayAlert("Registration Successful", $"Welcome, {FirstNameEntry.Text}!", "OK");
        }

        bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
    }
}


      
