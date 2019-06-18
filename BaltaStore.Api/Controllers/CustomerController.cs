using System;
using System.Collections.Generic;
using BaltaStore.Domain.StoreContext.CustomerCommands.Inputs;
using BaltaStore.Domain.StoreContext.Entities;
using BaltaStore.Domain.StoreContext.Handlers;
using BaltaStore.Domain.StoreContext.Queries;
using BaltaStore.Domain.StoreContext.Repositories;
using BaltaStore.Domain.StoreContext.ValueObjects;
using Microsoft.AspNetCore.Mvc;

namespace BaltaStore.Api.Controllers
{
    public class CustomerController : Controller
    {
        public readonly ICustomerRepository _repository;
        public readonly CustomerHandler _handler;
        public CustomerController(ICustomerRepository repository,CustomerHandler handler)
        {
            _repository = repository;  
            _handler = handler;          
        }
        [HttpGet]
        [Route("v1/custumers")]
        [ResponseCache(Duration=60)]
        public IEnumerable<ListCustomerQueryResult> Get()
        {
            return _repository.Get();
        }

        [HttpGet]
        [Route("v1/custumers/{id}")]
        public GetCustomerQueryResult GetById(Guid id)
        {
           return _repository.Get(id);
        }

        [HttpGet]
        [Route("v2/custumers/{document}")]
        public GetCustomerQueryResult GetByDocument(Guid document)
        {
           return _repository.Get(document);
        }

        [HttpGet]
        [Route("v1/custumers/{id}/orders")]
        public IEnumerable<ListCustomerOrdersQueryResult> GetOrders(Guid id)
        {
            return _repository.GetOrders(id);
        }

        [HttpPost]
        [Route("v1/custumers")]
        public CreateCustomerCommandResult Post([FromBody]CreateCustomerCommand command){
            var result = (CreateCustomerCommandResult)_handler.Handle(command);
            // if (_handler.Valid)
                // return BadRequest(_handler.Notifications);
            return result;
        }
        
        [HttpPut]
        [Route("v1/custumers/{id}")]
        public Customer Put([FromBody]CreateCustomerCommand command){
            
            var name = new Name(command.FirstName, command.LastName);
            var document = new Document(command.Document);
            var email = new Email(command.Email);
            var customer = new Customer(name, document, email, command.Phone);
            return customer;
        }

        [HttpDelete]
        [Route("v1/custumers/{id}")]
        public object Delete(){
            return new {mensage="Cliente excluido com sucesso!"};
        }
        
    }
}