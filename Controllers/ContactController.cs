using ContactManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ContactManager.Services;

namespace ContactManager.Controllers
{
    //BUILD RESTFUL APIs with ASP.NET Web API
    //Frank Campos Hernandez
    //Create Read-Only Web API
    //Create A Rad/Write Web API
    //Consume the Web API from an HTML
    public class ContactController : ApiController
    {
        /*( public string[] Get()
         {
             return new string[]
             {
             "Hello",
             "World"
             };
         }
         */
        //Using the ContactManager.Models
        /*public Contact[] Get()
         {
             return new Contact[]
             {
                new Contact
                {
                    Id = 1, 
                    Name = "Frank Campos" 
                }, 
                new Contact 
                {
                     Id= 1, 
                     Name="Frank Marcel"
                }
             };
         }*/
        private ContactRepository contactRepository;
        public ContactController()
        {
            this.contactRepository = new ContactRepository();
        }
        public Contact[] Get()
        {
            return this.contactRepository.GetAllContacts();
        }
        public HttpResponseMessage Post(Contact contact)
        {
            this.contactRepository.SaveContact(contact);

            var response = Request.CreateResponse<Contact>(System.Net.HttpStatusCode.Created, contact);

            return response;
        }
    }
}
