using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Contact = Contacts.CoreBusiness.Contact;
using Contacts.UseCases.Interfaces;
using Contacts.Maui.Views_MVVM;


namespace Contacts.Maui.ViewModels
{
    public partial class ContactViewModel : ObservableObject
    {
        private Contact contact;
        private readonly IViewContactUseCase viewContactUseCase;
        private readonly IEditContactUseCase editContactUseCase;

        public Contact Contact 
        { 
            get => contact;
            set 
            {
                SetProperty(ref contact, value);
            }
        }

        public ContactViewModel(
            IViewContactUseCase viewContactUseCase,
            IEditContactUseCase editContactUseCase)
        {
           this.Contact = new Contact();
           this.viewContactUseCase = viewContactUseCase;
           this.editContactUseCase = editContactUseCase;
        }

        public async Task LoadContact(int contactId)
        {
            this.Contact = await this.viewContactUseCase.ExecuteAsync(contactId);
        }

        [RelayCommand]
        public async Task Editcontact()
        {
            await this.editContactUseCase.ExecuteAsync(this.Contact.ContactId, this.contact);
            await Shell.Current.GoToAsync($"{nameof(Contacts_MVVM_Page)}");
        }
        [RelayCommand]

        public async Task BackToContacts()
        {
            await Shell.Current.GoToAsync($"{nameof(Contacts_MVVM_Page)}");
        }
    }
}
