using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Webkit;
using Android.Widget;

namespace App1
{
    [Activity(Label = "moviedetails")]
    public class moviedetails : Activity
    {
        string moviename;
        TextView movienamefromxml, views;
        TextView moviedetailsxml, movierating;
        Spinner spinnerView;
        string[] myCategory = { "Select","Add To Favorite List", "Add to Watch Later" };
        DBHelperclass dbcn;
        

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.moviedetails);
            moviename = Intent.GetStringExtra("movie");
            movienamefromxml= FindViewById<TextView>(Resource.Id.movieNameId);
            moviedetailsxml = FindViewById<TextView>(Resource.Id.moviedetails);
            views = FindViewById<TextView>(Resource.Id.moviedetails);
            movierating = FindViewById<TextView>(Resource.Id.movierating);
            spinnerView = FindViewById<Spinner>(Resource.Id.spinner1);

            spinnerView.Adapter = new ArrayAdapter
                (this, Android.Resource.Layout.SimpleListItem1, myCategory);           

            string strUrl = "http://youtube.com/embed/Z-9JUl0z4A8";

            movienamefromxml.Text = moviename;

            if (moviename.Equals("Special 26"))
            {
                moviedetailsxml.Text = "Movie Description: A group of cons pose as CBI officers and conduct bogus raids to loot politicians and businessmen. When the real CBI officers learn about this gang, they come up with a plan to catch them red-handed. ";
                
                
                movierating.Text =  "8.0";
                strUrl= "http://youtube.com/embed/DNi8nyn-v0s";

            }
            if (moviename.Equals("Chak De India"))
            {
                moviedetailsxml.Text = "Movie Description: After failing to score the winning goal, Kabir Khan (Shah Rukh Khan), Captain of the Men's Hockey Team is blamed for the team's loss and fired.";
                
                movierating.Text = "8.2";
                strUrl = "http://youtube.com/embed/6a0-dSMWm5g";
                
            }
            if (moviename.Equals("Parmanu"))
            {
                moviedetailsxml.Text = "Movie Description: A dedicated government official puts his career in jeopardy by insisting that India become a nuclear power, a goal that powerful forces resist.";


                movierating.Text = "7.7";
                strUrl = "http://youtube.com/embed/qN_9DnBh3hM";

            }
            if (moviename.Equals("Dangal"))
            {
                moviedetailsxml.Text = "Movie Description: After his failure at winning a gold medal for the country, Mahavir Phogat vows to realize his dreams by training his daughters for the Commonwealth Games despite societal pressures.";

                movierating.Text = "8.4";
                strUrl = "http://youtube.com/embed/LvtEnYvicno";

            }
            if (moviename.Equals("Sanju"))
            {
                moviedetailsxml.Text = "Movie Description: Coming from a family of cinematic legends, East Indian actor Sanjay Dutt reaches dizzying heights of success -- but also battles numerous addictions and other personal demons.";


                movierating.Text = "7.9";
                strUrl = "http://youtube.com/embed/1J76wN0TPI4";

            }
            if (moviename.Equals("Black Panther"))
            {
                moviedetailsxml.Text = "Movie Description: After the death of his father, T'Challa returns home to the African nation of Wakanda to take his rightful place as king. When a powerful enemy suddenly reappears, T'Challa's mettle as king -- and as Black Panther ";

                movierating.Text = "7.3";
                strUrl = "http://youtube.com/embed/xjDjIWPwcPU";

            }
            if (moviename.Equals("Inception"))
            {
                moviedetailsxml.Text = "Movie Description: Dom Cobb (Leonardo DiCaprio) is a thief with the rare ability to enter people's dreams and steal their secrets from their subconscious. His skill has made him a hot commodity in the world of corporate espionage but has also cost him everything he loves";


                movierating.Text = "8.8";
                strUrl = "http://youtube.com/embed/YoHD9XEInc0";

            }
            if (moviename.Equals("Iron Man"))
            {
                moviedetailsxml.Text = "Movie Description: A billionaire industrialist and genius inventor, Tony Stark (Robert Downey Jr.), is conducting weapons tests overseas, but terrorists kidnap him to force him to build a devastating weapon. Instead, he builds an armored suit and upends his captors";

                movierating.Text = "7.9";
                strUrl = "http://youtube.com/embed/BoohRoVA9WQ";

            }
            if (moviename.Equals("Aladdin"))
            {
                moviedetailsxml.Text = "Movie Description: Aladdin is a lovable street urchin who meets Princess Jasmine, the beautiful daughter of the sultan of Agrabah. While visiting her exotic palace, Aladdin stumbles upon a magic oil lamp that unleashes a powerful, wisecracking, larger-than-life genie.";


                movierating.Text = "7.4";
                strUrl = "http://youtube.com/embed/foyufD52aog";

            }
            if (moviename.Equals("Spider Man"))
            {
                moviedetailsxml.Text = "Movie Description: Spider-Man centers on student Peter Parker (Tobey Maguire) who, after being bitten by a genetically-altered spider, gains superhuman strength and the spider-like ability to cling to any surface. ";

                movierating.Text = "7.3";
                strUrl = "http://youtube.com/embed/1QMXBXDISUs";

            }
            if (moviename.Equals("Ardaas"))
            {
                moviedetailsxml.Text = "Movie Description: ARDAAS KARAAN explores the Generation gap faced by many families. Three elderly men live in Canada with their families and realize that each generation has a different conflicting opinion about life.";


                movierating.Text = "9.5";
                strUrl = "http://youtube.com/embed/UOprGzb5ZDY";

            }
            if (moviename.Equals("Asees"))
            {
                moviedetailsxml.Text = "Movie Description: When a dispute breaks out between five siblings over their mother's property, one devoted son will go to any lengths to protect her land.";

                movierating.Text = "7.4";
                strUrl = "http://youtube.com/embed/8lb7xal3lrg";

            }
            if (moviename.Equals("Udta Punjab"))
            {
                moviedetailsxml.Text = "Movie Description: The insurgence of substance abuse among the young in the Indian state of Punjab through the stories of a rock star, a migrant labourer, a doctor and a policeman.";


                movierating.Text = "7.8";
                strUrl = "http://youtube.com/embed/EJylz_9KYf8";

            }
            if (moviename.Equals("The Black Prince"))
            {
                moviedetailsxml.Text = "Movie Description: The Black Prince is a story of Queen Victoria and the Last King of Punjab, Maharajah Duleep Singh. His character as it evolves, torn between two cultures and facing constant dilemmas as a result";

                movierating.Text = "6.7";
                strUrl = "http://youtube.com/embed/SfR1iHNjw7s";

            }
            if (moviename.Equals("Sardaar Ji"))
            {
                moviedetailsxml.Text = "Movie Description: Jaggi Singh, the professional ghostbuster from rural Punjab is invited to driving away a ghost in London. Hilarious situations ensue when he falls in love with the ghost.";


                movierating.Text = "6.5";
                strUrl = "http://youtube.com/embed/MuMcSiIqCpc";

            }
            if (moviename.Equals("Dukhtar"))
            {
                moviedetailsxml.Text = "Movie Description: In the mountains of Pakistan, villagers hunt a mother, son and daughter after they flee on the eve of the girl's marriage to a tribal leader.";

                movierating.Text = "7.0";
                strUrl = "http://youtube.com/embed/KsH8SHSurT4";

            }
            if (moviename.Equals("Moor"))
            {
                moviedetailsxml.Text = "Movie Description: A railway stationmaster tries to cope with his wife's death, his estrangement from his son and the corrupt world in which he lives.";


                movierating.Text = "7.7";
                strUrl = "http://youtube.com/embed/Lla1lNt0wLI";

            }
            if (moviename.Equals("Rangreza"))
            {
                moviedetailsxml.Text = "Movie Description: ";

                movierating.Text = "8.5";
                strUrl = "http://youtube.com/embed/hbk9SpLNkHU";

            }
            if (moviename.Equals("Janaan"))
            {
                moviedetailsxml.Text = "Movie Description: After 11 years in Canada, young Meena returns to her native Pakistan for a family wedding and becomes romantically entangled with an adopted cousin.";


                movierating.Text = "7.2";
                strUrl = "http://youtube.com/embed/RgStr3iz0v0";

            }
            if (moviename.Equals("Pinky Memsaab"))
            {
                moviedetailsxml.Text = "Movie Description: Pinky Memsaab is a 2018 Urdu-language Pakistani drama film. The film stars Hajra Yamin, Kiran Malik, Adnan Jaffar, Sunny Hinduja, Khalid Ahmed and Shamim Hilaly.";

                movierating.Text = "6.6";
                strUrl = "http://youtube.com/embed/crzPqyo1TVU";

            }



