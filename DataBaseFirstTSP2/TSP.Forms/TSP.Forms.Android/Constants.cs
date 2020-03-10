using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace TSP.Forms.Droid
{
    public static class Constants
    {
        public const string ListenConnectionString = "Endpoint=sb://notificationtspengennering.servicebus.windows.net/;SharedAccessKeyName=DefaultListenSharedAccessSignature;SharedAccessKey=Y0vgv8F8hqkHCX3KmMzbc5nDt7I5cCLlNhTwRjWAMaw=";
        public const string NotificationHubName = "notificationtspengennering";
    }
}