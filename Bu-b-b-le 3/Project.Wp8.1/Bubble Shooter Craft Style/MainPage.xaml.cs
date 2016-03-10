using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine.Windows;
using Windows.ApplicationModel.Activation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

using VungleSDK;
// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238
using UnityPlayer;
using Windows.ApplicationModel.Core;
//UnityPlayer.AppCallbacks.Instance.InvokeOnAppThread
namespace Bubble_Shooter_Craft_Style
{
	/// <summary>
	/// An empty page that can be used on its own or navigated to within a Frame.
	/// </summary>
	public sealed partial class MainPage : Page
	{
		private WinRTBridge.WinRTBridge _bridge;
		
		private SplashScreen splash;
		private Rect splashImageRect;
		private WindowSizeChangedEventHandler onResizeHandler;
        VungleAd sdkInstance;
        public MainPage()
		{
			this.InitializeComponent();
			NavigationCacheMode = Windows.UI.Xaml.Navigation.NavigationCacheMode.Required;

			AppCallbacks appCallbacks = AppCallbacks.Instance;
			// Setup scripting bridge
			_bridge = new WinRTBridge.WinRTBridge();
			appCallbacks.SetBridge(_bridge);
            WP8Statics.WP8FunctionHandleShowAds += WP8Statics_ShowAds;
            WP8Statics.WP8FunctionHandleRateApp +=WP8Statics_RateApp;
			appCallbacks.RenderingStarted += () => { RemoveSplashScreen(); };

#if !UNITY_WP_8_1
			appCallbacks.SetKeyboardTriggerControl(this);
#endif
			appCallbacks.SetSwapChainPanel(GetSwapChainPanel());
			appCallbacks.SetCoreWindowEvents(Window.Current.CoreWindow);
			appCallbacks.InitializeD3DXAML();

			splash = ((App)App.Current).splashScreen;
			GetSplashBackgroundColor();
			OnResize();
			onResizeHandler = new WindowSizeChangedEventHandler((o, e) => OnResize());
			Window.Current.SizeChanged += onResizeHandler;


            sdkInstance = AdFactory.GetInstance("56dc034016ab53e11800001a");
        //    sdkInstance.OnAdPlayableChanged += SdkInstance_OnAdPlayableChanged;


#if UNITY_WP_8_1
            SetupLocationService();
#endif
		}
        //Event handler for OnAdPlayableChanged event
//private async void SdkInstance_OnAdPlayableChanged(object sender, AdPlayableEventArgs e)
     //   {
            //Run asynchronously on the UI thread
     //       await CoreApplication.MainView.Dispatcher.RunAsync(CoreDispatcherPriority.Normal,
      //      new DispatchedHandler(() => someMethod()));
      //  }
        void WP8Statics_ShowAds(object sender, EventArgs e)
        {
           
            ShowAdsVungleFull();
         
        }
		  async void ShowAdsVungleFull()
        {
            await sdkInstance.PlayAdAsync(new AdConfig { Incentivized = true, SoundEnabled = false });

        }
         async void WP8Statics_RateApp(object sender, EventArgs e)
          {
              //MarketplaceReviewTask marketplaceReviewTask = new MarketplaceReviewTask();
             // marketplaceReviewTask.Show();
              //await Windows.System.Launcher.LaunchUriAsync(new Uri("ms-windows-store:reviewapp"));
              //await Windows.System.Launcher.LaunchUriAsync(new Uri("ms-windows-store:reviewapp?appid=" + Windows.ApplicationModel.Store.CurrentApp.AppId));

              
                  await Windows.System.Launcher.LaunchUriAsync(new Uri("ms-windows-store:reviewapp?appid=" + Windows.ApplicationModel.Store.CurrentApp.AppId));

              
              
              // Windows.System.Launcher.LaunchUriAsync(new Uri("ms-windows-store:reviewapp?appid=" + Windows.ApplicationModel.Store.CurrentApp.AppId));
             
          }

    //    private void someMethod()//khong de lam gi ca
      //  {
            //Change IsEnabled property for each button
           
     //   }
        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.  The Parameter
        /// property is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
		{
			splash = (SplashScreen)e.Parameter;
			OnResize();
		}

		private void OnResize()
		{
			if (splash != null)
			{
				splashImageRect = splash.ImageLocation;
				PositionImage();
			}
		}

