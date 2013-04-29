using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json.Linq;
using SimpleRedditPCL;

namespace SimpleRedditPCL
{
    public class MainViewModel : BindableBase
    {
        public RedditBoard redditData;
        
        public MainViewModel()
        {
            this.Items = new ObservableCollection<subredditentries>();
            this.Subreddit = "pics";
            this.redditData = new RedditBoard(this.Subreddit);
        }

        public ObservableCollection<subredditentries> Items { get; private set; }

        private bool _isDataLoaded = false;
        public Boolean IsDataLoaded
        {
            get { return this._isDataLoaded; }
            set { this.SetProperty(ref this._isDataLoaded, value); }
        }

        private string _subreddit = "";
        public string Subreddit
        {
            get { return this._subreddit; }
            set { this.SetProperty(ref this._subreddit, value); }
        }

        public async void LoadData()
        {
            // Sample data; replace with real data
            //this.Items.Add(new subredditentries() { Title = "runtime one"});
            var srh = await redditData.GetData();
            if (srh.Any())
            {
                Items.Clear();
                var i = 0;
                foreach (var sre in srh)
                {
                    var x = sre["data"].ToObject<subredditentries>();
                    Items.Add(x);
                }
            }

            this.IsDataLoaded = true;
        }

    }
}