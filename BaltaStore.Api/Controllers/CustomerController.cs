using System;
using System.Collections.Generic;
using BaltaStore.Domain.StoreContext.CustomerCommands.Inputs;
using BaltaStore.Domain.StoreContext.Entities;
using BaltaStore.Domain.StoreContext.Queries;
using BaltaStore.Domain.StoreContext.Repositories;
using BaltaStore.Domain.StoreContext.ValueObjects;
using Microsoft.AspNetCore.Mvc;

namespace BaltaStore.Api.Controllers
{
    public class CustomerController : Controller
    {
        public readonly ICustomerRepository _repository;
        public CustomerController(ICustomerRepository repository)
        {
            _repository = repository;            
        }
        [HttpGet]
        [Route("custumers")]
        public IEnumerable<ListCustomerQueryResult> Get()
        {
            return _repository.Get();
        }

        [HttpGet]
        [Route("custumers/{id}")]
        public GetCustomerQueryResult GetById(Guid id)
        {
           return _repository.Get(id);
        }

        [HttpGet]
        [Route("custumers/{id}/orders")]
        public IEnumerable<ListCustomerOrdersQueryResult> GetOrders(Guid id)
        {
            return _repository.GetOrders(id);
        }

        [HttpPost]
        [Route("custumers")]
        public Customer Post([FromBody]CreateCustomerCommand command){
            var name = new Name(command.FirstName, command.LastName);
            var document = new Document(command.Document);
            var email = new Email(command.Email);
            var customer = new Customer(name, document, email, command.Phone);
            return customer;
        }
        
        [HttpPut]
        [Route("custumers/{id}")]
        public Customer Put([FromBody]CreateCustomerCommand command){
            
            var name = new Name(command.FirstName, command.LastName);
            var document = new Document(command.Document);
            var email = new Email(command.Email);
            var customer = new Customer(name, document, email, command.Phone);
            return customer;
        }

        [HttpDelete]
        [Route("custumers/{id}")]
        public object Delete(){
            return new {mensage="Cliente excluido com sucesso!"};
        }
        
    }
}