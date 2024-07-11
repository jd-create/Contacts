﻿using Microsoft.Extensions.Logging;
using CommunityToolkit.Maui;
using Contacts.UseCases.PluginInterfaces;
using Contacts.Plugins.DataStore.InMemory;
using Contacts.UseCases.Interfaces;
using Contacts.UseCases;
using Contacts.Maui.Views;


namespace Contacts.Maui
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif
            builder.Services.AddSingleton<IContactRepository, ContactInMemoryRepository>();
            builder.Services.AddSingleton<IViewContactsUseCase, ViewContactsUseCase>();

            builder.Services.AddSingleton<ContactsPage>();

            return builder.Build();
        }
    }
}
