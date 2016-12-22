using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Modbus_Poll_CS;
using Windows.Devices.SerialCommunication;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace FirstRpiUWP
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private modbus link = new modbus();

        public MainPage()
        {
            this.InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            link.Open("COM3", 9600, 8, SerialParity.None, SerialStopBitCount.Two);
        }
    }
}
