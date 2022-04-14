using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Views;
using AndroidX.AppCompat.App;
using AndroidX.Core.View;
using AndroidX.DrawerLayout.Widget;
using Google.Android.Material.Navigation;
using System;
using Toolbar = AndroidX.AppCompat.Widget.Toolbar;

namespace NavigationDrawerExample
{
    [Activity(Label = "@string/app_name", Theme = "@style/Theme.DesignDemo", MainLauncher = true)]
    public class MainActivity : AppCompatActivity, NavigationView.IOnNavigationItemSelectedListener
    {
        private Toolbar _toolbar;
        private DrawerLayout _drawerLayout;
        private NavigationView _navigationView;
        private HomeFragment _homeFragment;
        private MessageFragment _messageFragment;
        private FriendsFragment _friendsFragment;
        private DiscussionFragment _discussionFragment;

        [System.Obsolete]
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            _homeFragment = new HomeFragment();
            _messageFragment = new MessageFragment();
            _friendsFragment = new FriendsFragment();
            _discussionFragment = new DiscussionFragment();
            _toolbar = FindViewById<AndroidX.AppCompat.Widget.Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(_toolbar);
            _drawerLayout = FindViewById<DrawerLayout>(Resource.Id.drawerLayout);
            var drawerToggle = new ActionBarDrawerToggle(this, _drawerLayout, _toolbar, Resource.String.drawer_open, Resource.String.drawer_close);
            _drawerLayout.SetDrawerListener(drawerToggle);
            drawerToggle.SyncState();
            _navigationView = FindViewById<NavigationView>(Resource.Id.nav_view);
            _navigationView.SetNavigationItemSelectedListener(this);

        }
        public override void OnBackPressed()
        {
           
            if (_drawerLayout.IsDrawerOpen(GravityCompat.Start))
            {
               _drawerLayout.CloseDrawer(GravityCompat.Start);
            }
            else
            {
                base.OnBackPressed();
            }
        }

        public bool OnNavigationItemSelected(IMenuItem menuItem)
        {
            menuItem.SetChecked(true);
            switch (menuItem.ItemId)
            {
                case Resource.Id.nav_home:
                    SupportFragmentManager.BeginTransaction().Replace(Resource.Id.frameLayout, _homeFragment).Commit();
                    break;
                case Resource.Id.nav_messages:
                    SupportFragmentManager.BeginTransaction().Replace(Resource.Id.frameLayout, _messageFragment).Commit();
                    break;
                case Resource.Id.nav_friends:
                    SupportFragmentManager.BeginTransaction().Replace(Resource.Id.frameLayout, _friendsFragment).Commit();
                    break;
                case Resource.Id.nav_discussion:
                    SupportFragmentManager.BeginTransaction().Replace(Resource.Id.frameLayout, _discussionFragment).Commit();
                    break;
            }
            
            _drawerLayout.CloseDrawers();
            return true;
        }



        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

       
    }
}