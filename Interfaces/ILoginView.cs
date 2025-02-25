﻿using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MP140.Interfaces
{
    public interface ILoginView
    {
        void DisplayProgressbar();
        void HideProgressBar();
        void DisplayRegistrationPopup();
        void RedirectToRoomView();
        void DisplayErrorMessage();
    }
}