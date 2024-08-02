﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Contacts.Maui.Views_MVVM;
using Contacts.UseCases.Interfaces;
using System.Collections.ObjectModel;
using Contact = Contacts.CoreBusiness.Contact;

namespace Contacts.Maui.ViewModels
{
    public partial class ContactsViewModel : ObservableObject
    {
        private readonly IViewContactsUseCase viewContactsUseCase;
        private readonly IDeleteContactUseCase deleteContactUseCase;

        public ObservableCollection<Contact> Contacts { get; set; }

        public ContactsViewModel(
            IViewContactsUseCase viewContactsUseCase,
            IDeleteContactUseCase deleteContactUseCase)
        {
            this.viewContactsUseCase = viewContactsUseCase;
            this.deleteContactUseCase = deleteContactUseCase;
            this.Contacts = new ObservableCollection<Contact>();
        }

        public async Task LoadContactsAsync()
        {
            this.Contacts.Clear();

            var contacts = await viewContactsUseCase.ExecuteAsync(null);
            if (contacts != null && contacts.Count > 0)
            {
                foreach (var contact in contacts)
                {
                    this.Contacts.Add(contact);
                }
            }
        }
        [RelayCommand]
        public async Task DeleteContact(int contactId)
        {
            await deleteContactUseCase.ExecuteAsync(contactId);
            await LoadContactsAsync();
        }
        [RelayCommand]
        public async Task GotoEditContact(int contactId)
        {
            await Shell.Current.GoToAsync($"{nameof(EditContactPage_MVVM)}?Id={contactId}");
        }

        [RelayCommand]

        public async Task GotoAddContact()
        {
            await Shell.Current.GoToAsync(nameof(AddContactPage_MVVM));
        }
    }
}
