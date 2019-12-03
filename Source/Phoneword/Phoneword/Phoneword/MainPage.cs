using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Phoneword
{
    public class MainPage: ContentPage
    {
        private Entry _phoneNumberText;
        private Button _translateButton;
        private Button _callButton;
        private string _translatedNumber;

        public MainPage()
        {
            Padding = new Thickness(20, 20, 20, 20);

            StackLayout panel = new StackLayout
            {
                Spacing = 15
            };

            panel.Children.Add(new Label
            {
                Text = "Enter a Phoneword:",
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label))
            });

            panel.Children.Add(_phoneNumberText = new Entry
            {
                Text = "0-800-XAMARIN",
            });

            panel.Children.Add(_translateButton = new Button
            {
                Text = "Translate"
            });

            panel.Children.Add(_callButton = new Button
            {
                Text = "Call",
                IsEnabled = false,
            });

            Content = panel;
            _translateButton.Clicked += OnTranslate;
            _callButton.Clicked += OnCall;
        }

        private void OnTranslate(object sender, EventArgs e)
        {
            string enteredNumber = _phoneNumberText.Text;
            _translatedNumber = Core.PhonewordTranslator.ToNumber(enteredNumber);

            if (!string.IsNullOrEmpty(_translatedNumber))
            {
                _callButton.IsEnabled = true;
                _callButton.Text = "Call " + _translatedNumber;
            }
            else
            {
                _callButton.IsEnabled = false;
                _callButton.Text = "Call";
            }
        }

        async void OnCall(object sender, System.EventArgs e)
        {
            if (await this.DisplayAlert(
                "Dial a Number",
                "Would you like to call " + _translatedNumber + "?",
                "Yes",
                "No"))
            {
                try
                {
                    PhoneDialer.Open(_translatedNumber);
                }
                catch (ArgumentNullException)
                {
                    await DisplayAlert("Unable to dial", "Phone number was not valid.", "OK");
                }
                catch (FeatureNotSupportedException)
                {
                    await DisplayAlert("Unable to dial", "Phone dialing not supported.", "OK");
                }
                catch (Exception)
                {
                    // Other error has occurred.
                    await DisplayAlert("Unable to dial", "Phone dialing failed.", "OK");
                }
            }
        }

    }
}
