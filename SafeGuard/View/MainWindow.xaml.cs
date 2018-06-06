using SafeGuard.Enum;
using SafeGuard.Enums;
using SafeGuard.Exceptions;
using SafeGuard.Interfaces;
using SafeGuard.Model;
using SafeGuard.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SafeGuard
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        const string greetingText = "Write the code to Encrypt/Decrypt here.";

        public IEncryptViewModel encryptViewModel { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            // TODO - Improve this
            EncryptionTypeDDL.ItemsSource = System.Enum.GetValues(typeof(EncryptionType)).Cast<EncryptionType>().ToList();
            EncryptionTypeDDL.SelectedIndex = 0;
            InputText.Text = greetingText;
        }

        // Reset button
        private void ResetBtn_Click(object sender, RoutedEventArgs e)
        {
            EncryptionTypeDDL.SelectedIndex = 0;
            EncryptionKeyInputText.Text = "";
            InputText.Text = greetingText;
            OutputText.Text = "";
        }

        // Start button
        private void StartBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                EncryptionType encryptionType;
                System.Enum.TryParse(EncryptionTypeDDL.Text, out encryptionType);
                encryptViewModel = new EncryptViewModel(encryptionType,
                                                        EncryptionKeyInputText.Text, 
                                                        EncryptRB.IsChecked.Value, 
                                                        InputText.Text);
                OutputText.Text = encryptViewModel.EncryptInput();
            }
            catch (AException ae)
            {
                if (ae.ErrorLevel == ErrorLevelEnum.Warning)
                    MessageBox.Show($"Warning : {ae.Message}");
                else
                    MessageBox.Show($"ERROR : {ae.Message}");
            }
            catch (Exception)
            {
                MessageBox.Show($"Unhandeled error : {e.ToString()}");
                throw;
            }
        }
    }
}
