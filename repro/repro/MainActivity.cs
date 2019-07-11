using System;
using Android.Gms.Common;
using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Firebase;

using Firebase.Auth;

namespace repro
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        private FirebaseAuth mAuth;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.activity_main);

            // To use this you have to set up a project in the Firebase console and add the google-services.json file
            var baseOptions = FirebaseOptions.FromResource(Application.Context);
            var options = new FirebaseOptions.Builder(baseOptions)
                .SetProjectId(baseOptions.StorageBucket.Split('.')[0])
                .Build();

            var fa = FirebaseApp.InitializeApp(Application.Context, options, "Xamarin");

            //FirebaseApp fa = FirebaseApp.InitializeApp(Application.Context);

            mAuth = FirebaseAuth.GetInstance(fa);

            if (mAuth == null)
                Console.WriteLine("mAuth is null");

            AuthCredential credential = EmailAuthProvider.GetCredential("email@site.com", "password");

            var creds = mAuth.SignInWithEmailAndPassword("email@site.com", "password"); // Here the program crashes due to a null mAuth

           
        }
    }
}