            //play trailer
            string html = @"<html><body><div align=""center""><iframe width=""600"" height=""450"" align=""center"" src=""strUrl""></div></iframe></body></html>";
            var myWebView = (WebView)FindViewById(Resource.Id.videoView);
            var settings = myWebView.Settings;
            settings.JavaScriptEnabled = true;
            settings.UseWideViewPort = true;
            settings.LoadWithOverviewMode = true;
            settings.JavaScriptCanOpenWindowsAutomatically = true;
            settings.DomStorageEnabled = true;
            settings.SetRenderPriority(WebSettings.RenderPriority.High);
            settings.BuiltInZoomControls = false;

            settings.JavaScriptCanOpenWindowsAutomatically = true;
            myWebView.SetWebChromeClient(new WebChromeClient());
            settings.AllowFileAccess = true;
            settings.SetPluginState(WebSettings.PluginState.On);
            
            string strYouTubeURL = html.Replace("strUrl", strUrl);

            myWebView.LoadDataWithBaseURL(null, strYouTubeURL, "text/html", "UTF-8", null);
            
            spinnerView.ItemSelected += MyItemSelectedMethod;
        }
        void MyItemSelectedMethod(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            var index = e.Position;

            var value = myCategory[index];
            System.Console.WriteLine("value is of spinner " + value);

            dbcn = new DBHelperclass(this);
            if (value.Equals("Add To Favorite List") )
            {
                Intent newScreen4 = new Intent(this, typeof(favlist));

                dbcn.InsertValue(500, moviename, "0", "0", "0");
                StartActivity(newScreen4);

            }
            if (value.Equals("Add to Watch Later"))
            {
                Intent newScreen4 = new Intent(this, typeof(favlist));

                dbcn.InsertValue(501, moviename, "0", "0", "0");
                StartActivity(newScreen4);

            }

        }
    }
}