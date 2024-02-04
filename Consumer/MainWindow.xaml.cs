using System.Net.Http;
using System.Net;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Security.Cryptography;
using AASSPP.Models;
using System.Text.Json.Serialization;
using System.Net.Http.Json;
using Newtonsoft.Json;


namespace Consumer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const string ApiBaseURL = "https://localhost:7244/"; // api/Card/LogIn?number=1213&id=123
        private const string EndPointGetCardByNumber = "api/Card/GetCardByNumber?number=";
        /// api/Card/GetCardByNumber?number=1231414324134
        ///  
        /// 
        public MainWindow()
        {
            InitializeComponent();
        }

        public int ownerId;
        public Owner Owner = null;

        public async Task<Tuple<bool, string>> isLogged() {
            using (HttpClient client = new HttpClient())
            {
                string number = Number.Text.Trim();
                int PIN = Convert.ToInt32(pin.Text.Trim());

                HttpResponseMessage response = await client.GetAsync($"{ApiBaseURL}{EndPointGetCardByNumber}{number}");
                string str = "";
                if (response.IsSuccessStatusCode)
                {
                    str = await response.Content.ReadAsStringAsync();
                    return new Tuple<bool, string>(true, str);
                }
                else {
                    return new Tuple<bool, string>(false, str);
                }
                    
            }

            
        }

        private async void Check_Click(object sender, RoutedEventArgs e)
        {
            Tuple<bool, string> tuple = await isLogged();
            if (!tuple.Item1)
            {
                MessageBox.Show("Error in entering");
            }
            else {
                
                Card crd = JsonConvert.DeserializeObject<Card>(tuple.Item2);
                if(crd.PIN.ToString() == pin.Text.Trim())
                {
                    ownerId = crd.OwnerId;
                    InfoPage inf = new InfoPage(ownerId);
                    inf.ShowDialog();
                }
                
            }

        }
    }
}