		private void PositionImage()
		{
			var inverseScaleX = 1.0f;
			var inverseScaleY = 1.0f;
#if UNITY_WP_8_1
			inverseScaleX = inverseScaleX / DXSwapChainPanel.CompositionScaleX;
			inverseScaleY = inverseScaleY / DXSwapChainPanel.CompositionScaleY;
#endif

			ExtendedSplashImage.SetValue(Canvas.LeftProperty, splashImageRect.X * inverseScaleX);
			ExtendedSplashImage.SetValue(Canvas.TopProperty, splashImageRect.Y * inverseScaleY);
			ExtendedSplashImage.Height = splashImageRect.Height * inverseScaleY;
			ExtendedSplashImage.Width = splashImageRect.Width * inverseScaleX;
		}

		private async void GetSplashBackgroundColor()
		{
			try
			{
				StorageFile file = await StorageFile.GetFileFromApplicationUriAsync(new Uri("ms-appx:///AppxManifest.xml"));
				string manifest = await FileIO.ReadTextAsync(file);
				int idx = manifest.IndexOf("SplashScreen");
				manifest = manifest.Substring(idx);
				idx = manifest.IndexOf("BackgroundColor");
				if (idx < 0)  // background is optional
					return;
				manifest = manifest.Substring(idx);
				idx = manifest.IndexOf("\"");
				manifest = manifest.Substring(idx + 1);
				idx = manifest.IndexOf("\"");
				manifest = manifest.Substring(0, idx);
				int value = 0;
				bool transparent = false;
				if (manifest.Equals("transparent"))
					transparent = true;
				else if (manifest[0] == '#') // color value starts with #
					value = Convert.ToInt32(manifest, 16) & 0x00FFFFFF;
				else
					return; // at this point the value is 'red', 'blue' or similar, Unity does not set such, so it's up to user to fix here as well
				byte r = (byte)(value >> 16);
				byte g = (byte)((value & 0x0000FF00) >> 8);
				byte b = (byte)(value & 0x000000FF);

				await CoreWindow.GetForCurrentThread().Dispatcher.RunAsync(CoreDispatcherPriority.High, delegate()
				{
					byte a = (byte)(transparent ? 0x00 : 0xFF);
					ExtendedSplashGrid.Background = new SolidColorBrush(Color.FromArgb(a, r, g, b));
				});
			}
			catch (Exception)
			{ }
		}

		public SwapChainPanel GetSwapChainPanel()
		{
			return DXSwapChainPanel;
		}

		public void RemoveSplashScreen()
		{
			DXSwapChainPanel.Children.Remove(ExtendedSplashGrid);
			if (onResizeHandler != null)
			{
				Window.Current.SizeChanged -= onResizeHandler;
				onResizeHandler = null;
			}
		}

#if !UNITY_WP_8_1
		protected override Windows.UI.Xaml.Automation.Peers.AutomationPeer OnCreateAutomationPeer()
		{
			return new UnityPlayer.XamlPageAutomationPeer(this);
		}
#else
		// This is the default setup to show location consent message box to the user
		// You can customize it to your needs, but do not remove it completely if your application
		// uses location services, as it is a requirement in Windows Store certification process
		private async void SetupLocationService()
		{
			AppCallbacks appCallbacks = AppCallbacks.Instance;
			if (!appCallbacks.IsLocationCapabilitySet())
			{
				return;
			}

			const string settingName = "LocationContent";
			bool userGaveConsent = false;

			object consent;
			var settings = Windows.Storage.ApplicationData.Current.LocalSettings;
			var userWasAskedBefore = settings.Values.TryGetValue(settingName, out consent);

			if (!userWasAskedBefore)
			{
				var messageDialog = new Windows.UI.Popups.MessageDialog("Can this application use your location?", "Location services");

				var acceptCommand = new Windows.UI.Popups.UICommand("Yes");
				var declineCommand = new Windows.UI.Popups.UICommand("No");

				messageDialog.Commands.Add(acceptCommand);
				messageDialog.Commands.Add(declineCommand);

				userGaveConsent = (await messageDialog.ShowAsync()) == acceptCommand;
				settings.Values.Add(settingName, userGaveConsent);
			}
			else
			{
				userGaveConsent = (bool)consent;
			}

			if (userGaveConsent)
			{	// Must be called from UI thread
				appCallbacks.SetupGeolocator();
			}
		}
#endif
	}
}
