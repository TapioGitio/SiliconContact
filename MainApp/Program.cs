using Business.Services;
using MainApp.Interfaces;
using MainApp.Services;

var contactService = new ContactService();
IMenuService run = new MenuService(contactService);

run.StartMenu();

