using Newtonsoft.Json;
using Roadhackers_project.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Roadhackers_project

{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page

    {

        public MainPage()
        {
            this.InitializeComponent();
            getWeatherData();

            
        }

        async void getWeatherData()
        {
            string url = "http://api.openweathermap.org/data/2.5/weather?q=antwerp,be&units=metric&apikey=23c1237f8e3a4a8eca581f9c2c647d85"; //SRS:  URL to fetch data with my personal generated API Key
            HttpClient client = new HttpClient(); // SRS: to call the website 

            string weatherData = await client.GetStringAsync(url); // SRS: to save the fetched data into a string, data will be in json format and has to be converted
            var data = JsonConvert.DeserializeObject<Rootobject>(weatherData);

            txtBlockWeatherResult.Text = data.main.temp.ToString() + "C";


        }

       
    }
}

