using AASSPP.Dto;
using AASSPP.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.NetworkInformation;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Consumer
{
    /// <summary>
    /// Interaction logic for InfoPage.xaml
    /// </summary>
    public partial class InfoPage : Window
    {
        public int _ownerId;
        private const string ApiBaseURL = "https://localhost:7244/"; // api/Card/LogIn?number=1213&id=123
        private const string EndPointGetCardByNumber = "api/Card/GetCardByNumber?number=";
        private const string EndPointGetOwnerById = "api/Owner/GetOwnerById?id=";
        private const string EndPointGetOwnerByIdSensitive = "api/Owner/GetOwnerByIdSensitive?id=";
        private const string EndPointGetCountryById = "api/CountryControllers/GetCountryById?id=";
        private const string EndPointGetCardByOwnerIdAll = "api/Card/GetCardByOwnerIdAll?id=";
        private const string EndPointGetCardSensitiveByNumber = "api/Card/GetCardSensitive?number=";
        private const string EndPointGetCardsByOwnerIdAll = "api/Card/GetCardByOwnerIdAll?id=";
        private const string EndPointGetCardsByOwnerIdFirst = "api/Card/GetCardByOwnerIdFirst?id=";
        private const string EndPointGetCashinsByCardIdAll = "api/Cashin/GetCashinByCardId?id=";
        private const string EndPointGetCashoutsByCardIdAll = "api/Cashout/GetCashoutsByCardId?id=";

        public /*List<Card>*/ Card _cards = new Card()/*List<Card>()*/;
        /// api/Owner/GetOwnerById?id=  -- get owner By ID
        /// api/Owner/GetOwnerByIdSensitive?id= -- get owner sensitive
        /// api/CountryControllers/GetCountryById?id= -- get countryById
        /// api/Card/GetCardByOwnerIdAll?id= -- get Cards All by owner Id
        /// api/Card/GetCardSensitive?number= -- get card sensitive info
        /// api/Card/GetCardByOwnerIdAll?id= -- get all cards by owner Id <summary>
        /// api/Owner/GetOwnerById?id=  -- get owner By ID
        /// api/Card/GetCardByOwnerIdFirst?id=1 -- get card by owner ID
        /// api/Cashin/GetCashinByCardId?id= -- get Cashins All By Card ID 
        /// api/Cashout/GetCashoutsByCardId?id= -- get Cashouts all by Card Id All
        /// <returns></returns>
        public async Task<string> GetOwnerSensitive() {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync($"{ApiBaseURL}{EndPointGetOwnerByIdSensitive}{_ownerId}");
                string str = "";
                if (response.IsSuccessStatusCode)
                    str = await response.Content.ReadAsStringAsync();
                return str;
            }
        }

        public async Task<string> GetInfoOwner()
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync($"{ApiBaseURL}{EndPointGetOwnerById}{_ownerId}");
                string str = "";
                if (response.IsSuccessStatusCode)
                    str = await response.Content.ReadAsStringAsync();
                return str;
            }
        }

        public async Task<string> GetCountryById(int CountryId) {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync($"{ApiBaseURL}{EndPointGetCountryById}{CountryId}");
                string str = "";
                if (response.IsSuccessStatusCode)
                    str = await response.Content.ReadAsStringAsync();
                return str;
            }
        }

        public async void GetCards() {
            using (HttpClient client = new HttpClient())
            {
                //HttpResponseMessage response = await client.GetAsync($"{ApiBaseURL}{EndPointGetCardsByOwnerIdAll}{_ownerId}");
                HttpResponseMessage response = await client.GetAsync($"{ApiBaseURL}{EndPointGetCardsByOwnerIdFirst}{_ownerId}");
                string str = "";
                str = await response.Content.ReadAsStringAsync();
                //Debug.WriteLine(str);
                //Card crd = ;
                _cards = JsonConvert.DeserializeObject<Card>(str);
                number.Text = _cards.Number;
                //return _cards;
            }
        } 

        public InfoPage(int ownerId)
        {
            _ownerId = ownerId;
            InitializeComponent();
            WriteOwnerInfo();
            GetCards();
            
            //foreach (var cards in _cards) { 
            //    Cards.Items.Add(_cards.Number);
            //Cards.SelectedIndex = 0;
            //}
        }

        public async void WriteOwnerInfo() { 
            string str = await GetInfoOwner();
            OwnerDto owner= JsonConvert.DeserializeObject<OwnerDto>(str);
            Name.Text = owner.Name;
            Surname.Text = owner.Surname;
            Sex.Text = owner.Sex;
            Born.Text = owner.Born.ToString("dd/MM/yyyy");
            string ctr = await GetCountryById(owner.CountryId);
            CountryDto country = JsonConvert.DeserializeObject<CountryDto>(ctr);
            Country.Text = country.Name;
        }



        private async void OwnerSensitive_Click(object sender, RoutedEventArgs e)
        {
            string str = await GetOwnerSensitive();
            SensitiveOwnerDto sensitive = JsonConvert.DeserializeObject<SensitiveOwnerDto>(str);
            PESEL.Visibility = Visibility.Visible;
            PESEL.Text = sensitive.PESEL;
            HOME.Visibility = Visibility.Visible;
            HOME.Text = sensitive.Home;
            PHONE.Visibility = Visibility.Visible;
            PHONE.Text = sensitive.Phone;
            
        }

        private void Cards_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        public async Task<CardSensitive> GetSensitiveCardInfo() {
            using (HttpClient client = new HttpClient())
            {
                //HttpResponseMessage response = await client.GetAsync($"{ApiBaseURL}{EndPointGetCardsByOwnerIdAll}{_ownerId}");
                HttpResponseMessage response = await client.GetAsync($"{ApiBaseURL}{EndPointGetCardSensitiveByNumber}{number.Text}");
                Debug.WriteLine($"{ApiBaseURL}{EndPointGetCardSensitiveByNumber}{number.Text}");
                string str = "";
                str = await response.Content.ReadAsStringAsync();
                //Debug.WriteLine(str);
                CardSensitive crd = JsonConvert.DeserializeObject<CardSensitive>(str);
                return crd;
                
            }
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            CardSensitive crd = await GetSensitiveCardInfo();
            pin.Text = crd.PIN.ToString();
            cvv.Text = crd.CVV.ToString();
            cardName.Text = crd.Name.ToString();
            expireDate.Text = crd.ExpireDate.ToString("MM/yyyy");
        }


        public async Task<List<CashinDto>> GetCashins() {
            using (HttpClient client = new HttpClient())
            {
                //HttpResponseMessage response = await client.GetAsync($"{ApiBaseURL}{EndPointGetCardsByOwnerIdAll}{_ownerId}");
                HttpResponseMessage response = await client.GetAsync($"{ApiBaseURL}{EndPointGetCashinsByCardIdAll}{_cards.Id}");
                //Debug.WriteLine($"{ApiBaseURL}{EndPointGetCardSensitiveByNumber}{number.Text}");
                string str = "";
                str = await response.Content.ReadAsStringAsync();
                //Debug.WriteLine(str);
                List<CashinDto> crd = JsonConvert.DeserializeObject<List<CashinDto>>(str);
                return crd;

            }
        }
        private async void Button_Click_1(object sender, RoutedEventArgs e)
        {
            List<CashinDto> cashins = await GetCashins();
            foreach (var cashin in cashins) {
                cashinsText.Text += "From Card: " + _cards.Number.ToString() + " \n\tSum: " + cashin.Sum.ToString() + "\n"; 
            }
        }


        public async Task<List<CashoutDto>> GetCashouts()
        {
            using (HttpClient client = new HttpClient())
            {
                //HttpResponseMessage response = await client.GetAsync($"{ApiBaseURL}{EndPointGetCardsByOwnerIdAll}{_ownerId}");
                HttpResponseMessage response = await client.GetAsync($"{ApiBaseURL}{EndPointGetCashoutsByCardIdAll}{_cards.Id}");
                //Debug.WriteLine($"{ApiBaseURL}{EndPointGetCardSensitiveByNumber}{number.Text}");
                string str = "";
                str = await response.Content.ReadAsStringAsync();
                //Debug.WriteLine(str);
                List<CashoutDto> crd = JsonConvert.DeserializeObject<List<CashoutDto>>(str);
                return crd;

            }
        }
        private async void Button_Click_2(object sender, RoutedEventArgs e)
        {
            List<CashoutDto> cashouts = await GetCashouts();
            foreach (var cashout in cashouts)
            {
                cashoutsText.Text += "From Card: " + _cards.Number.ToString() + " \n\tSum: " + cashout.Sum.ToString() + "\n";
            }
        }
    }
}
