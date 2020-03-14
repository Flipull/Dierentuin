using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows;
using System.IO;
using Newtonsoft.Json;
using ZooLibrary.Model;
using System.Timers;
using System.Windows.Threading;

namespace WpfCore
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly HttpClient server = new HttpClient();
        private readonly string BASE_URL = "https://localhost:5001/api/";
        
        public MainWindow()
        {
            InitializeComponent();

            //manually send pull-requests every 500 ms
            var timer = new Timer();
            timer.Interval = 500;
            timer.Elapsed += (object sender, ElapsedEventArgs e) => APIUpdateRequest();
            timer.Start();
        }

        private async void CreateMonkey_Click(object sender, RoutedEventArgs e)
        {
            await APICreateRequest<Monkey>("Monkey", new Monkey());
        }
        private async void CreateLion_Click(object sender, RoutedEventArgs e)
        {
            await APICreateRequest<Lion>("Lion", new Lion());
        }
        private async void CreateElephant_Click(object sender, RoutedEventArgs e)
        {
            await APICreateRequest<Elephant>("Elephant", new Elephant());
        }
        private async void FeedAll_Click(object sender, RoutedEventArgs e)
        {
            await APIFeedRequest("All");
        }
        private async void FeedMonkeys_Click(object sender, RoutedEventArgs e)
        {
            await APIFeedRequest("Monkeys");
        }
        private async void FeedLions_Click(object sender, RoutedEventArgs e)
        {
            await APIFeedRequest("Lions");
        }
        private async void FeedElephants_Click(object sender, RoutedEventArgs e)
        {
            await APIFeedRequest("Elephants");
        }

        private async void APIUpdateRequest()//manually call API to fetch all data
        {
            var privateserver = new HttpClient();

            Uri target_address = new Uri(BASE_URL + "zoo/");
            var r = await privateserver.PostAsJsonAsync(target_address, new StringContent(""));
            //var tmp = await r.Content.ReadAsStringAsync();
            if (!r.IsSuccessStatusCode)
                throw new InvalidDataException();
            var animals = JsonConvert.DeserializeObject<Animal[]>(
                        await r.Content.ReadAsStringAsync(), 
                        new JsonSerializerSettings()
                    {
                        TypeNameHandling = TypeNameHandling.Auto
                    }
                );
            
            listview_animals.Dispatcher.Invoke(() => listview_animals.ItemsSource = animals, DispatcherPriority.Render);
            //Application.Current.Dispatcher.Invoke( ,new Action(Animal[] animals) => listview_animals.ItemsSource = animals, animals);
            //listview_animals.ItemsSource = animals;
        }
        private async Task APIFeedRequest(string action)
        {
            Uri target_address = new Uri(BASE_URL + "Feeding/" + action);
            var r = await server.PostAsJsonAsync(target_address, new StringContent("") );
            if (!r.IsSuccessStatusCode)
                throw new InvalidDataException();
        }

        private async Task<T> APICreateRequest<T>(string action, T generic_object)
        {
            Uri target_address = new Uri(BASE_URL + "Create/" + action);
            var r = await server.PostAsJsonAsync(target_address, generic_object);
            if (!r.IsSuccessStatusCode)
                throw new InvalidDataException();

            return JsonConvert.DeserializeObject<T>(await r.Content.ReadAsStringAsync() );
        }

    }
}
