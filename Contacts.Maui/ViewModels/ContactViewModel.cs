using CommunityToolkit.Mvvm.ComponentModel;
using Contact = Contacts.CoreBusiness.Contact;
using Contacts.UseCases.Interfaces;

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

        public ContactViewModel(IViewContactUseCase viewContactUseCase)
        {
           this.Contact = new Contact();
           this.viewContactUseCase = viewContactUseCase;
        }

        public async Task LoadContact(int contactId)
        {
            this.Contact = await this.viewContactUseCase.ExecuteAsync(contactId);
        }

        //[RelayCommand]
        //public void SaveContact()
        //{
        //    ContactRepository.UpdateContact(
        //        this.Contact.ContactId, 
        //        this.Contact);
        //}
    }
}
