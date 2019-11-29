﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using TSP.Forms.Model;

namespace TSP.Forms.ViewModel
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        public List<Conversation> Messages { get; set; } = Conversations.All;

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
