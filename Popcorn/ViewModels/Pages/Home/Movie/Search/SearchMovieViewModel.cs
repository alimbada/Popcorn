﻿using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
using NLog;
using Popcorn.Messaging;

namespace Popcorn.ViewModels.Pages.Home.Movie.Search
{
    /// <summary>
    /// Movie's search
    /// </summary>
    public sealed class SearchMovieViewModel : ViewModelBase
    {
        /// <summary>
        /// Logger of the class
        /// </summary>
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// The filter for searching movies
        /// </summary>
        private string _searchFilter;

        /// <summary>
        /// Initializes a new instance of the SearchMovieViewModel class.
        /// </summary>
        public SearchMovieViewModel()
        {
            RegisterMessages();
            RegisterCommands();
        }

        /// <summary>
        /// The filter for searching movies
        /// </summary>
        public string SearchFilter
        {
            get { return _searchFilter; }
            set { Set(() => SearchFilter, ref _searchFilter, value, true); }
        }

        /// <summary>
        /// Command used to search movies
        /// </summary>
        public RelayCommand SearchMovieCommand { get; private set; }

        /// <summary>
        /// Register messages
        /// </summary>
        private void RegisterMessages() => Messenger.Default.Register<PropertyChangedMessage<string>>(this, e =>
        {
            if (e.PropertyName == GetPropertyName(() => SearchFilter) && string.IsNullOrEmpty(e.NewValue))
                Messenger.Default.Send(new SearchMovieMessage(string.Empty));
        });

        /// <summary>
        /// Register commands
        /// </summary>
        private void RegisterCommands() => SearchMovieCommand =
            new RelayCommand(() =>
            {
                Logger.Debug(
                    $"New search criteria: {SearchFilter}");
                Messenger.Default.Send(new SearchMovieMessage(SearchFilter));
            });
    }
}