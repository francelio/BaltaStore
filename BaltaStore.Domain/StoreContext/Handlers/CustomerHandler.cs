using System;
using BaltaStore.Domain.StoreContext.CustomerCommands.Inputs;
using BaltaStore.Domain.StoreContext.Entities;
using BaltaStore.Domain.StoreContext.ValueObjects;
using BaltaStore.Shared.Commands;
using FluentValidator;

namespace BaltaStore.Domain.StoreContext.Handlers
{
    public class CustomerHandlers : 
        Notifiable, 
        ICommandHandler<CreateCustomerCommand>,
        ICommandHandler<AddAddressCommand>
    {
        public ICommandResult Handle(CreateCustomerCommand command)
        {
            //Verificar se o cpf ja existe na base

            //verificar se o email ja existe na base

            //criar os VOS
            var name = new Name(command.FirstName,command.LastName);
            var document = new Document(command.Document);
            var email = new Email(command.Email);

            // Criar a entidade
            var customer = new Customer(name,document,email,command.Phone);

            //Validar entidades e vos
            AddNotifications(name.Notifications);
            AddNotifications(document.Notifications);
            AddNotifications(email.Notifications);
            AddNotifications(customer.Notifications);


            // persistir o cliente

            //Enviar um Email de boas vindas

            //Retornar o resultado para tela

            return new CreateCustomerCommandResult(Guid.NewGuid() ,name.ToString(),email.Address);

        }

        public ICommandResult Handle(AddAddressCommand command)
        {
            throw new System.NotImplementedException();
        }
    }
}
